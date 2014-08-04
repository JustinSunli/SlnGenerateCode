using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class TablesData : DataLibBase
    {
        /// <summary>
        /// 。
        /// </summary>
        public const string name = "name";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string sysobjects = "sysobjects";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(sysobjects);

            dt.Columns.Add(name, typeof(System.String));
            dt.TableName = sysobjects;
            this.Tables.Add(dt);
            this.DataSetName = "sysobjects";
        }

        public TablesData()
        {
            this.BuildData();
        }
    }
}
