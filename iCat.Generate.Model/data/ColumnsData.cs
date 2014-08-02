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
        /// 用户序列号。
        /// </summary>
        public const string name = "name";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string xtype = "xtype";
        /// <summary>
        /// 用户密码。
        /// </summary>
        public const string value = "value";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string SysColumns = "syscolumns";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(SysColumns);
            
            dt.Columns.Add(name, typeof(System.Int32));
            dt.Columns.Add(xtype, typeof(System.String));
            dt.Columns.Add(value, typeof(System.String));
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
