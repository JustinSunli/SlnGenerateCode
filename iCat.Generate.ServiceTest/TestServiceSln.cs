using iCat.Generate.IService;
using iCat.Generate.Model;
using iCat.Generate.Service;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.ServiceTest
{
    class TestServiceSln
    {
        private IApplicationContext _springContext = null;
        [SetUp]
        public void Setup()
        {
            _springContext = ContextRegistry.GetContext();
        }
        [Test]
        public void TestServiceSln_GenAll()
        {
            #region
            
            Namespace nspace = new Namespace()
            {
                _CustomSpring = "CustomSpring.Core",
                _FoundationCore = "Foundation.Core",
                _Prefix = "DocumentFlow"
            };

            Copyright copyright = new Copyright()
            {
                _Company = "iCat Studio",
                _Creater = "lhlfy",
                _Version = "V2.0"
            };

            GenSlnService slnservice = (GenSlnService)_springContext
                .GetObject("slnGenService");
            
            Connection connection = new Connection() { 
                rid = 1,
                provider = "SqlServer-2.0",
                connectionString = "server=192.168.0.236;database=TY_QBDB;user id=zhanghui;password=zhanghui;Pooling=true;Min Pool Size=10;Max Pool Size=50;Connection Lifetime=30;Connection Timeout=30;"
            };

            //slnservice.GenerateAll(connection);
            #endregion
        }


    }
}
