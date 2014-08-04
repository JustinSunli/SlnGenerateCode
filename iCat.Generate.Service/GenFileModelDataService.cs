﻿using Foundation.Core;
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
    public class GenFileModelDataService : GenFileServiceBase, IFileCreatorService
    {
        #region
        private const string _fileTemplate = @"
{0}
{1}
using System;
using System.Collections.Generic;
using System.Data;

namespace {2}
{{
    public class {3}Data : DataLibBase
    {{
        #region table structure
{6}
        /// <summary>
        /// 表名。
        /// </summary>
        public const string {3} = ""{3}"";
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public {3}Data()
        {{
            this.buildData();
        }}
        private void buildData()
        {{
            #region
            DataTable dt = new DataTable({3});
{7}
            dt.PrimaryKey = new DataColumn[{9}] {{ dt.Columns[uid] }};
            dt.TableName = {3};
            this.Tables.Add(dt);
            this.DataSetName = ""T{3}"";
            #endregion
        }}
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""currentRow""></param>
        /// <param name=""{4}""></param>
        private void assignAll(
            DataRow currentRow, Entity{3} {4})
        {{
            #region
{8}
            #endregion
        }}
        /// <summary>
        /// 接口：添加实体到缓存
        /// </summary>
        /// <param name=""{4}""></param>
        public void AddCache(
            Entity{3} {4})
        {{
            #region
            base.checkIsNull(() => {{ 
                this.buildData();
            }});
                
            DataRow dr = this.Tables[0].NewRow();
            assignAll(dr, {4});
            this.Tables[0].Rows.Add(dr);
            #endregion
        }}
        /// <summary>
        /// 接口：添加多实体到缓存
        /// </summary>
        /// <param name=""{4}s""></param>
        public void AddCache(
            IList<Entity{3}> {4}s)
        {{
            #region
            foreach (Entity{3} {5} in {4}s)
                this.AddCache({5});
            #endregion
        }}
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}""></param>
        public void EditCache(
            Entity{3} {4})
        {{
            #region
            base.checkIsNotNull(() => {{ 
                DataRow dr = findRow({4});

                if (dr != null)
                    this.assignAll(dr, {4});
                else
                    Console.WriteLine(""{3}Data Cache hasn't {4}！"");
            }});
            #endregion
        }}
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}""></param>
        public void DeleteCache(
            Entity{3} {4})
        {{
            #region
            base.checkIsNotNull(() =>
            {{
                DataRow dr = findRow({4});

                if (dr != null)
                    dr.Delete();
                else
                    Console.WriteLine(""{3}Data Cache hasn't {4}！"");
            }});
            #endregion
        }}
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}""></param>
        /// <returns></returns>
        private DataRow findRow(
            Entity{3} {4})
        {{
            #region
            return this.Tables[0].Rows.Find(
                this.getPrimaryParams({4}));
            #endregion
        }}
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{4}""></param>
        /// <returns></returns>
        private object[] getPrimaryParams(
            Entity{3} {4})
        {{
            #region
            object[] dbparams = new object[{9}];
            dbparams[0] = {4}.uid;
            return dbparams;
            #endregion
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
            args.Add(table._ParamNamePrefix);
            args.Add(table._NameLower);
            args.Add(this.getFields());
            args.Add(this.getColumnsAdd());
            args.Add(this.getAssigns());
            args.Add(table._Columns
                .Tables[0].PrimaryKey
                .Length.ToString());

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
                _Template = "\t\tdt.Columns.Add({0}, typeof(System.{1}));",
                _IterType = EnumStrIteration.DataColumnsAdd
            });
            _strIterations.Add(new CodeIneration()
            {
                _Template = "\t\tthis.Assign(currentRow, {0}, {1}.{0});",
                _IterType = EnumStrIteration.DataAssigns
            });
            _strIterations.Add(new CodeIneration()
            {
                _Template = "\t/// <summary>\r\n"+
                            "\t/// {0}。\r\n"+
                            "\t/// </summary>\r\n"+
                            "\tpublic const string {1} = \"{1}\";",
                _IterType = EnumStrIteration.DataFields
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
                case EnumStrIteration.DataColumnsAdd:
                    {
                        iterparams.Add(dr[ColumnsData.name]);
                        iterparams.Add(
                            XType.getCSharpTypeName(
                            dr[ColumnsData.xtype].ToString()));
                        break;
                    }
                case EnumStrIteration.DataAssigns:
                    {
                        iterparams.Add(dr[ColumnsData.name]);
                        iterparams.Add(table._ParamNamePrefix);
                        break;
                    }
                case EnumStrIteration.DataFields:
                    {
                        iterparams.Add(dr[ColumnsData.value]);
                        iterparams.Add(dr[ColumnsData.name]);
                        break;
                    }
            }
            return iterparams.ToArray<object>();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getColumnsAdd()
        {
            #region
            return _strIterations[0]._Returns.ToString();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getAssigns()
        {
            #region
            return _strIterations[1]._Returns.ToString(); ;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getFields()
        {
            #region
            return _strIterations[2]._Returns.ToString(); ;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void Generate()
        {
            throw new NotImplementedException();

        }
        public void GenerateProject(
            DBStructure dbStructure,
            Namespace nSpace,
            Copyright copyright,
            string parentDir)
        {
            string codedir = Path.Combine(parentDir, nSpace._Model, "entity");
            string filepath = "";
            if (!Directory.Exists(codedir))
                Directory.CreateDirectory(codedir);
            foreach (TableStructure table in dbStructure._Tables)
            {
                filepath = Path.Combine(codedir, string.Format("Entity{0}.cs", table._Name));

                StreamWriter sw;
                if (!File.Exists(filepath))
                    sw = File.CreateText(filepath);
                else
                {
                    File.Delete(filepath);
                    sw = File.CreateText(filepath);
                }
                sw.WriteLine(this.GetCode(table, nSpace, copyright));
                sw.WriteLine();
                sw.Dispose();
            }
            //string codeDir = dir + "\\" + dataLayerName + "\\";
            //string filename = tableName + "Data.cs";
            //string entityfilename = "Entity" + tableName + ".cs";

        }
        #endregion
    }
}
