using CustomSpring.Core.Dao;
using iCat.Generate.IDao;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Dao
{
    public class TableDao : BaseDao, ITableDao
    {
        public TablesData Select()
        {
            #region
            string sql = @"select [name] from [sysobjects] where xtype='u'";
            return base.GetDataSet<TablesData>(null, sql);
            #endregion
        }

    }
}
