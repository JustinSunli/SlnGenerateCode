using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class ColumnsData : DataLibBase
    {
        /// <summary>
        /// 。
        /// </summary>
        public const string name = "name";
        /// <summary>
        /// 。
        /// </summary>
        public const string xtype = "xtype";
        /// <summary>
        /// 。
        /// </summary>
        public const string value = "value";
        /// <summary>
        /// 。
        /// </summary>
        public const string maxlength = "maxlength";
        /// <summary>
        /// 。
        /// </summary>
        public const string xtypename = "xtypename";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string SysColumns = "syscolumns";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(SysColumns);

            dt.Columns.Add(name, typeof(System.String));
            dt.Columns.Add(xtype, typeof(System.Int32));
            dt.Columns.Add(maxlength, typeof(System.Int32));
            dt.Columns.Add(value, typeof(System.String));
            dt.Columns.Add(xtypename, typeof(System.String));
            //dt.PrimaryKey = new DataColumn[1] { dt.Columns[uid] };
            dt.TableName = SysColumns;
            this.Tables.Add(dt);
            this.DataSetName = "TSysColumns";
        }

        public ColumnsData()
        {
            this.BuildData();
        }
    }
}
