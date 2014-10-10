using iCat.Generate.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    class GenFileDBMappingService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace {0}
{{
    public class {1}Mapping
    {{
{2}
        /// <summary>
        /// 表名。
        /// </summary>
        public const string {1} = ""{1}"";
    }}
}}";

        public void Generate(
            Model.TableStructure table)
        {
            throw new NotImplementedException();
        }

        public string GetCode(
            Model.TableStructure table)
        {
            throw new NotImplementedException();
        }

        public Model.Project GenerateProject(
            Model.DBStructure dbStructure, 
            Model.Namespace nSpace, 
            Model.Copyright copyright, 
            string parentDir)
        {
            throw new NotImplementedException();
        }

        public void GenerateCsproj(
            Model.DBStructure dbStructure, 
            List<Model.Project> allProjects, 
            string parentDir)
        {
            throw new NotImplementedException();
        }
    }
}
