using Foundation.Core;
using iCatGenerator.custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iCatGenerator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CustomConfig.GetSystemParameters();
            LogInterface.Listen(CustomConfig.LogDirectoryName.ToString());
            Application.Run(new frmMain());
        }
    }
}
