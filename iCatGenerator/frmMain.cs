using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using iCat.Generate.Model;
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
                SkinManager.Default.Skins[5].SkinName
                );
        }
        public ConnectionsData _ConnectionsData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlFilename"></param>
        private void bindDBList(
            string xmlFilename)
        {
            #region
            _ConnectionsData = new ConnectionsData();
            string xmlfilepath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                xmlFilename);

            _ConnectionsData.ReadXml(xmlfilepath, XmlReadMode.Auto);

            this.lueditDBList.Properties.DataSource = _ConnectionsData.Tables[0].DefaultView;
            this.lueditDBList.Properties.DisplayMember = ConnectionsData.discribe;
            this.lueditDBList.Properties.ValueMember = ConnectionsData.rid;

            this.lueditDBList.EditValueChanged += lueditDBList_EditValueChanged;

            this.bindLookupGrid();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lueditDBList_EditValueChanged(
            object sender, EventArgs e)
        {
            #region
            DataRow dr = _ConnectionsData.Tables[0]
                .Rows.Find(this.lueditDBList.EditValue);

            if (dr != null)
                this.teConnectString.Text = 
                    dr[ConnectionsData.connectionString].ToString();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void bindLookupGrid()
        {
            #region
            LookUpColumnInfoCollection columns = 
                this.lueditDBList.Properties.Columns;

            LookUpColumnInfo col = new LookUpColumnInfo(
                    ConnectionsData.discribe, 
                    "数据库描述", 30);

            col.SortOrder = ColumnSortOrder.Ascending;
            columns.Add(col);

            col = new LookUpColumnInfo(
                    ConnectionsData.connectionString,
                    "连接字符串", 70);

            col.SortOrder = ColumnSortOrder.Ascending;
            columns.Add(col);
            #endregion
        }

        private void bindCodeConfig()
        { 
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.bindDBList("Connection.xml");
        }
    }
}
