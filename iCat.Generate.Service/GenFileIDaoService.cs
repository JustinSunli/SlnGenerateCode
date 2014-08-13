using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileIDaoService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}

namespace {2}
{{
    public interface I{3}Dao
    {{
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name=""{4}Data"">欲保存的数据集</param>
        void Save({3}Data {4}Data);
        {5}
        /// <summary>
        /// 检索单表
        /// </summary>
        /// <param name=""condition"">查询条件</param>
        /// <returns>{3}的数据集</returns>
        {3}Data SelectSingleT(QueryCondition condition); 
    }}
}}";
        //4为首字母小写的表名，3为原始表名，
        public string GetCode(
            TableStructure table)
        {
            #region
            string all = "";
            List<string> args = new List<string>();
            args.Add(base._Copyright);
            args.Add(base._Usings);
            args.Add(base._Project._Name);
            args.Add(table._Name);
            args.Add(table._ParamNamePrefix);
            args.Add(getMaxidCode(table._HasIntPrimaryKey));
            all = string.Format(_fileTemplate, args.ToArray<string>());
            return all;
            #endregion
        }

        private string getMaxidCode(
            bool hasIntKey)
        {
            #region
            string temp = @"/// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns>最大编号</returns>
        int GetMaxId();";
            temp = (hasIntKey) ? temp : "";
            return temp;
            #endregion
        }

        private string getUsing(
            Namespace nSpace)
        {
            #region
            IList<string> usings = new List<string>();
            usings.Add(nSpace._FoundationCore.ToString());
            usings.Add(nSpace._Model);
            this._Project._ReferenceNSpace = usings;
            return base.StrcatUsing(usings);
            #endregion
        }

        public void Generate(TableStructure table)
        {
            throw new NotImplementedException();
        }


        public Project GenerateProject(
            DBStructure dbStructure, 
            Namespace nSpace, 
            Copyright copyright, 
            string parentDir)
        {
            #region
            if (this._Project == null)
                this._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._IDao
                };
            else
                this._Project._ReferenceNSpace.Clear();

            base._Usings = getUsing(nSpace);
            base._Copyright = copyright.ToString();

            string codedir = Path.Combine(
                parentDir, this._Project._Name);

            base.CheckDir(codedir);

            _FileNameFormat = "I{0}Dao.cs";

            foreach (TableStructure table in dbStructure._Tables)
            {
                if (table._IsGen)
                {
                    string filename = string.Format(_FileNameFormat, table._Name);
                    base.SaveFile(codedir, filename, this.GetCode(table));
                }
            }
            return this._Project;

            #endregion
        }


        public void GenerateCsproj(
            DBStructure dbStructure, 
            List<Project> allProjects, 
            string parentDir)
        {
            base.SaveCsproj(dbStructure, allProjects, parentDir);
            base.SaveAssembly(parentDir);

        }
    }
}
