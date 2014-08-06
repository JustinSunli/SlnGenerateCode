using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace iCatGenerator
{
    class DBComboBoxController
    {
        public LookUpEdit _Control { get; set; }
        public DBComboBoxController(LookUpEdit control)
        {
            this._Control = control;
        }
        public ConnectionsData GetConnections(
            string xmlSource)
        {
            #region
            ConnectionsData connectionsdata = new ConnectionsData();
            string xmlfilepath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                xmlSource);

            connectionsdata.ReadXml(xmlfilepath, XmlReadMode.Auto);
            return connectionsdata;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlFilename"></param>
        public void BindDBList(
            EventHandler editValueHandler)
        {
            #region

            _Control.Properties.DataSource = 
                frmMain._ConnectionsData.Tables[0].DefaultView;

            _Control.Properties.DisplayMember = ConnectionsData.discribe;
            _Control.Properties.ValueMember = ConnectionsData.rid;

            if(editValueHandler != null)
                _Control.EditValueChanged += new EventHandler(editValueHandler);

            this.bindLookupGrid();

            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void bindLookupGrid()
        {
            #region
            LookUpColumnInfoCollection columns =
                this._Control.Properties.Columns;

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

    }
}
