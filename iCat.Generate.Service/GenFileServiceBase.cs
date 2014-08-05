using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileServiceBase
    {
        public Project _Project { get; set; }
        public string _Usings { get; set; }
        public string _Copyright { get; set; }
        public string _FileNameFormat { get; set; }
        protected string StrcatUsing(
            IList<string> usings)
        {
            #region
            StringBuilder strusings = new StringBuilder();
            for (int i = 0; i < usings.Count; i++)
            {
                string temp = string.Format("using {0};",
                    usings[i]);
                if (i == usings.Count-1)
                    strusings.Append(temp);
                else
                    strusings.AppendLine(temp);
            }
            return strusings.ToString();
            #endregion

        }

        protected delegate object[] DLGetIterParams(
            CodeIneration iter,
            int colsRowIndex,
            TableStructure table);

        protected DLGetIterParams _dlGetIterParams;
        protected void AppendCodeInerationsByTable(
            TableStructure table, 
            List<CodeIneration> strIterations)
        {
            #region
            DataRowCollection drs = table._Columns.Tables[0].Rows;
            for (int i = 0; i < drs.Count; i++)
            {
                foreach (CodeIneration iter in strIterations)
                {
                    string temp = string.Format(iter._Template,
                    _dlGetIterParams(iter, i, table));

                    if (i == drs.Count - 1)
                        iter._Returns.Append(temp);
                    else
                        iter._Returns.AppendLine(temp);
                }
            }
            #endregion
        }
        protected void SaveFile(
            string codeDir, 
            string fileName, 
            string content)
        {
            #region
            string filepath = Path.Combine(codeDir, fileName);

            StreamWriter sw;
            if (!File.Exists(filepath))
                sw = File.CreateText(filepath);
            else
            {
                File.Delete(filepath);
                sw = File.CreateText(filepath);
            }
            sw.WriteLine(content);
            sw.WriteLine();
            sw.Dispose();
            #endregion
        }

        protected void CheckDir(
            string codeDir)
        {
            #region
            if (!Directory.Exists(codeDir))
                Directory.CreateDirectory(codeDir);
            #endregion
        }

        protected StringBuilder getCsprojFiles(
            DBStructure dbStructure)
        {
            #region
            StringBuilder files = new StringBuilder();
            for (int i = 0; i < dbStructure._Tables.Count; i++)
            {
                string tablename = dbStructure._Tables[i]._Name;
                string temp = string.Format(
                    string.Format(@"<Compile Include=""{0}"" />", _FileNameFormat),
                    tablename);

                if (i == dbStructure._Tables.Count - 1)
                    files.Append(temp);
                else
                    files.AppendLine(temp);
            }
            return files;
            #endregion
        }

        protected StringBuilder getCsprojRefers(
            List<Project> allProjects)
        {
            #region
            StringBuilder references = new StringBuilder();
            for (int m = 0; m < this._Project._ReferenceNSpace.Count; m++)
            {
                string nspace = this._Project._ReferenceNSpace[m];
                Project refproject = null;
                for (int n = 0; n < allProjects.Count; n++)
                {
                    if (nspace == allProjects[n]._Name)
                    {
                        refproject = allProjects[n];
                        break;
                    }
                }
                if (refproject != null)
                {
                    List<string> tempparams = new List<string>();
                    tempparams.Add(refproject._Name);
                    tempparams.Add(refproject._Name);
                    tempparams.Add(refproject._Guid.ToString());
                    tempparams.Add(refproject._Name);
                    string temp = string.Format(@"<ProjectReference Include=""..\{0}\{1}.csproj"">
          <Project>{{{2}}}</Project>
          <Name>{3}</Name>
        </ProjectReference>", tempparams.ToArray<string>());

                    if (m == this._Project._ReferenceNSpace.Count - 1)
                        references.Append(temp);
                    else
                        references.AppendLine(temp);
                }
            }
            return references;
            #endregion
        }

        protected string[] getCsprojParams(
            string files, string refers)
        {
            #region
            List<string> csprojparams = new List<string>();
            csprojparams.Add(_Project._Guid.ToString());
            csprojparams.Add(_Project._Name);
            csprojparams.Add(_Project._Name);
            csprojparams.Add(files);
            csprojparams.Add(refers);
            return csprojparams.ToArray<string>();
            #endregion
        }

        protected void SaveCsproj(
            DBStructure dbStructure,
            List<Project> allProjects,
            string parentDir)
        {
            #region
            StringBuilder files = this.getCsprojFiles(dbStructure);
            StringBuilder references = this.getCsprojRefers(allProjects);

            string codedir = Path.Combine(
                parentDir, this._Project._Name);

            this.SaveFile(codedir,
                string.Format("{0}.csproj", this._Project._Name),
                string.Format(Project._CsprojTemplate,
                this.getCsprojParams(files.ToString(), references.ToString())));
            #endregion
        }

        protected void SaveAssembly(
            string parentDir)
        {

            string codedir = Path.Combine(
                parentDir, this._Project._Name, "Properties");

            this.CheckDir(codedir);

            this.SaveFile(codedir, "AssemblyInfo.cs",
                string.Format(Project._AssemblyTemplate, this._Project._Name, this._Project._Name, Guid.NewGuid()));
        }
    }
}
