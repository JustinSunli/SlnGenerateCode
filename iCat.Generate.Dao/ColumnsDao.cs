using CustomSpring.Core.Dao;
using Foundation.Core;
using iCat.Generate.IDao;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Dao
{
    public class ColumnsDao : BaseDao, IColumnsDao, IConnect
    {

        public ColumnsData Select(
            QueryCondition conditions, 
            string tableName)
        {
            #region
            string sql = string.Format(@"select a.name,a.user_type_id as xtype,b.value,case  
	when c.name in ('nvarchar','nchar') then a.max_length/2 
	else a.max_length
	end as maxlength,
case 
	when c.name in ('decimal','numeric') then c.name+'('+CAST(a.max_length AS VARCHAR(5))+')('+CAST(a.precision AS VARCHAR(5))+','+CAST(a.scale AS VARCHAR(5))+')'
	else c.name+'('+CAST(case 
	when c.name in ('nvarchar','nchar') then a.max_length/2 
	else a.max_length
	end AS VARCHAR(5))+')'
	end as xtypename
from sys.columns a 
left join sys.extended_properties b on b.major_id = a.object_id and b.minor_id = a.column_id 
inner join sys.types c on a.user_type_id = c.user_type_id 
where a.object_id=object_id('{0}')", tableName);
            return base.GetDataSet<ColumnsData>(conditions, sql);
            #endregion
        }

        public ColumnsData Select(
            string tableName)
        {
            #region
            return this.Select(null, tableName);
            #endregion
        }

        public void SetConnection(
            Connection connection)
        {
            #region
            base.SetAdoTemplate(
                connection.provider, 
                connection.connectionString);
            #endregion
        }

        public List<string> SelectPrimaryKeys(
            string tableName)
        {
            List<string> keys = new List<string>();
            string sql = string.Format("exec sp_pkeys '{0}'", tableName);
            DataSet ds = base.AdoTemplate.DataSetCreate(CommandType.Text, sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
                keys.Add(dr["COLUMN_NAME"].ToString());
            return keys;
        }


        public new string GetConnection()
        {
            return base.GetConnection();
        }
    }
}
