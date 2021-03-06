﻿using System;
using System.Diagnostics;

namespace 关机助手.Util
{
    class SystemCommandUtil
    {
        /**
         * @parms command需要执行的dos指令
         * @returns 执行过程中显示的字符串
         */
        public static String ExecuteCommand(String command, bool adminAuthorized=false)
        {
            Process process = new Process();

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            if (adminAuthorized == true)
                process.StartInfo.Verb = "runas";

            try
            {
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");
            }
            catch(Exception exception)
            {
                System.Windows.Forms.MessageBox.Show(exception.ToString(), "错误信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            
            return process.StandardOutput.ReadToEnd();
        }
    }
    
}
