using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
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
            ref TUserData {4}Data,
            EntityTUser {4});
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetMaxId();
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
            List<string> args = new List<string>();
            args.Add(copyright.ToString());
            args.Add(getUsing(nSpace));
            args.Add(nSpace._IService);
            args.Add(table._Name);
            args.Add(table._ParamNamePrefix);
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
            usings.Add(nSpace._Model);

            return base.StrcatUsing(usings);
            #endregion
        }

        public void Generate()
        {
            throw new NotImplementedException();
        }



        public void GenerateProject(DBStructure dbStructure, Namespace nSpace, Copyright copyright, string parentDir)
        {
            throw new NotImplementedException();
        }
    }
}
