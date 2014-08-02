using CustomSpring.Core.Dao;
using Foundation.Core;
using iCat.Generate.IDao;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Dao
{
    public class ColumnsDao : BaseDao, IColumnsDao
    {

        public ColumnsData Select(
            QueryCondition conditions, 
            string tableName)
        {
            string sql = string.Format(@"select a.name,a.xtype,b.value from [syscolumns] a 
left join sys.extended_properties b on b.major_id = a.id and b.minor_id = a.colorder 
where id=object_id('{0}')", tableName);
            return base.GetDataSet<ColumnsData>(conditions, sql);
        }

        public ColumnsData Select(
            string tableName)
        {
            return this.Select(null, tableName);
        }
    }
}
