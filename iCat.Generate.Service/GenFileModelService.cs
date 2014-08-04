using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileModelService : GenFileServiceBase, IFileCreatorService
    {
        #region
        private const string _fileTemplate = @"
{0}
{1}
using System.Data;

namespace {2}
{{
    public class Entity{3} : IEntity
    {{
{4}

        public void Get(DataRow dr)
        {{
{5}
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
            this.createIterationStrings(table);
            List<string> args = new List<string>();
            args.Add(copyright.ToString());
            args.Add(getUsing(nSpace));
            args.Add(nSpace._Model);
            args.Add(table._Name);
            args.Add(getFields());
            args.Add(getAssign());
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
            usings.Add(nSpace._FoundationCore);
            return base.StrcatUsing(usings);
            #endregion
        }
        private List<CodeIneration> _strIterations = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        private void createIterationStrings(
            TableStructure table)
        {
            #region
            _strIterations = new List<CodeIneration>();
            _strIterations.Add(new CodeIneration()
            {
                _Template = "\t\tthis.{0} = dr[{1}Data.{0}].ToString();",
                _IterType = EnumStrIteration.EntityAssigns
            });
            _strIterations.Add(new CodeIneration()
            {
                _Template = "\t/// <summary>\r\n" +
                            "\t/// {0}。\r\n" +
                            "\t/// </summary>\r\n" +
                            "\tpublic string {1} {{ get; set; }}",
                _IterType = EnumStrIteration.EntityFields
            });

            base._dlGetIterParams = new DLGetIterParams(getIterParams);
            base.AppendCodeInerationsByTable(table, _strIterations);
            #endregion
        }
        private object[] getIterParams(
            CodeIneration iter,
            int colsRowIndex,
            TableStructure table)
        {
            #region
            IList<object> iterparams = new List<object>();
            DataRow dr = table._Columns.Tables[0].Rows[colsRowIndex];
            switch (iter._IterType)
            {
                case EnumStrIteration.EntityAssigns:
                    {
                        iterparams.Add(dr[ColumnsData.name]);
                        iterparams.Add(table._Name);
                        break;
                    }
                case EnumStrIteration.EntityFields:
                    {
                        iterparams.Add(dr[ColumnsData.value]);
                        iterparams.Add(dr[ColumnsData.name]);
                        break;
                    }
            }
            return iterparams.ToArray<object>();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getFields()
        {
            #region
            return _strIterations[1]._Returns.ToString();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getAssign()
        {
            #region
            return _strIterations[0]._Returns.ToString(); ;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void Generate()
        {
            throw new NotImplementedException();
        }
        #endregion


        public void GenerateProject(DBStructure dbStructure, Namespace nSpace, Copyright copyright, string parentDir)
        {
            throw new NotImplementedException();
        }
    }
}
