using iCat.Generate.IService;
using iCat.Generate.Model;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            #region
            ColumnsData userdata = null;

            IColumnsService columnsservice = (IColumnsService)_springContext
                .GetObject("columnsService");
            userdata = columnsservice.GetColumns("TUser");
            #endregion
        }
        [Test]
        public void TestRegex()
        {
            #region
            string htmlmatch = @"/<(.)>.<\/\1>|<(.*) \/>/";
            string intmatch = @"\w(\d*)\w";
            Regex regex = new Regex(intmatch); //匹配两个字母间的数字串
            GroupCollection groups = regex.Match("<table><br>abc1212121wef</table>").Groups;
            Console.WriteLine(groups[0].Value);
            /*
            string input = "This is   text with   far  too   much   " +
                     "whitespace.";
            string pattern = "\\s+";
            string replacement = " ";
            string result = Regex.Replace(input, pattern, replacement);

            Console.WriteLine("Original String: {0}", input);
            Console.WriteLine("Replacement String: {0}", result);     
            */
            #endregion
        }

        [Test]
        public void TestPathCombine()
        {
            string codedir = Path.Combine("c:\\sina\\g", "good");
            Console.WriteLine(codedir);
            if (!Directory.Exists(codedir))
                Directory.CreateDirectory(codedir);
        }
    }
}
