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
    public class GenFileModelService : GenFileServiceBase, IFileCreatorService
    {
        #region
        private const string _fileTemplate = @"
{0}
{1}
using System.Data;
using System;

namespace {2}
{{
    public class Entity{3} : IEntity
    {{
{4}
        /// <summary>
        /// 从数据集中根据主键获取实体时（接口方法）
        /// </summary>
        /// <param name=""dr""></param>
        public void Get(DataRow dr)
        {{
{5}
        }}
    }}
}}";
        //4为首字母小写的表名，3为原始表名，
        public string GetCode(
            TableStructure table)
        {
            #region
            string all = "";
            this.createIterationStrings(table);
            List<string> args = new List<string>();
            args.Add(base._Copyright);
            args.Add(base._Usings);
            args.Add(base._Project._Name);
            args.Add(table._Name);
            args.Add(getFields());
            args.Add(getAssign());
            all = string.Format(_fileTemplate, args.ToArray<string>());
            return all;
            #endregion
        }

        private string getUsing(
            Namespace nSpace)
        {
            #region
            IList<string> usings = new List<string>();
            usings.Add(nSpace._FoundationCore.ToString());
            usings.Add(nSpace._DBMapping);
            base._Project._ReferenceNSpace = usings;
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
                _Template = "\t\t\tthis.{0} = dr[{1}Mapping.{0}].ToString();",
                _IterType = EnumStrIteration.EntityAssigns
            });
            _strIterations.Add(new CodeIneration()
            {
                _Template = "\t\t/// <summary>\r\n" +
                            "\t\t/// {0}。\r\n" +
                            "\t\t/// </summary>\r\n" +
                            "\t\tpublic {2} {1} {{ get; set; }}",
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
            string entityfieldtypename = XType.getEntityFieldTypeName(
                dr[ColumnsData.xtype].ToString());
            switch (iter._IterType)
            {
                case EnumStrIteration.EntityAssigns:
                    {
                        if (entityfieldtypename.Equals("Byte[]"))
                            iter._Template = @"
            if (dr[{1}Mapping.{0}]!=System.DBNull.Value)
                this.{0} = dr[{1}Mapping.{0}].ToString();";
                        else
                            iter._Template = "\t\t\tthis.{0} = dr[{1}Mapping.{0}].ToString();";
                        iterparams.Add(dr[ColumnsData.name]);
                        iterparams.Add(table._Name);
                        break;
                    }
                case EnumStrIteration.EntityFields:
                    {
                        iterparams.Add(dr[ColumnsData.value]);
                        iterparams.Add(dr[ColumnsData.name]);
                        iterparams.Add(entityfieldtypename);
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
        public void Generate(TableStructure table)
        {
            throw new NotImplementedException();
        }
        #endregion


        public Project GenerateProject(
            DBStructure dbStructure, 
            Namespace nSpace, 
            Copyright copyright, 
            string parentDir)
        {
            #region
            if (base._Project == null)
                base._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._Model
                };
            else
                this._Project._ReferenceNSpace.Clear();

            base._Usings = getUsing(nSpace);
            base._Copyright = copyright.ToString();
            
            string codedir = Path.Combine(
                parentDir, base._Project._Name, "entity");

            base.CheckDir(codedir);
            base._FileNameFormat = "Entity{0}.cs";
            foreach (TableStructure table in dbStructure._Tables)
            {
                if (table._IsGen)
                {
                    string filename = string.Format(_FileNameFormat, table._Name);
                    base.SaveFile(codedir, filename, this.GetCode(table));
                }
            }

            _modelDataService = new GenFileModelDataService();
            _modelDataService.GenerateProject(dbStructure, nSpace, copyright, parentDir);

            return base._Project;
            #endregion
        }

        private GenFileModelDataService _modelDataService = null;
        public void GenerateCsproj(
            DBStructure dbStructure, 
            List<Project> allProjects, 
            string parentDir)
        {
            base._FileNameFormat = "entity\\{0}Data.cs";
            base.SaveCsproj(dbStructure, allProjects, parentDir);
            _modelDataService.GenerateCsproj(dbStructure, allProjects, parentDir);
            base.SaveAssembly(parentDir);

        }
    }
}
