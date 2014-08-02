/****************************************
***创建人：bhlfy
***创建时间：2013-08-29 03:00:29
***公司：iCat Studio
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class PageSort
    {
        private string _fieldname;

        public string _FieldName
        {
            get { return _fieldname; }
            set { _fieldname = value; }
        }

        private EnumSQLOrderBY _orderBy;

        public EnumSQLOrderBY _OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }
        
    }
}
