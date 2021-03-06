﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using 关机助手.Util;

namespace 关机助手
{
    public partial class AnalysingForm : Form
    {
        DataTable resultTable { get; set; }
        DatabaseAgency sqlite = new DatabaseAgency();
        List<string> pointLabels = new List<string>();

        public AnalysingForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            this.FillDataGridView();
            this.FillChart();

            this.TopMost = MainForm.窗口置顶;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionForm.ShowDialog((Exception) e.ExceptionObject);
        }

        #region DataGridView初始化
        private void FillDataGridView()
        {
            this.QueryAndCalculate();
            DataTable resultTable = this.resultTable;
            foreach(DataRow row in resultTable.Rows)
            {
                row[2] = row[2].ToString().Replace("days", "天");
            }
            this.dataGridView.DataSource = resultTable;
        }

        private void QueryAndCalculate()
        {
            try
            {
                sqlite.ExecuteUpdate(DeleteTempVarsSQL());
            }
            catch (Exception)
            {

            }
            sqlite.ExecuteUpdate(CreateSqlFunctionSQL());
            resultTable = sqlite.ExecuteQuery(CountSumDateTimeOfEachMonthSQL());
        }

        private string CreateSqlFunctionSQL() =>
            "Create function SecToDateTime(@total int) " +
            "Returns varchar(50) " +
            "As " +
            "Begin " +
            "   Declare @day int " +
            "   Declare @hour int " +
            "   Declare @min int " +
            "   Declare @sec int " +
            "   Declare @dt varchar(50) " +
            "   set @sec = @total % 60 " +
            "   set @total = floor(@total / 60) " +
            "   set @min = @total % 60 " +
            "   set @total = floor(@total / 60) " +
            "   set @hour = @total % 24 " +
            "   set @total = floor(@total / 24) " +
            "   set @day = @total " +
            " " +
            "   set @dt = convert(varchar(50), @day) + ' days ' + convert(varchar(50), @hour) + ':' + convert(varchar(50), @min) + ':' + convert(varchar(50), @sec) " +
            "Return @dt " +
            "End ";

        private string DeleteTempVarsSQL() =>
            "drop function SecToDateTime ";

        private string CountSumDateTimeOfEachMonthSQL() =>
            "/*创建该函数对象*/\n" +
            "/*重复创建需要先 drop function SecToDateTime */\n" +
            "               \n " +
            "select YEAR(开机时间) 年份, MONTH(开机时间) 月份, dbo.SecToDateTime(sum(datediff(second, '00:00:00', 时长))) 当月累计时长 /*into 每月累计时长表*/\n" +
            "from[Table]\n" +
            "group by YEAR(开机时间),MONTH(开机时间)" +
            "order by YEAR(开机时间),MONTH(开机时间);\n";
        #endregion

        #region Chart初始化
        private void FillChart()
        {
            List<string> xData = new List<string>();
            List<double> yData = new List<double>();

            foreach (DataRow row in resultTable.Rows)
            {
                xData.Add(row[0] + "年" + row[1] + "月");
                yData.Add(Transfer2Hour(row[2].ToString()));
            }

            chart.Series[0].Points.Clear();
            chart.Series[0]["PieLineColor"] = "Black"; //绘制黑色的连线
            chart.Series[0].Points.DataBindXY(xData, yData); //绑定数据，进行绘图并添加了数据标签
            chart.Series[0].IsVisibleInLegend = false;
            chart.Series[0].ToolTip = "月份：#VALX\n时长：#VALY小时";
            
            SaveLabels();
        }

        private double Transfer2Hour(String original)
        {
            String[] dayHourMinSec = original.Replace(" ", "").Replace("天", ":").Split(':');
            if (dayHourMinSec.Count() != 4)
                return 0;

            double day = double.Parse(dayHourMinSec[0]);
            double hour = double.Parse(dayHourMinSec[1]);
            double min = double.Parse(dayHourMinSec[2]);
            double sec = double.Parse(dayHourMinSec[3]);

            return CutDownSmallNumber(day * 24 + hour + min / 60 + sec / 3600, 2);
        }

        private double CutDownSmallNumber(double longNumber, int smallNumberLength)
        {
            int tmp = (int) Math.Floor(longNumber * Math.Pow(10, smallNumberLength));
            return 1.0 * tmp / Math.Pow(10, smallNumberLength);
        }
        
