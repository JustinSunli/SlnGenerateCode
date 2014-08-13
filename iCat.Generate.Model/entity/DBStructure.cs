using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class DBStructure
    {
        private string _dbName;

        public string _DBName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        private IList<TableStructure> _tables;

        public IList<TableStructure> _Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        private TablesData _tablesData;

        public TablesData _TablesData
        {
            get { return _tablesData; }
            set { _tablesData = value; }
        }
        

        private Connection _connection;

        public Connection _Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public DBStructure()
        {
            if (_connection == null)
                this._connection = new Connection();
            if (_tables == null)
                this._tables = new List<TableStructure>();
        }
    }
}
