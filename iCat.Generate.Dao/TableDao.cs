using CustomSpring.Core.Dao;
using iCat.Generate.IDao;
using iCat.Generate.Model;
using Spring.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Dao
{
    public class TableDao : BaseDao, ITableDao, IConnect
    {
        public TablesData Select()
        {
            #region
            string sql = @"select [name] from [sysobjects] where xtype='u'";
            return base.GetDataSet<TablesData>(null, sql);
            #endregion
        }
        public void SetConnection(
            Connection connection)
        {
            #region
            base.SetAdoTemplate(connection.provider, connection.connectionString);
            #endregion
        }

        public new string GetConnection()
        {
            return base.GetConnection();
        }
    }
}
