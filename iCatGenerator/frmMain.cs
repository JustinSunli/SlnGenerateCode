using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatGenerator
{
    public partial class frmMain : XtraForm
    {
        public frmMain()
        {
            InitializeComponent();

            UserLookAndFeel.Default.SetSkinStyle(
                SkinManager.Default.Skins[14].SkinName
                );
        }

        private void bindDBList()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Connection.xml"), XmlReadMode.Auto);

        }

        private void bindCodeConfig()
        { 
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bindDBList();
        }
    }
}
