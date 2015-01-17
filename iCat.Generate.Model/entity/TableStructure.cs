using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class TableStructure
    {
        private bool _isGen = false;

        public bool _IsGen
        {
            get { return _isGen; }
            set { _isGen = value; }
        }
        
        private string _name;

        public string _Name
        {
            get { return _name; }
            set { 
                _name = value;
                _paramNamePrefix = getParamPrefix();
                _nameLower = _name.ToLower();

            }
        }
        private string _nameLower;

        public string _NameLower
        {
            get { return _nameLower; }
        }
        
        private string _paramNamePrefix;

        public string _ParamNamePrefix
        {
            get { return _paramNamePrefix; }
            //set { _paramNamePrefix = value; }
        }
        

        private ColumnsData _columns;

        public ColumnsData _Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        private List<string> _primaryKeys;

        public List<string> _PrimaryKeys
        {
            get { return _primaryKeys; }
            set { _primaryKeys = value; }
        }

        private bool _hasIntPrimaryKey;

        public bool _HasIntPrimaryKey
        {
            get { return _hasIntPrimaryKey; }
            set { _hasIntPrimaryKey = value; }
        }
        

        public TableStructure()
        {
            if (_columns == null)
                this._columns = new ColumnsData();
            if (_primaryKeys == null)
                this._primaryKeys = new List<string>();
        }

        private string getParamPrefix()
        {
            #region
            string prefix = "";
            if (this._name.Length == 1)
                prefix = this._name.ToLower();
            else
            {
                string first = this._name.Substring(0, 1).ToLower();
                string other = this._name.Substring(1, this._name.Length - 1);
                prefix = string.Format("{0}{1}", first, other);
            }
            return prefix;
            #endregion
        }

        public string GetEnumSqlTypeName(
            string columnName)
        {
            #region
            string typename = "";
            DataRow[] drs = this._Columns.Tables[0].Select("name='" + columnName+"'");
            if (drs.Length > 0)
                typename = SqlType.GetEnumString(drs[0][ColumnsData.xtype].ToString());
            return typename;
            #endregion
        }

        public bool CheckHasIntPrimaryKey()
        {
            bool has = false;

            foreach (string col in _PrimaryKeys)
            {
                for (int i = 0; i < _columns.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = _columns.Tables[0].Rows[i];
                    if (col == dr[ColumnsData.name].ToString())
                    {
                        string xtype = dr[ColumnsData.xtype].ToString();
                        if (xtype == "56" ||
                            xtype == "127" ||
                            xtype == "48" ||
                            xtype == "52")
                        {
                            return true;
                        }
                    }
                }
            }

            return has;
        }
    }
}
