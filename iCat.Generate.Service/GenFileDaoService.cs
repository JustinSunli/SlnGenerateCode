using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileDaoService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}
using System;
using System.Collections.Generic;
using System.Text;

namespace {2}
{
    public class {3}Dao : BaseDao, I{3}Dao
    {
        public void Save({3}Data {4}Data)
        {
            base.Save({4}Data);
        }
        public int GetMaxId({3}Data {4}Data)
        {
            return base.GetMaxId({4}Data);
        }
        public {3}Data SelectSingleT(
            QueryCondition condition)
        {
            return base.GetDataSet<{3}Data>(condition);
        }
    }
}";
        //4为首字母小写的表名，3为原始表名，
        public string GetCode(
            TableStructure table,
            Namespace nSpace,
            Copyright copyright)
        {
            #region
            string all = "";
            IList<object> args = new List<object>();
            args.Add(copyright);
            args.Add(getUsing(nSpace));
            args.Add(nSpace._Dao);
            args.Add(table._Name);
            args.Add(table._ParamNamePrefix);
            all = string.Format(_fileTemplate, args);
            Console.WriteLine(all);
            return all;
            #endregion
        }

        private string getUsing(
            Namespace nSpace)
        {
            #region
            IList<string> usings = new List<string>();
            usings.Add(nSpace._CustomSpring);
            usings.Add(nSpace._FoundationCore);
            usings.Add(nSpace._IDao);
            usings.Add(nSpace._Model);

            return base.StrcatUsing(usings);
            #endregion
        }

        public void Generate()
        {
            throw new NotImplementedException();
        }
    }
}
