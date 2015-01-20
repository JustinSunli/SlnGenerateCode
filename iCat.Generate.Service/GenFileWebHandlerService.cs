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
    public class GenFileWebHandlerService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace {2}
{{
    public class {3} : PageHandlerBase, IHttpHandler
    {{
        private Entity{3} _{4} = new Entity{3}();
        private {3}Client _{4}Client = new {3}Client();

        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name=""request""></param>
        private void getPostParams(
            HttpRequest request)
        {{
            #region
            NameValueCollection paramsarray = request.Params;
{5}
            #endregion
        }}
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name=""json""></param>
        private void ActionList(
            ref string json)
        {{
            #region
            GridParamsByPage p = base.GetPageParams();
            //json = this._{4}Client.Get{3}ByPage(
            //    this.SessionUserId, this.SessionUserIp, 
            //    p.PageIndex, p.PageSize, this._{4});
            #endregion
        }}
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name=""json""></param>
        private void ActionGetAll(
            ref string json)
        {{
            #region
            //json = this._{4}Client.GetJsonByAll();
            #endregion
        }}
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name=""json""></param>
        private void ActionAddNew(
            ref string json)
        {{
            #region
            //json = this._{4}Client.Add{3}(
            //  this.SessionUserId, this.SessionUserIp, 
            //  imapplyforgroup);
            #endregion
        }}
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name=""json""></param>
        private void ActionEdit(
            ref string json)
        {{
            #region
            #endregion
        }}
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name=""json""></param>
        private void ActionDelete(
            ref string json)
        {{
            #region
            #endregion
        }}

        /// <summary>
        /// 处理请求的过程，当前台页面调用本文件时，自动执行本方法。
        /// </summary>
        /// <param name=""context"">上下文</param>
        public void ProcessRequest(
            HttpContext context)
        {{
            #region
            HttpRequest request = context.Request;
            String action = request.QueryString[""action""];
            String json = """";

            this.getPostParams(request);

            switch (action)
            {{
                case ""list"":
                    this.ActionList(ref json);
                    break;
                case ""viewall"":
                    this.ActionGetAll(ref json);
                    break;
                case ""add"":
                    this.ActionAddNew(ref json);
                    break;
                case ""update"":
                    this.ActionEdit(ref json);
                    break;
                case ""delete"":
                    this.ActionDelete(ref json);
                    break;
                default:
                    break;
            }}
            context.Response.ContentType = ""text/json"";
            context.Response.Write(json);
            #endregion
        }}

        public bool IsReusable
        {{
            #region
            get
            {{
                return false;
            }}
            #endregion
        }}
    }}
}}";
        //4为首字母小写的表名，3为原始表名，
        public string GetCode(
            TableStructure table)
        {
            #region
            string all = "";
            this.createIterationStrings(table);
            List<string> args = new List<string>();
            args.Add(base._Copyright);
            args.Add(base._Usings);
            args.Add(base._Project._Name);
            args.Add(table._Name);
            args.Add(table._ParamNamePrefix);
            args.Add(this._strIterations[0]._Returns.ToString());
            all = string.Format(_fileTemplate, args.ToArray<string>());
            return all;
            #endregion
        }
        private List<CodeIneration> _strIterations = null;
        private void createIterationStrings(
    TableStructure table)
        {
            #region
            _strIterations = new List<CodeIneration>();
            _strIterations.Add(new CodeIneration()
            {
                _Template = "\t\t\tthis._{0}.{2} = paramsarray[{1}Mapping.{2}];",
                _IterType = EnumStrIteration.AshxAssign
            });
            base._dlGetIterParams = new DLGetIterParams(getIterParams);
            base.AppendCodeInerationsByTable(table, _strIterations);
            #endregion
        }
        private object[] getIterParams(
            CodeIneration iter,
            int colsRowIndex,
            TableStructure table)
        {
            #region
            IList<object> iterparams = new List<object>();
            DataRow dr = table._Columns.Tables[0].Rows[colsRowIndex];
            switch (iter._IterType)
            {
                case EnumStrIteration.AshxAssign:
                    {
                        iterparams.Add(table._ParamNamePrefix);
                        iterparams.Add(table._Name);
                        iterparams.Add(dr[ColumnsData.name]);
                        break;
                    }
            }
            return iterparams.ToArray<object>();
            #endregion
        }

        private string getUsing(
            Namespace nSpace)
        {
            #region
            IList<string> usings = new List<string>();
            usings.Add(nSpace._DBMapping);
            usings.Add(nSpace._App + ".WCFService");
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
                this._Project = new Project()
                {
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._App
                };
            else
                this._Project._ReferenceNSpace.Clear();

            base._Usings = getUsing(nSpace);
            base._Copyright = copyright.ToString();

            string codedir = Path.Combine(
                parentDir, this._Project._Name, "handler");

            base.CheckDir(codedir);

            _FileNameFormat = "{0}.ashx.cs";

            foreach (TableStructure table in dbStructure._Tables)
            {
                if (table._IsGen)
                {
                    string filename = string.Format(_FileNameFormat, table._Name);
                    string ashxfilename = string.Format("{0}.ashx", table._Name);
                    base.SaveFile(codedir, filename, this.GetCode(table));
                    base.SaveFile(codedir, ashxfilename, this.GetAshxCode(table));
                }
            }
            return this._Project;

            #endregion
        }

        private string GetAshxCode(
            TableStructure table)
        {
            #region
            string format = @"<%@ WebHandler Language=""C#"" CodeBehind=""{0}.ashx.cs"" Class=""{1}.{0}"" %>";
            return string.Format(format, table._Name, this._Project._Name);
            #endregion
        }


        public void GenerateCsproj(
            DBStructure dbStructure, 
            List<Project> allProjects, 
            string parentDir)
        {
            //base.SaveCsproj(dbStructure, allProjects, parentDir);
            //base.SaveAssembly(parentDir);

        }
    }
}
