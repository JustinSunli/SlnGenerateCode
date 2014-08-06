using Foundation.Core;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IDao
{
    public interface IColumnsDao
    {
        ColumnsData Select(QueryCondition conditions, string tableName);
        ColumnsData Select(string tableName);
        
    }
}
