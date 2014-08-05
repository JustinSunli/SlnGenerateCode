using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class ConnectionsData : DataLibBase
    {
        /// <summary>
        /// 序号。
        /// </summary>
        public const string rid = "rid";
        /// <summary>
        /// 引擎。
        /// </summary>
        public const string provider = "provider";
        /// <summary>
        /// 数据库描述。
        /// </summary>
        public const string discribe = "discribe";
        /// <summary>
        /// 连接字符串。
        /// </summary>
        public const string connectionString = "connectionString";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string Connection = "Connection";

        private void BuildData()
        {
            DataTable dt = new DataTable(Connection);

            dt.Columns.Add(rid, typeof(System.Int32));
            dt.Columns.Add(provider, typeof(System.String));
            dt.Columns.Add(discribe, typeof(System.String));
            dt.Columns.Add(connectionString, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[rid] };
            dt.TableName = Connection;
            this.Tables.Add(dt);
            this.DataSetName = "TConnection";
        }

        public ConnectionsData()
        {
            this.BuildData();
        }
    }
}
