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
    public class GenFileDaoService : GenFileServiceBase, IFileCreatorService
    {
        private const string _fileTemplate = @"
{0}
{1}

namespace {2}
{{
    public class {3}Dao : BaseDao, I{3}Dao
    {{
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name=""{4}Data"">欲保存的数据集</param>
        public void Save({3}Data {4}Data)
        {{
            base.Save({4}Data);
        }}
        {5}
        /// <summary>
        /// 检索单表
        /// </summary>
        /// <param name=""condition"">查询条件</param>
        /// <returns>{3}的数据集</returns>
        public {3}Data SelectSingleT(
            QueryCondition condition)
        {{
            return base.GetDataSet<{3}Data>(condition);
        }}

        #region 用户自定义多表关联查询模版
        /*
        public DataSet Select{3}ByPage(
            QueryCondition condition, 
            out int totalCount) 
        {{
            #region
            //该sql语句需用户自定义构建
            string businesssql = @""select a.applyForId,a.userOfApplyFor,d.groupId,d.groupNO,d.groupName,
a.applyForMemo,a.applyForTime 
 from IMApplyForGroup a
left join IMVerifyApplyFor b on a.applyForId=b.applyForId 
join IMGroup d on a.groupId=d.groupId "";
            //分页后的呈现数据源
            DataSet ds = new DataSet();
            //添加分页依据字段（必选，可多个），请根据实际业务定义。
            condition.AddInKey({3}Mapping.primaryKeyName);
            //填充数据源
            base.fillDsByPage(ds, condition, businesssql);
            //符合查询条件的数据记录（调用基类查询方法）
            totalCount = base.selectRecordCount(
                condition, businesssql);
            return ds;
            #endregion
        }}
        */
        #endregion
    }}
}}";
        //4为首字母小写的表名，3为原始表名，
        public string GetCode(
            TableStructure table)
        {
            #region
            string all = "";
            List<string> args = new List<string>();
            args.Add(base._Copyright);
            args.Add(base._Usings);
            args.Add(this._Project._Name);
            args.Add(table._Name);
            args.Add(table._ParamNamePrefix);
            args.Add(this.getMaxidCode(table));
            all = string.Format(_fileTemplate, args.ToArray<string>());
            return all;
            #endregion
        }

        private string getMaxidCode(
            TableStructure table)
        {
            string temp = @"/// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns>最大编号</returns>
        public int GetMaxId()
        {{
            return base.GetMaxId<{0}Data>();
        }}";
            temp = (table._HasIntPrimaryKey) ? string.Format(temp, table._Name) : "";
            return temp;
        }

        private string getUsing(
            Namespace nSpace)
        {
            #region
            IList<string> usings = new List<string>();
            usings.Add(nSpace._CustomSpring.ToString());
            usings.Add(nSpace._FoundationCore.ToString());
            usings.Add(nSpace._IDao);
            usings.Add(nSpace._Model);

            this._Project._ReferenceNSpace = usings;

            return base.StrcatUsing(usings);
            #endregion
        }

        public void Generate(
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
            #region

            if (this._Project == null)
                this._Project = new Project(){ 
                    _Guid = Guid.NewGuid(),
                    _Name = nSpace._Dao
                };
            else
                this._Project._ReferenceNSpace.Clear();

            base._Usings = getUsing(nSpace);
            base._Copyright = copyright.ToString();

            string codedir = Path.Combine(
                parentDir, this._Project._Name);

            base.CheckDir(codedir);

            _FileNameFormat = "{0}Dao.cs";

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
            #region
            base.SaveCsproj(dbStructure, allProjects, parentDir);
            base.SaveAssembly(parentDir);
            #endregion
        }

    }
}
