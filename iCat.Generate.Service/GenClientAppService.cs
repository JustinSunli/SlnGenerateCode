using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenClientAppService : GenFileServiceBase, IFileCreatorService
    {

        public void Generate(
            TableStructure table)
        {
            throw new NotImplementedException();
        }

        public string GetCode(
            TableStructure table)
        {
            throw new NotImplementedException();
        }

        public Project GenerateProject(
            DBStructure dbStructure, 
            Namespace nSpace, 
            Copyright copyright, 
            string parentDir)
        {
            throw new NotImplementedException();
        }

        public void GenerateCsproj(
            DBStructure dbStructure, 
            List<Project> allProjects, 
            string parentDir)
        {
            throw new NotImplementedException();
        }
    }
}
