using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class Connection : IEntity
    {
        /// <summary>
        /// 序号。
        /// </summary>
        public int rid { set; get; }
        /// <summary>
        /// 引擎。
        /// </summary>
        public string provider { set; get; }
        /// <summary>
        /// 数据库描述。
        /// </summary>
        public string discribe { set; get; }
        /// <summary>
        /// 连接字符串。
        /// </summary>
        public string connectionString { set; get; }

        public void Get(System.Data.DataRow dr)
        {
            this.rid = Convert.ToInt32(dr[ConnectionsData.rid]);
            this.provider = dr[ConnectionsData.provider].ToString();
            this.discribe = dr[ConnectionsData.discribe].ToString();
            this.connectionString = dr[ConnectionsData.connectionString].ToString();

        }
    }
}
