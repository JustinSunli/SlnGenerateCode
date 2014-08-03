using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileModelService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}
using System.Data;

namespace {2}
{{
    public class Entity{3} : IEntity
    {{
        {4}

        public void Get(DataRow dr)
        {{
            {5}
        }}
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
            this.createIterationStrings(table);
            List<string> args = new List<string>();
            args.Add(copyright.ToString());
            args.Add(getUsing(nSpace));
            args.Add(nSpace._Model);
            args.Add(table._Name);
            args.Add(getFields());
            args.Add(getAssign());
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
            usings.Add(nSpace._FoundationCore);
            return base.StrcatUsing(usings);
            #endregion
        }
        private List<StrIteration> _strIterations = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        private void createIterationStrings(
            TableStructure table)
        {
            #region
            _strIterations = new List<StrIteration>();
            _strIterations.Add(new StrIteration()
            {
                _Template = "this.{0} = dr[{1}Data.{0}].ToString();"
            });
            _strIterations.Add(new StrIteration()
            {
                _Template = @"/// <summary>
        /// {0}。
        /// </summary>
        public string {1} {{ get; set; }}"
            });

            DataRowCollection drs = table._Columns.Tables[0].Rows;
            for (int i = 0; i < drs.Count; i++)
            {
                foreach(StrIteration iter in _strIterations)
                {
                    string temp = string.Format(iter._Template,
                    drs[0][ColumnsData.name], table._Name);

                    if (i == drs.Count - 1)
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
        /// <returns></returns>
        private string getFields()
        {
            #region
            return _strIterations[1]._Returns.ToString();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getAssign()
        {
            #region
            return _strIterations[0]._Returns.ToString(); ;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void Generate()
        {
            throw new NotImplementedException();
        }
    }
    public class StrIteration
    {
        private string _template;

        public string _Template
        {
            get { return _template; }
            set { _template = value; }
        }

        private StringBuilder _returns;

        public StringBuilder _Returns
        {
            get { return _returns; }
            set { _returns = value; }
        }

        public StrIteration()
        {
            if (_returns == null)
                _returns = new StringBuilder();
        }
    }
}
