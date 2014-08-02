using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class QueryCondition
    {
        public QueryCondition()
        {
            this._DBContainer = new DBConditions();
            this._pageSorts = new PageSorts();
            this._InKeys = new List<string>();
            this._ReturnFields = new List<string>();
        }
        private int _pageIndex;
        /// <summary>
        /// 页面索引（此处索引不同数组索引用法，是从1开始的）
        /// </summary>
	    public int _PageIndex
	    {
		    get { return _pageIndex;}
		    set { _pageIndex = value;}
	    }
        private int _pageSize;
        /// <summary>
        /// 单页容量
        /// </summary>
	    public int _PageSize
	    {
		    get { return _pageSize;}
		    set { _pageSize = value;}
	    }
	    private PageSorts _pageSorts;
        /// <summary>
        /// 排序条件（可添加多个排序条件，优先级分先后）
        /// </summary>
	    public PageSorts _PageSorts
	    {
		    get { return _pageSorts;}
		    set { _pageSorts = value;}
	    }

        private DBConditions _dbContainer;
        /// <summary>
        /// 条件容器（可添加数据项查询条件）
        /// </summary>
        public DBConditions _DBContainer
        {
            get { return _dbContainer; }
            set { _dbContainer = value; }
        }
        private IList<string> _inKeys;
        /// <summary>
        /// 分页依据的IN条件
        /// </summary>
        public IList<string> _InKeys
        {
            get { return _inKeys; }
            set { _inKeys = value; }
        }
        private string _tableName;
        /// <summary>
        /// DataSet的tableName
        /// </summary>
        public string _TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
        
        /// <summary>
        /// 添加分页依据的IN条件关键字
        /// </summary>
        /// <param name="keyname"></param>
        public void AddInKey(string keyname)
        {
            #region
            if (this._InKeys == null)
                this._InKeys = new List<string>();
            if(this._inKeys.IndexOf(keyname) == -1)
                this._InKeys.Add(keyname);
            #endregion
        }

        private IList<string> _returnFields;

        public IList<string> _ReturnFields
        {
            get { return _returnFields; }
            set { _returnFields = value; }
        }
        /// <summary>
        /// 返回业务逻辑中要用到的数据项
        /// </summary>
        /// <param name="fieldName"></param>
        public void AddReturnField(string fieldName)
        {
            #region
            if (this._ReturnFields == null)
                this._ReturnFields = new List<string>();
            if (this._ReturnFields.IndexOf(fieldName) == -1)
                this._ReturnFields.Add(fieldName);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public void SetPageIndex(
            int pageIndex, int pageSize)
        {
            #region
            this._PageIndex = pageIndex;
            this._PageSize = pageSize;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="pageSize"></param>
        public void SetPageStart(
            int start, int pageSize)
        {
            #region
            int pageindex = 0;
            if (pageSize != 0)
                pageindex = (pageSize + start) / pageSize;

            this._PageIndex = pageindex;
            this._PageSize = pageSize;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetReturnFields()
        {
            #region
            string strfields = "";
            if (this._ReturnFields != null)
            {
                for (int i = 0; i < this._ReturnFields.Count; i++)
                {
                    if (i == 0)
                        strfields = this._ReturnFields[i];
                    else
                        strfields += string.Format(",[{0}]", this._ReturnFields[i]);
                }
            }
            return (strfields == "") ? "*" : strfields;
            #endregion
        }
	/*
        private string _TableName;
        private string _ReturnFields;
        private int _PageIndex = 1;
        private int _PageSize = int.MaxValue;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }

        }
        /// <summary>
        /// 返回字段
        /// </summary>
        public string ReturnFields
        {
            get
            {
                return _ReturnFields;
            }
            set
            {
                _ReturnFields = value;
            }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }

        }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }
        */
    }
}
