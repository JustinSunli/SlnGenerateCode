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
    class TestCMDService
    {
        private IApplicationContext _springContext = null;
        [SetUp]
        public void Setup()
        {
            _springContext = ContextRegistry.GetContext();
        }

        [Test]
        public void TestExecCMD()
        {
            CmdService slnservice = (CmdService)_springContext
    .GetObject("cmdService");

            Console.WriteLine(slnservice.ExeCMD("dir"));
        }
    }
}
