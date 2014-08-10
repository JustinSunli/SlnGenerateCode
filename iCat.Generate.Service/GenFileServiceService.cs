using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileServiceService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}
using System;
using System.Collections.Generic;

namespace {2}
{{
    class {3}Service : I{3}Service
    {{
        public I{3}Dao _{3}Dao {{ get; set; }}

        #region 添加操作
        /// <summary>
        /// 添加[{4}]数据到数据库（有源、单实体）。
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}""></param>
        public void Add(
            ref {3}Data {4}Data,
            Entity{3} {4})
        {{
            #region
            {4}Data.AddCache({4});
            _{3}Dao.Save({4}Data);
            #endregion
        }}
        /// <summary>
        /// 添加[{4}]数据到数据库（有源、多实体）。
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}s""></param>
        public void Add(
            ref {4}Data {4}Data,
            IList<Entity{3}> {4}s)
        {{
            #region
            {4}Data.AddCache({4}s);
            _{3}Dao.Save({4}Data);
            #endregion
        }}
        /// <summary>
        /// 添加[{4}]数据到数据库（无源、单实体）。
        /// </summary>
        /// <param name=""{4}""></param>
        /// <returns></returns>
        public TUserData Add(
            Entity{3} {4})
        {{
            #region
            {3}Data {5}data = new {3}Data();
            this.Add(ref {5}data, {4});
            return {5}data;
            #endregion
        }}
        /// <summary>
        /// 添加[{4}]数据到数据库（无源、多实体）。
        /// </summary>
        /// <param name=""{4}s""></param>
        /// <returns></returns>
        public {3}Data Add(
            IList<Entity{3}> {4}s)
        {{
            #region
            {3}Data {5}data = new {3}Data();
            this.Add(ref {5}data, {4}s);
            return {5}data;
            #endregion
        }}
        #endregion

        #region 编辑操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}""></param>
        public void Edit(
            ref {3}Data {4}Data,
            Entity{3} {4})
        {{
            #region
            {4}Data.EditCache({4});
            _{3}Dao.Save({3}Data);
            #endregion
        }}
        #endregion

        #region 删除操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}""></param>
        public void Delete(
            ref {3}Data {4}Data,
            Entity{3} {4})
        {{
            #region
            {4}Data.DeleteCache({4});
            _{3}Dao.Save({4}Data);
            #endregion
        }}
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {{
            #region
            return _{3}Dao.GetMaxId();
            #endregion
        }}
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
            args.Add(table._NameLower);
            all = string.Format(_fileTemplate, args.ToArray<string>());
            return all;
            #endregion
        }

        private string getUsing(
            Namespace nSpace)
        {
            #region
            IList<string> usings = new List<string>();
            usings.Add(nSpace._IDao);
            usings.Add(nSpace._IService);
            usings.Add(nSpace._Model);
            base._Project._ReferenceNSpace = usings;
            return base.StrcatUsing(usings);
            #endregion
        }

        public void Generate()
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
            if (base._Project == null)
                base._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._Service
                };
            else
                this._Project._ReferenceNSpace.Clear();

            base._Usings = getUsing(nSpace);
            base._Copyright = copyright.ToString();

            string codedir = Path.Combine(
                parentDir, base._Project._Name);

            base.CheckDir(codedir);
            base._FileNameFormat = "{0}Service.cs";
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
            DBStructure dbStructure, 
            List<Project> allProjects, 
            string parentDir)
        {
            base.SaveCsproj(dbStructure, allProjects, parentDir);
            base.SaveAssembly(parentDir);

        }
    }
}
