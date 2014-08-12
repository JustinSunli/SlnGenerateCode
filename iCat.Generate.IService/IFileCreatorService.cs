using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IService
{
    public interface IFileCreatorService
    {
        /// <summary>
        /// 生成单页文件
        /// </summary>
        void Generate(
            TableStructure table);

        /// <summary>
        /// 根据表获取单页文件
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        string GetCode(
            TableStructure table);

        Project GenerateProject(DBStructure dbStructure,
            Namespace nSpace,
            Copyright copyright,
            string parentDir);

        void GenerateCsproj(
            DBStructure dbStructure,
            List<Project> allProjects,
            string parentDir);
    }
}
