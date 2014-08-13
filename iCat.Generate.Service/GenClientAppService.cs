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
            
            this.createIterationStrings(table);
            return null;
        }

        private string _diDao = "";
        private string _diService = "";
        private string _sprintKeys = "";
        private Namespace _nSpace = null;

        public Project GenerateProject(
            DBStructure dbStructure, 
            Namespace nSpace, 
            Copyright copyright, 
            string parentDir)
        {
            if (base._Project == null)
                base._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._App
                };
            else
                this._Project._ReferenceNSpace.Clear();

            string codedir = Path.Combine(
                parentDir, this._Project._Name);

            this._nSpace = nSpace;
            base.CheckDir(codedir);
            foreach (TableStructure table in dbStructure._Tables)
            {
                if (table._IsGen)
                {
                    this.GetCode(table);
                    _diDao += _strIterations[0]._Returns.ToString();
                    _diService += _strIterations[1]._Returns.ToString();
                    this._sprintKeys += _strIterations[2]._Returns.ToString();
                }
            }

            return base._Project;
        }

        public void GenerateCsproj(
            DBStructure dbStructure, 
            List<Project> allProjects, 
            string parentDir)
        {
            string codedir = Path.Combine(
                parentDir, this._Project._Name);
            //base.SaveCsproj(dbStructure, allProjects, parentDir);
            this.saveAppConfig(codedir);
            this.saveDiConfig(codedir);
            this.saveDBConfig(dbStructure._Connection, codedir);
            this.saveSpringKeys(codedir);
        }

        private void saveDiConfig( 
            string parentDir)
        {
            string diconfig = string.Format(
                SpringConfig.DITemplate,
                _diDao,
                _diService);
            base.SaveFile(parentDir, "DIConfig.xml", diconfig);
        }
        private void saveSpringKeys(
            string parentDir)
        {
            string springkeys = string.Format(
                SpringConfig.SpringKeysTemplate,
                this._Project._Name,
                this._sprintKeys);
            base.SaveFile(parentDir, "SpringKeys.cs", springkeys);
        }
        private void saveDBConfig(
            Connection connection,
            string parentDir)
        {
            string dbconfig = string.Format(
                SpringConfig.DBTemplate,
                _nSpace._Prefix,
                connection.connectionString);
            base.SaveFile(parentDir, "DBConfig.xml", dbconfig);
        }

        private void saveAppConfig(string parentDir)
        {
            base.SaveFile(parentDir, "App.Config", SpringConfig.AppconfigTemplate);
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
                _Template = @"<object id=""{0}Dao"" type=""{1}.Dao.{2}Dao, {1}.Dao"">
    <property name=""AdoTemplate"" ref=""adoTemplate""/>
  </object>",
                _IterType = EnumStrIteration.SpringDIDao
            });
            _strIterations.Add(new CodeIneration()
            {
                _Template = @"<object id=""{0}Service"" type=""{1}.Service.{2}Service, {1}.Service"">
    <property name=""_{2}Dao"" ref=""{0}Dao""/>
  </object>",
                _IterType = EnumStrIteration.SpringDIService
            });
            _strIterations.Add(new CodeIneration()
            {
                _Template = "\t\tpublic const string {0}Service = \"{1}Service\";",
                _IterType = EnumStrIteration.SpringKeys
            });
            base._dlGetIterParams = new DLGetIterParams(getIterParams);
            this.AppendCodeInerations(table, _strIterations);
            #endregion
        }
        private void AppendCodeInerations(
    TableStructure table,
    List<CodeIneration> strIterations)
        {
            #region

            foreach (CodeIneration iter in strIterations)
            {
                string temp = string.Format(iter._Template,
                _dlGetIterParams(iter, 0, table));

                iter._Returns.AppendLine(temp);
            }
            #endregion
        }

        private object[] getIterParams(
            CodeIneration iter,
            int colsRowIndex,
            TableStructure table)
        {
            #region
            IList<object> iterparams = new List<object>();
            switch (iter._IterType)
            {
                case EnumStrIteration.SpringDIDao:
                    {
                        iterparams.Add(table._ParamNamePrefix);
                        iterparams.Add(this._nSpace._Prefix);
                        iterparams.Add(table._Name);
                        break;
                    }
                case EnumStrIteration.SpringDIService:
                    {
                        iterparams.Add(table._ParamNamePrefix);
                        iterparams.Add(this._nSpace._Prefix);
                        iterparams.Add(table._Name);
                        break;
                    }
                case EnumStrIteration.SpringKeys:
                    {
                        iterparams.Add(table._Name);
                        iterparams.Add(table._ParamNamePrefix);
                        break;
                    }
            }
            return iterparams.ToArray<object>();
            #endregion
        }

    }
}
