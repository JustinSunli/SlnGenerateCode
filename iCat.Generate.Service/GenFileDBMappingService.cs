using Foundation.Core;
using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    class GenFileDBMappingService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace {1}
{{
    public class {2}Mapping
    {{
{3}
        /// <summary>
        /// 表名。
        /// </summary>
        public const string {2} = ""{2}"";
    }}
}}";

        public void Generate(
            Model.TableStructure table)
        {

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
                _Template = "\t\t/// <summary>\r\n" +
                            "\t\t/// {0}。\r\n" +
                            "\t\t/// </summary>\r\n" +
                            "\t\tpublic const string {1} = \"{1}\";",
                _IterType = EnumStrIteration.DataFields
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
                case EnumStrIteration.DataFields:
                    {
                        iterparams.Add(dr[ColumnsData.value]);
                        iterparams.Add(dr[ColumnsData.name]);
                        break;
                    }
            }
            return iterparams.ToArray<object>();
            #endregion
        }
        public string GetCode(
            Model.TableStructure table)
        {
            IList<object> dbparams = new List<object>();

            string all = "";
            this.createIterationStrings(table);
            List<string> args = new List<string>();
            args.Add(base._Copyright);
            args.Add(base._Project._Name);
            args.Add(table._Name);
            args.Add(this._strIterations[0]._Returns.ToString());
            args.Add(table._PrimaryKeys.Count.ToString());

            all = string.Format(_fileTemplate, args.ToArray<string>());
            return all;
        }

        public Model.Project GenerateProject(
            Model.DBStructure dbStructure,
            Model.Namespace nSpace,
            Model.Copyright copyright,
            string parentDir)
        {
            #region
            if (base._Project == null)
                base._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._DBMapping
                };
            else
                this._Project._ReferenceNSpace.Clear();

            base._Copyright = copyright.ToString();

            string codedir = Path.Combine(
                parentDir, base._Project._Name);
            base._FileNameFormat = "{0}Mapping.cs";

            base.CheckDir(codedir);
            foreach (TableStructure table in dbStructure._Tables)
            {
                if (table._IsGen)
                {
                    string filename = string.Format(_FileNameFormat, table._Name);
                    base.SaveFile(codedir, filename, this.GetCode(table));
                }
            }
            return base._Project;
            #endregion        
        }

        public void GenerateCsproj(
            Model.DBStructure dbStructure, 
            List<Model.Project> allProjects, 
            string parentDir)
        {
            base.SaveCsproj(dbStructure, allProjects, parentDir);
            base.SaveAssembly(parentDir);
        }
    }
}
