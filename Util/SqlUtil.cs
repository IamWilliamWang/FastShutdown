﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关机助手.Util
{
    class SqlUtil
    {
        /// <summary>
        /// 简单查询功能。
        /// 例如arg0:[Table1]  arg1:Id  arg2:Id>10
        /// </summary>
        /// <param name="查询列名">要查询的列名，用逗号隔开</param>
        /// <param name="查询表名">要查询的表名</param>
        /// <param name="查询条件">满足的查询条件，可为空</param>
        public static DataTable Select(string 查询表名,string 查询列名,string 查询条件 = null)
        {
            if (查询条件 != null)
                return SqlServerConnection.ExecuteQuery("select " + 查询列名 + " from " + 查询表名 + " where " + 查询条件);
            else
                return SqlServerConnection.ExecuteQuery("select " + 查询列名 + " from " + 查询表名);
        }

        /// <summary>
        /// 插入一条数据功能
        /// 例如arg0:[Table]  arg1:1,'data'  arg2:Id,Content
        /// </summary>
        /// <param name="表名称">插入表的表名</param>
        /// <param name="各列的值">插入数据对应各列的值</param>
        /// <param name="列名称">插入数据对应列的值，可为空</param>
        /// <returns></returns>
        public static bool Insert(string 表名称,string 各列的值,string 列名称=null)
        {
            if (列名称 == null)
                return SqlServerConnection.ExecuteUpdate("insert into " + 表名称 + " values (" + 各列的值 + ")") == 1;
            else
                return SqlServerConnection.ExecuteUpdate("insert into " + 表名称 + "("+列名称+") values (" + 各列的值 + ")") == 1;
        }

        /// <summary>
        /// 更新一条数据
        /// 例如arg0:[Table]  arg1:Context  arg2:'New text.'  arg3:Id=2
        /// </summary>
        /// <param name="表名称">要更新的表名</param>
        /// <param name="列名称">要更新条的列名</param>
        /// <param name="新值">需要更新的新数据</param>
        /// <param name="更新条件">更新数据条件</param>
        /// <returns></returns>
        public static bool Update(string 表名称,string 列名称,string 新值,string 更新条件=null)
        {
            if (更新条件 == null)
                return SqlServerConnection.ExecuteUpdate("update " + 表名称 + " set " + 列名称 + "=" + 新值) == 1;
            else
                return SqlServerConnection.ExecuteUpdate("update " + 表名称 + " set " + 列名称 + "=" + 新值+" where "+更新条件) == 1;
        }

        /// <summary>
        /// 简单删除功能
        /// 例如arg0:[Table] arg1:Id<50
        /// </summary>
        /// <param name="表名称">要删除内容的表名</param>
        /// <param name="更新条件">更新条件，可为空</param>
        /// <returns></returns>
        public static bool Delete(string 表名称,string 更新条件=null)
        {
            if (更新条件 != null)
                return SqlServerConnection.ExecuteUpdate("delete from " + 表名称 + " where " + 更新条件) > 0;
            else
                return SqlServerConnection.ExecuteUpdate("delete from " + 表名称) > 0;
        }
    }
}