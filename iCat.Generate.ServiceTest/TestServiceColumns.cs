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
    class TestServiceColumns
    {
        private IApplicationContext _springContext = null;
        [SetUp]
        public void Setup()
        {
            _springContext = ContextRegistry.GetContext();
        }
        [Test]
        public void TestServiceColumns_Select()
        {
            ColumnsData userdata = null;

            IColumnsService columnsservice = (IColumnsService)_springContext
                .GetObject("columnsService");
            //QueryCondition condition = new QueryCondition();
            userdata = columnsservice.GetColumns("TUser");
        }

    }
}
