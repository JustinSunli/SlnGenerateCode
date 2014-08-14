using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Foundation.Core;
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
    public partial class frmSetConnect : XtraForm
    {
        public frmSetConnect()
        {
            InitializeComponent();
        }

        private void frmSetConnect_Load(
            object sender, EventArgs e)
        {
            this.gColConnections.DataSource = frmMain._ConnectionsData.Tables[0].DefaultView;
            this.tsslSaveInfor.Text = "";
        }

        private void gridView1_CellValueChanged(
            object sender, 
            CellValueChangedEventArgs e)
        {
            string xmlfilepath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Connection.xml");

            frmMain._ConnectionsData.WriteXml(xmlfilepath, XmlWriteMode.IgnoreSchema);
            frmMain._ConnectionsData.AcceptChanges();
            this.tsslSaveInfor.Text = string.Format("修改成功！{0}", DateTime.Now);
        }
    }
}
