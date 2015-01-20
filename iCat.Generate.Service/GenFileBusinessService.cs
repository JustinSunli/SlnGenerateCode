using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileBusinessService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}

namespace {2}
{{
    class {3}Business : AbstractBusiness
    {{
        private I{3}Service _{4}Service
            = (I{3}Service)SpringManager.GetObject(SpringKeys.{3}Service);

        public {3}Business(
            string logonUserId, string logonUserIp) 
            : base(logonUserId, logonUserIp)
        {{ }}
        public {3}Business(
            string logonUserId) 
            : base(logonUserId)
        {{ }}
        /// <summary>
        /// 根据关键字获取实体对象
        /// </summary>{7}
        /// <returns>实体</returns>
        Entity{3} GetEntity(
            {5})
        {{
            #region
            Entity{3} entitykeys =
                new Entity{3}()
                {{{6}
                }};

            {3}Data ds = 
                this._{4}Service.Get{3}ByKeys(entitykeys);

            return ds.GetEntity<Entity{3}>(0);
            #endregion
        }}
    }}
}}";
        private void getStrByKeys(
            TableStructure table,
            ref string fnParams,
            ref string keysAssign,
            ref string summary)
        {
            #region
            fnParams = "";
            keysAssign = "";
            summary = "";
            string fnParamsformat = "string {0},";
            string keysAssignformat = @"
                    {0} = {0},";
            string summaryformat = @"
        /// <param name=""{0}""></param>";
            foreach (string key in table._PrimaryKeys)
            {
                fnParams += string.Format(fnParamsformat, key);
                keysAssign += string.Format(keysAssignformat, key);
                summary += string.Format(summaryformat, key);
            }
            if (table._PrimaryKeys.Count > 0)
            {
                fnParams = fnParams.Remove(fnParams.Length - 1, 1);
                keysAssign = keysAssign.Remove(keysAssign.Length - 1, 1);
            }
            #endregion
        }
        //4为首字母小写的表名，3为原始表名，
        public string GetCode(
            TableStructure table)
        {
            #region
            string all = "";
            string fnparams = "", keysassign = "", summary = "";
            this.getStrByKeys(table, 
                ref fnparams, ref keysassign, 
                ref summary);

            List<string> args = new List<string>();
            args.Add(base._Copyright);
            args.Add(base._Usings);
            args.Add(base._Project._Name);
            args.Add(table._Name);
            args.Add(table._ParamNamePrefix);
            args.Add(fnparams);
            args.Add(keysassign);
            args.Add(summary);
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
            usings.Add(nSpace._CustomSpring.ToString());
            usings.Add(nSpace._Model);
            usings.Add(nSpace._IService);
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
            {
                this._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._WCFName.ToString()
                };
                this._Project._FolderName = nSpace._Business;
            }
            else
                this._Project._ReferenceNSpace.Clear();

            base._Usings = getUsing(nSpace);
            base._Copyright = copyright.ToString();

            string codedir = Path.Combine(
                parentDir, this._Project._FolderName);

            base.CheckDir(codedir);

            _FileNameFormat = "{0}Business.cs";

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
