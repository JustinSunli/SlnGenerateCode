using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustomSpring.Core.Dao
{
    public class SQLCreator
    {
        private static string _selectPageSqlFormat = @"select top {0} {2} from ({4}) as a
where {3} not in (select top ({0}*({1}-1)) {3} from ({4}) as b {5}) {5}
";
        private static string _selectNoPageSqlFormat = @"select {0} from ({1}) as a {2}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="condition"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string GetSelectSQL(
            string sql,
            QueryCondition condition,
            DataSet ds)
        {
            #region

            string format = (condition._PageSize == 0)? 
                _selectNoPageSqlFormat: 
                _selectPageSqlFormat;
            string strcondition = condition.
                _DBContainer.ToString();
            string orderby = condition._PageSorts.ToString();
            string key = getInKeysString(condition, ds);

            string fullsql = string.IsNullOrEmpty(strcondition) ?
                    sql : string.Format("{0} where {1}", sql, strcondition);
            string returnfields = condition.GetReturnFields();
            object[] argument = null;

            if (condition._PageSize != 0)
            {
                argument = new object[6];
                argument[0] = condition._PageSize;
                argument[1] = condition._PageIndex;
                argument[2] = returnfields;
                argument[3] = key;
                argument[4] = fullsql;
                argument[5] = orderby;
            }
            else
            {
                argument = new object[3];
                argument[0] = returnfields;
                argument[1] = fullsql;
                argument[2] = orderby;
            }
            fullsql = string.Format(format, argument);
            ExtConsole.Write(fullsql);
            return fullsql;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static string getInKeysString(
            QueryCondition condition, DataSet ds)
        {
            #region
            string inkeysstring = "";
            if (condition._InKeys != null)
                for (int i = 0; i < condition._InKeys.Count; i++)
                    strcat(ref inkeysstring, i, condition._InKeys[i]);
            else
                inkeysstring = getInKeysByDataSet(ds);
            return inkeysstring;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static string getInKeysByDataSet(
            DataSet ds)
        {
            #region
            string inkeysstring = "";
            DataColumn[] dc = GetPrimaryKey(ds);
            for (int i = 0; i < dc.Length; i++)
                strcat(ref inkeysstring, i, dc[i].ColumnName);
            return inkeysstring;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inKeysString"></param>
        /// <param name="inKeyIndex"></param>
        /// <param name="inkey"></param>
        private static void strcat(
            ref string inKeysString,
            int inKeyIndex,
            string inkey)
        {
            #region
            if (inKeyIndex == 0)
                inKeysString += inkey;
            else
                inKeysString += string.Format("+{0}", inkey);
            #endregion
        }
        /// <summary>
        /// 根据输入数据集构建选择语句
        /// </summary>
        /// <param name="willSaveDs"></param>
        /// <returns></returns>
        public static String CreateBuilderSelectSQL(
            DataSet willSaveDs)
        {
            #region
            DataColumn[] cols = GetPrimaryKey(willSaveDs);

            string keyfieldname = cols[0].ColumnName;
            string sqlexpression = String.Format("select * from [{0}] where {1}=@{1} ",
                willSaveDs.Tables[0].TableName, keyfieldname);
            return sqlexpression;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static DataColumn[] GetPrimaryKey(
            DataSet ds)
        {
            #region
            DataTable dt = ds.Tables[0];
            if (dt.PrimaryKey.Length <= 0)
            {
                string message = string.Format(
                    "该表[{0}]不存在主键！",
                    dt.TableName);

                throw new Exception(message);
            }
            return dt.PrimaryKey;
            #endregion
        }

    }
}
