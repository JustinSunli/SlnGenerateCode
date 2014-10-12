using iCat.Generate.IDao;
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
    public class GenSlnService : GenFileServiceBase, ISlnCreatorService
    {
        private const string _slnTemplate = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 2013
VisualStudioVersion = 12.0.21005.1
MinimumVisualStudioVersion = 10.0.40219.1
{0}
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{1}
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal";
        //public DBStructure _DBStructure { get; set; }
        //public Copyright _Copyright { get; set; }
        //public Namespace _NameSpace { get; set; }

        private IList<IFileCreatorService> _fileServices;
        private Guid _slnGuid;
        private void initCache()
        {
            #region
            if(this._projects != null)
                this._projects.Clear();
            if (this._strIterations != null)
                this._strIterations.Clear();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void Generate(
            Copyright _copyright,
            Namespace _nameSpace, 
            DBStructure _dbStructure, 
            string dir)
        {
            #region
            this.initCache();
            //this.fillTablesIsGen(_dbStructure, _selTables);
            string slnpath = Path.Combine(dir, _nameSpace._Prefix.ToString());
            foreach (IFileCreatorService fileservice
                in _fileServices)
            {
                Project proj = fileservice.GenerateProject(
                    _dbStructure,
                    _nameSpace,
                    _copyright, slnpath);

                _projects.Add(proj);
            }
            
            _slnGuid = Guid.NewGuid();

            this.createIterationStrings();

            base.SaveFile(slnpath,
                string.Format("{0}.sln", _nameSpace._Prefix),
                string.Format(_slnTemplate, 
                _strIterations[0]._Returns, 
                _strIterations[1]._Returns));

            foreach (IFileCreatorService fileservice
                in _fileServices)
            {
                fileservice.GenerateCsproj(
                    _dbStructure,
                    _projects,
                    slnpath);
            }

            #endregion
        }
        private List<CodeIneration> _strIterations = null;
        private List<Project> _projects = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        private void createIterationStrings()
        {
            #region
            _strIterations = new List<CodeIneration>();
            _strIterations.Add(new CodeIneration()
            {
                _Template = @"Project(""{{{0}}}"") = ""{1}"", ""{2}\{3}.csproj"", ""{{{4}}}""
EndProject",
                _IterType = EnumStrIteration.SlnProjects
            });
            _strIterations.Add(new CodeIneration()
            {
                _Template = @"{{{0}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{0}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{0}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{0}}}.Release|Any CPU.Build.0 = Release|Any CPU",
                _IterType = EnumStrIteration.SlnCompiles
            });
            Console.WriteLine("_projects.Count = {0}", _projects.Count);
            Console.WriteLine("_strIterations.Count = {0}", _strIterations.Count);
            for (int i = 0; i < _projects.Count; i++)
            {
                foreach (CodeIneration iter in _strIterations)
                {
                    string temp = string.Format(iter._Template,
                    getIterParams(iter, i));

                    if (i == _projects.Count - 1)
                        iter._Returns.Append(temp);
                    else
                        iter._Returns.AppendLine(temp);
                }
            }

            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iter"></param>
        /// <param name="colsRowIndex"></param>
        /// <returns></returns>
        private object[] getIterParams(
            CodeIneration iter,
            int colsRowIndex)
        {
            #region
            IList<object> iterparams = new List<object>();
            Project project = _projects[colsRowIndex];
            switch (iter._IterType)
            {
                case EnumStrIteration.SlnProjects:
                    {
                        iterparams.Add(this._slnGuid);
                        iterparams.Add(project._AssemblyName);
                        iterparams.Add(project._FolderName);
                        iterparams.Add(project._Name);
                        iterparams.Add(project._Guid);
                        break;
                    }
                case EnumStrIteration.SlnCompiles:
                    {
                        iterparams.Add(project._Guid);
                        break;
                    }
            }
            return iterparams.ToArray<object>();
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public void initFileServices()
        {
            #region
            if (_fileServices == null)
            {
                _fileServices =
                    new List<IFileCreatorService>();

                _fileServices.Add(new GenFileDaoService());
                _fileServices.Add(new GenFileDBMappingService());
                _fileServices.Add(new GenFileIDaoService());
                _fileServices.Add(new GenFileIServiceService());
                _fileServices.Add(new GenFileModelService());
                _fileServices.Add(new GenFileServiceService());
                _fileServices.Add(new GenClientAppService());

                if (_fileServices != null)
                    _projects = new List<Project>();
            }
            #endregion
        }


        public GenSlnService()
        { 
            initFileServices(); 
        }

        public void Generate()
        {
            throw new NotImplementedException();
        }
    }
}
