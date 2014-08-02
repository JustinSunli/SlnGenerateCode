/****************************************
***创建人：bhlfy
***创建时间：2013-08-29 03:00:29
***公司：iCat Studio
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class DataLibBase: DataSet
    {
        private string _operateMessage;
        /// <summary>
        /// 操作缓存提示（一般用作显示错误信息）
        /// </summary>
        public string _OperateMessage
        {
            get { return _operateMessage; }
            set { _operateMessage = value; }
        }
        
        /// <summary>
        /// 给缓存数据行赋值操作（这里可以加入敏感字符检测）
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="colName"></param>
        /// <param name="colValue"></param>
        public void Assign(
            DataRow currentRow, 
            string colName, object colValue)
        {
            #region
            Type fieldtype = this.Tables[0].Columns[colName].DataType;

            if (colValue != null)
                currentRow[colName] = SqlType
                    .ConvertForSQL(colValue, 
                    Type.GetTypeCode(fieldtype));
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public T GetEntity<T>(
    object[] keys)
        {
            #region
            T tuser = default(T);
            if (this == null)
            {
                string message = string.Format(
                    "TUser的数据集为空，不能从缓存中抓出数据！");

                this._OperateMessage = message;
                Console.WriteLine(message);
            }
            DataRow dr = this.Tables[0].Rows.Find(keys);
            if (dr != null)
            {
                Console.WriteLine("找到数据了！");
                Type t = typeof(T);
                tuser = (T)Activator.CreateInstance(t);
                ((IEntity)tuser).Get(dr);
            }
            else
            {
                string message = string.Format(
                    "TUser的数据集有数据，但没有符合索引的缓存数据！");
                this._OperateMessage = message;
                Console.WriteLine(message);
            }
            return tuser;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        protected void checkIsNull(
            Action callback)
        {
            #region
            if (this == null)
            {
                Console.WriteLine("DataSet Cache is null！");
                if (callback != null)
                    callback();
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        protected void checkIsNotNull(
            Action callback)
        {
            #region
            if (this != null)
            {
                if (callback != null)
                    callback();
            }
            else
                Console.WriteLine("DataSet Cache is null！");

            #endregion
        }
    }
}
