using iCat.Generate.IService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class CmdService : ICmdService
    {

        public string ExeCMD(string command)
        {
            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe"; //确定程序名
            p.StartInfo.Arguments = "/c " + command; //确定程式命令行
            p.StartInfo.UseShellExecute = false; //Shell的使用
            p.StartInfo.RedirectStandardInput = true; //重定向输入
            p.StartInfo.RedirectStandardOutput = true; //重定向输出
            p.StartInfo.RedirectStandardError = true; //重定向输出错误
            p.StartInfo.CreateNoWindow = true; //设置置不显示示窗口

            p.Start(); //00

            //p.StandardInput.WriteLine(command); //也可以用这种方式输入入要行的命令
            //p.StandardInput.WriteLine("exit"); //要得加上Exit要不然下一行程式

            return p.StandardOutput.ReadToEnd(); //输出出流取得命令行结果果


        }
    }
}
