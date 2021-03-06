﻿using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileIServiceService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}
using System;
using System.Collections.Generic;

namespace {2}
{{
    public interface I{3}Service
    {{
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}""></param>
        void Add(
            ref {3}Data {4}Data,
            Entity{3} {4});
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}s""></param>
        void Add(
           ref {3}Data {4}Data,
           IList<Entity{3}> {4}s);
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}""></param>
        /// <returns></returns>
        {3}Data Add(
            Entity{3} {4});
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}s""></param>
        /// <returns></returns>
        {3}Data Add(
            IList<Entity{3}> {4}s);
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}""></param>
        void Edit(
            ref {3}Data {4}Data,
            Entity{3} {4});
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}Data""></param>
        /// <param name=""{4}""></param>
        void Delete(
            ref {3}Data {4}Data,
            Entity{3} {4});

        {5}
        /// <summary>
        /// 根据实体的关键字从数据库中查询符合条件的数据
        /// </summary>
        /// <param name=""{4}""></param>
        /// <returns>符合条件的数据</returns>
        {3}Data Get{3}ByKeys(
            Entity{3} {4});
        /// <summary>
        /// 获取全部数据（表数据量大时慎用）
        /// </summary>
        /// <returns>表全部数据</returns>
        {3}Data GetAll();
        /// <summary>
        /// 根据实体的指定属性从数据库中查询符合条件的数据（条件只=）
        /// </summary>
        /// <returns>符合条件的数据</returns>
        {3}Data GetData(
            Entity{3} {4});
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
        /// 
        /// </summary>
        /// <returns></returns>
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
            usings.Add(nSpace._Model);
            base._Project._ReferenceNSpace = usings;
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
            {
                this._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._IService
                };
            }
            else
                this._Project._ReferenceNSpace.Clear();

            base._Usings = getUsing(nSpace);
            base._Copyright = copyright.ToString();

            string codedir = Path.Combine(
                parentDir, this._Project._Name);

            base.CheckDir(codedir);
            base._FileNameFormat = "I{0}Service.cs";
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
