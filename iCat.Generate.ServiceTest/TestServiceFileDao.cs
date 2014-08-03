using iCat.Generate.IService;
using iCat.Generate.Model;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.ServiceTest
{
    class TestServiceFileDao
    {
        private IApplicationContext _springContext = null;
        [SetUp]
        public void Setup()
        {
            _springContext = ContextRegistry.GetContext();
        }
        [Test]
        public void TestServiceFileDao_GetCode()
        {
            IColumnsService columnsservice = (IColumnsService)_springContext
                .GetObject("columnsService");

            TableStructure tablestructure = new TableStructure();
            tablestructure._Name = "TUser";
            tablestructure._Columns = columnsservice
                .GetColumns(tablestructure._Name);

            Namespace nspace = new Namespace(){
                _CustomSpring = "CustomSpring.Core",
                _FoundationCore = "Foundation.Core",
                _Prefix = "iCat.Generate"
            };

            Copyright copyright = new Copyright(){
                _Company = "iCat Studio",
                _Creater = "lhlfy",
                _Version = "V2.0"
            };

            IFileCreatorService fileservice = (IFileCreatorService)_springContext
                .GetObject("fileDaoService");
            fileservice.GetCode(tablestructure, nspace, copyright);
        }


    }
}
