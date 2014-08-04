using Foundation.Core;
using Spring.Data.Common;
using Spring.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustomSpring.Core.Dao
{
    public class BaseDao : AdoDaoSupport
    {
        /// <summary>
        /// 保存数据集（添加、编辑、删除）单行或多行数据
        /// </summary>
        /// <param name="ds"></param>
        public void Save(
            DataSet ds)
        {
            #region

            string tablename = "";
            this.checkTablesCount(ds, () => { 
                tablename = ds.Tables[0].TableName;
                this.checkTablesName(tablename, () => { 
                    Console.WriteLine("starting exec savesql, tablename is [{0}]", ds.Tables[0].TableName);
                    string selectsql = SQLCreator.CreateBuilderSelectSQL(ds);
                    Console.WriteLine("sql = [{0}]", selectsql);
                    Console.WriteLine("save records count is [{0}]", ds.Tables[0].Rows.Count);
                    
                    this.AdoTemplate.DataSetUpdateWithCommandBuilder(
                        ds, System.Data.CommandType.Text,
                        selectsql, getSelectParams(ds), 
                        ds.Tables[0].TableName);
                    Console.WriteLine("exec savesql has completed, tablename is [{0}]", ds.Tables[0].TableName);
                });
            });
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int GetMaxId<T>()
        {
            #region
            Type t = typeof(T);
            DataSet tuser = (DataSet)Activator.CreateInstance(t);

            DataColumn[] cols = SQLCreator.GetPrimaryKey(tuser);
            string keyfieldname = "";
            foreach (DataColumn col in cols)
            {
                Type fieldtype = col.DataType;
                TypeCode coltype = Type.GetTypeCode(fieldtype);
                if (coltype == TypeCode.Byte ||
                    coltype == TypeCode.Int16 ||
                    coltype == TypeCode.Int32 ||
                    coltype == TypeCode.Int64)
                {
                    keyfieldname = col.ColumnName;
                    break;
                }
            }
            string selectsql = string.Format(
                "select max([{0}]) from [{1}]",
                keyfieldname,
                tuser.Tables[0].TableName);

            object maxid = this.AdoTemplate
                .ExecuteScalar(CommandType.Text, selectsql);
            return (maxid != System.DBNull.Value) ? Convert.ToInt32(maxid) : 0;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willSaveDs"></param>
        /// <returns></returns>
        private IDbParameters getSelectParams(
            DataSet willSaveDs)
        {
            #region
            DataTable willsavedt = willSaveDs.Tables[0];
            if (willsavedt.PrimaryKey.Length <= 0)
                Console.Write("欲保存的数据集没有主键，不能自动生成sql语句！");
            string keyfieldname = willSaveDs.Tables[0].PrimaryKey[0].ColumnName;
            IDbParameters dbparams = this.AdoTemplate.CreateDbParameters(); ;
            dbparams.Add(keyfieldname, DbType.String).Value = "";
            return dbparams;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="action"></param>
        private void checkTablesCount(
            DataSet ds, Action action)
        {
            #region
            if (ds.Tables.Count == 0)
            {
                Console.WriteLine("exec savesql error: dataset hasn't any table!");
                return;
            }
            if (action != null)
                action();

            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="action"></param>
        private void checkTablesName(
            string tableName, Action action)
        {
            #region
            if (string.IsNullOrEmpty(tableName))
            {
                Console.WriteLine("exec savesql error: tablename is empty!");
                return;
            }
            if (action != null)
                action();
            #endregion
        }
        protected T GetDataSet<T>(
            QueryCondition condition)
        {
            return this.GetDataSet<T>(condition, null);
        }

        protected T GetDataSet<T>(
            QueryCondition condition,
            string sql)
        {
            if (condition == null)
                condition = new QueryCondition();

            T ds = default(T);
            Type t = typeof(T);
            ds = (T)Activator.CreateInstance(t);
            DataSet temp = ds as DataSet;
            sql = (string.IsNullOrEmpty(sql))?string.Format(
                "select * from [{0}]", 
                temp.Tables[0].TableName):sql;
            sql = SQLCreator.GetSelectSQL(sql, condition, temp);
            
            this.AdoTemplate.DataSetFill(temp, 
                CommandType.Text, sql, 
                new string[1] { temp.Tables[0].TableName }
                );
            return ds;
            
        }
    }
}