        /// <summary>
        /// 保存现有的所有数据标签
        /// </summary>
        private void SaveLabels()
        {
            this.pointLabels.Clear();
            foreach (var point in this.chart.Series[0].Points)
                this.pointLabels.Add(point.Label);
        }

        /// <summary>
        /// 去除图中所有的数据标签
        /// </summary>
        private void RemoveLabels()
        {
            foreach (var point in this.chart.Series[0].Points)
                point.Label = "";
        }

        /// <summary>
        /// 恢复图中所有的数据标签
        /// </summary>
        private void RestoreLabels()
        {
            for (var i = 0; i < this.chart.Series[0].Points.Count; i++)
                this.chart.Series[0].Points[i].Label = this.pointLabels[i];
        }
        #endregion

        #region 图形切换选项卡
        private void 饼图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].ChartType = SeriesChartType.Pie;
            this.chart.Series[0].IsVisibleInLegend = true;
        }

        private void 空心饼图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].ChartType = SeriesChartType.Doughnut;
            this.chart.Series[0].IsVisibleInLegend = true;
        }

        private void 柱状图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].ChartType = SeriesChartType.Column;
            this.chart.Series[0].IsVisibleInLegend = false;
        }

        private void 折线图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].ChartType = SeriesChartType.Line;
            this.chart.Series[0].IsVisibleInLegend = false;
        }

        private void 曲线图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].ChartType = SeriesChartType.Spline;
            this.chart.Series[0].IsVisibleInLegend = false;
        }
        #endregion

        #region 更换颜色选项卡
        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].Color = Color.Red;
        }

        private void 蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].Color = Color.Blue;
        }

        private void 黄色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].Color = Color.Yellow;
        }

        private void 紫色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].Color = Color.BlueViolet;
        }

        private void 灰色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].Color = Color.Gray;
        }

        private void 浅蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.Series[0].Color = Color.LightSkyBlue;
        }
        #endregion

        #region 切换3D效果选项卡
        private void 切换3D效果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chart.ChartAreas[0].Area3DStyle.Enable3D = !this.chart.ChartAreas[0].Area3DStyle.Enable3D;
        }
        #endregion

        #region 关闭选项卡
        private void 数据标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.数据标签ToolStripMenuItem.Text == "关闭数据标签")
            {
                RemoveLabels();
                this.数据标签ToolStripMenuItem.Text = "打开数据标签";
            }
            else if (this.数据标签ToolStripMenuItem.Text == "打开数据标签") 
            {
                RestoreLabels();
                this.数据标签ToolStripMenuItem.Text = "关闭数据标签";
            }
        }

        private void 关闭程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 保存图片选项卡
        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "png文件 (*.png)|所有文件 (*.*)";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                String fullFileName = fileDialog.FileName;
                if (fullFileName.Contains("png") == false)
                    fullFileName += ".png";
                chart.SaveImage(fullFileName, ChartImageFormat.Png);
                MessageBox.Show("已经成功保存图片！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        #endregion

        #region 分析时间分布
        private void 开机时间分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> hourNums = new List<int>();
            List<int> 频度 = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                hourNums.Add(i);
                频度.Add(0);
            }
            AnalyseByTimes(hourNums, 频度, "开机");

            this.chart.Series[0].Points.Clear();
            this.chart.Series[0].Points.DataBindXY(hourNums, 频度);
            this.返回总图ToolStripMenuItem.Enabled = true;
        }

        private void AnalyseByTimes(List<int> hourNums, List<int> 频度, string keyWord)
        {
            if (keyWord != "开机" && keyWord != "关机")
                return;

            string sql = "select datename(hour, " + keyWord + "时间) from[Table]";
            DataTable queryResult = sqlite.ExecuteQuery(sql);
            foreach (DataRow row in queryResult.Rows)
            {
                if (row[0].ToString() == "")
                    continue;
                频度[int.Parse(row[0].ToString())]++;
            }
        }

        private void 关机时间分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> hourNums = new List<int>();
            List<int> 频度 = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                hourNums.Add(i);
                频度.Add(0);
            }
            AnalyseByTimes(hourNums, 频度, "关机");

            this.chart.Series[0].Points.Clear();
            this.chart.Series[0].Points.DataBindXY(hourNums, 频度);
            this.返回总图ToolStripMenuItem.Enabled = true;
        }

        private void 返回总图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Form_Load(sender, e);
        }
        #endregion
    }
}
