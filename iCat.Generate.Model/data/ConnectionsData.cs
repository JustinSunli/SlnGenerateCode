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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="connection"></param>
        private void assignAll(
            DataRow currentRow, Connection connection)
        {
            #region
            this.Assign(currentRow, rid, connection.rid);
            this.Assign(currentRow, provider, connection.provider);
            this.Assign(currentRow, discribe, connection.discribe);
            this.Assign(currentRow, connectionString, connection.connectionString);
            #endregion
        }
        /// <summary>
        /// 接口：添加实体到缓存
        /// </summary>
        /// <param name="order"></param>
        public void AddCache(
            Connection connection)
        {
            #region
            base.checkIsNull(() =>
            {
                this.BuildData();
            });

            DataRow dr = this.Tables[0].NewRow();
            assignAll(dr, connection);
            this.Tables[0].Rows.Add(dr);
            #endregion
        }
        /// <summary>
        /// 接口：添加多实体到缓存
        /// </summary>
        /// <param name="orders"></param>
        public void AddCache(
            IList<Connection> connections)
        {
            #region
            foreach (Connection connection in connections)
                this.AddCache(connection);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public void EditCache(
            Connection connection)
        {
            #region
            base.checkIsNotNull(() =>
            {
                DataRow dr = findRow(connection);

                if (dr != null)
                    this.assignAll(dr, connection);
                else
                    Console.WriteLine("OrderData Cache hasn't order！");
            });
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public void DeleteCache(
            Connection connection)
        {
            #region
            base.checkIsNotNull(() =>
            {
                DataRow dr = findRow(connection);

                if (dr != null)
                    dr.Delete();
                else
                    Console.WriteLine("OrderData Cache hasn't order！");
            });
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private DataRow findRow(
            Connection connection)
        {
            #region
            return this.Tables[0].Rows.Find(
                this.getPrimaryParams(connection));
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private object[] getPrimaryParams(
            Connection connection)
        {
            #region
            object[] dbparams = new object[1];
            dbparams[1] = connection.rid;
            return dbparams;
            #endregion
        }
    }
}
