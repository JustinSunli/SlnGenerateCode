using CustomSpring.Core.Dao;
using iCat.Generate.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Dao
{
    public class DBDao : BaseDao, IDBDao, IConnect
    {
        public DateTime? TestDB()
        {
            try { 
                return Convert.ToDateTime(
                    base.AdoTemplate.ExecuteScalar(
                    System.Data.CommandType.Text, 
                    "select getdate();")); 
            }
            catch { 
                return null; 
            }
        }

        public void SetConnection(
            Model.Connection connection)
        {
            #region
            base.SetAdoTemplate(
                connection.provider, 
                connection.connectionString);
            #endregion
        }
    }
}
