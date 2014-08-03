using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model.entity
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

        public DBStructure()
        {
            if (_tables == null)
                this._tables = new List<TableStructure>();
        }
    }
}
