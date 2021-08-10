using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Lym.Common.Helpers
{
    /// <summary>
    /// windows命令辅助类
    /// </summary>
    public class WinCmdHelper
    {
        #region 执行Dos命令

        /// <summary>
        /// 执行Dos命令
        /// </summary>
        /// <param name="cmd">Dos命令及参数</param>
        /// <param name="isShowCmdWindow">是否显示cmd窗口</param>
        /// <param name="isCloseCmdProcess">执行完毕后是否关闭cmd进程</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static bool ExcuteDosCommand(string cmd, bool isShowCmdWindow, bool isCloseCmdProcess, string WorkingDirectory = "")
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd";

                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.RedirectStandardError = true;
                if (!string.IsNullOrEmpty(WorkingDirectory))
                {
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.WorkingDirectory = WorkingDirectory;
                }
                else
                {
                    p.StartInfo.UseShellExecute = false;
                } 
                p.StartInfo.CreateNoWindow = !isShowCmdWindow;
                p.OutputDataReceived += new DataReceivedEventHandler(delegate (object sender, DataReceivedEventArgs e)
                {
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        Console.WriteLine(e.Data);
                    }
                });
                p.Start();
                StreamWriter cmdWriter = p.StandardInput;
                p.BeginOutputReadLine();
                if (!String.IsNullOrEmpty(cmd))
                {
                    cmdWriter.WriteLine(cmd);
                }
                cmdWriter.Close();
                p.WaitForExit();
                if (isCloseCmdProcess)
                {
                    p.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region 判断指定的进程是否在运行中

        /// <summary>
        /// 判断指定的进程是否在运行中
        /// </summary>
        /// <param name="processName">要判断的进程名称，不包括扩展名exe</param>
        /// <param name="processFileName">进程文件的完整路径</param>
        /// <returns>存在返回true，否则返回false</returns>
        public static bool CheckProcessExists(string processName, string processFileName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(processFileName))
                {
                    if (processFileName == p.MainModule.FileName)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 结束指定的windows进程

        /// <summary>
        /// 结束指定的windows进程，如果进程存在
        /// </summary>
        /// <param name="processName">进程名称，不包含扩展名</param>
        /// <param name="processFileName">进程文件完整路径，如果为空则删除所有进程名为processName参数值的进程</param>
        public static bool KillProcessExists(string processName, string processFileName)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process p in processes)
                {
                    if (!String.IsNullOrEmpty(processFileName))
                    {
                        if (processFileName == p.MainModule.FileName)
                        {
                            p.Kill();
                            p.Close();
                        }
                    }
                    else
                    {
                        p.Kill();
                        p.Close();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
