using iCat.Generate.IDao;
using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class ColumnsService : IColumnsService
    {
        public IColumnsDao _ColumnsDao { get; set; }
        public ColumnsData GetColumns(
            string tableName)
        {
            return _ColumnsDao.Select(tableName);
        }
    }
}
