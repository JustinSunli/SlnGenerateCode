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

namespace {2}
{{
    public class {3}Dao : BaseDao, I{3}Dao
    {{
        public void Save({3}Data {4}Data)
        {{
            base.Save({4}Data);
        }}
        public int GetMaxId()
        {{
            return base.GetMaxId<{3}Data>();
        }}
        public {3}Data SelectSingleT(
            QueryCondition condition)
        {{
            return base.GetDataSet<{3}Data>(condition);
        }}
    }}
}}";
        //4为首字母小写的表名，3为原始表名，
        public string GetCode(
            TableStructure table,
            Namespace nSpace,
            Copyright copyright)
        {
            #region
            string all = "";
            List<string> args = new List<string>();
            args.Add(copyright.ToString());
            args.Add(getUsing(nSpace));
            args.Add(nSpace._Dao);
            args.Add(table._Name);
            args.Add(table._ParamNamePrefix);
            all = string.Format(_fileTemplate, args.ToArray<string>());
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


        public void GenerateProject(DBStructure dbStructure, Namespace nSpace, Copyright copyright, string parentDir)
        {
            throw new NotImplementedException();
        }
    }
}
