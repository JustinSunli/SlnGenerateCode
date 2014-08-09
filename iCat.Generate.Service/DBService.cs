using iCat.Generate.IDao;
using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class DBService : IDBService
    {
        public IDBDao _DBDao { get; set; }

        public ITableDao _TableDao { get; set; }

        public IColumnsDao _ColumnsDao { get; set; }

        public bool IsSuccessConnectDB(
            Model.Connection connection)
        {
            #region
            (_DBDao as IConnect).SetConnection(connection);
            DateTime? dbtime = this._DBDao.TestDB();
            return (dbtime != null);
            #endregion
        }

        public DBStructure GetDBStructure(
            Model.Connection connection)
        {
            #region
            (_TableDao as IConnect).SetConnection(connection);
            (_ColumnsDao as IConnect).SetConnection(connection);
            DBStructure dbstructure = new DBStructure();

            TablesData tablesdata = _TableDao.Select();
            dbstructure._TablesData = tablesdata;
            foreach (DataRow dr
                in tablesdata.Tables[0].Rows)
            {
                string tablename = dr[TablesData.name].ToString();
                dbstructure._Tables.Add(new TableStructure()
                {
                    _Name = tablename,
                    _Columns = _ColumnsDao.Select(tablename),
                    _PrimaryKeys = _ColumnsDao.SelectPrimaryKeys(tablename)
                });
            }
            return dbstructure;
            #endregion
        }
    }
}
