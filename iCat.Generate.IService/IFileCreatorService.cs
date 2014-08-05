using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IService
{
    public interface IFileCreatorService
    {
        void Generate();

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
