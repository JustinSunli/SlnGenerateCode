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
    public class GenSlnService
    {
        public IColumnsDao _ColumnsDao { get; set; }
        public ITableDao _TablesDao { get; set; }
        public DBStructure _DBStructure { get; set; }
        public Copyright _Copyright { get; set; }
        public Namespace _NameSpace { get; set; }
        private IList<IFileCreatorService> _fileServices;
        public void GenerateAll()
        {
            #region
            if (_DBStructure == null)
                _DBStructure = new DBStructure();

            this.fillDBStructure();
            string dir = "E:\\work";

            foreach (IFileCreatorService fileservice
                in _fileServices)
            {
                fileservice.GenerateProject(
                    this._DBStructure, 
                    this._NameSpace, 
                    this._Copyright, dir);
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void initFileServices()
        {
            #region
            if (_fileServices == null)
            {
                _fileServices =
                    new List<IFileCreatorService>();
                _fileServices.Add(new GenFileModelDataService());
            }
            #endregion
        }
        public GenSlnService(
            Copyright copyright, 
            Namespace nameSpace)
        {
            this._Copyright = copyright;
            this._NameSpace = nameSpace;
            this.initFileServices();
        }
        public void GenerateSelect(
            IList<string> tables)
        {
            this.fillDBStructure(tables);

        }

        private void fillDBStructure(
            IList<string> tables)
        { 
            
        }

        private void fillDBStructure()
        {
            TablesData tablesdata = _TablesDao.Select();
            foreach(DataRow dr 
                in tablesdata.Tables[0].Rows)
            { 
                string tablename = dr[TablesData.name].ToString();
                _DBStructure._Tables.Add(new TableStructure() {
                    _Name = tablename,
                    _Columns = _ColumnsDao.Select(tablename)
                });
            }
        }

        public GenSlnService()
        { initFileServices(); }
    }
}
