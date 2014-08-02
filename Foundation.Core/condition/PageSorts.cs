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
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class PageSorts : System.Collections.CollectionBase
    {

        /// <summary>
        /// 增加排序条件（可以改进查找匹配算法？）
        /// </summary>
        /// <param name="sqlExpression"></param>
        public void Add(PageSort pagesort)
        {
            #region
            
            for (int i = 0; i < this.Count; i++)
            {
                if (pagesort._FieldName 
                    == ((PageSort)List[i])._FieldName)
                {
                    ExtConsole.WriteWithColor("不能重复添加排序字段!");
                    return;
                }
            }
            List.Add(pagesort);
            #endregion
        }
        /// <summary>
        /// 删除排序条件
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            #region
            if (index > Count - 1 || index < 0)
            {
                ExtConsole.WriteWithColor("删除排序时，索引出错!");
                return;
            }
            List.RemoveAt(index);
            
            #endregion
        }
        /// <summary>
        /// 设置索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PageSort this[int index]
        {
            #region
            get
            {
                return (PageSort)List[index];
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            #region
            string orderby = "";
            string format = "";
            if (this != null)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    PageSort pagesort = this[i];
                    format = (i == 0) ? "{0} {1}" : ",{0} {1}";
                    orderby += string.Format(format,
                        pagesort._FieldName, getAscOrDesc(pagesort._OrderBy));
                }
                if (this.Count > 0)
                    orderby = string.Format("order by {0}", orderby);
            }
            return orderby;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderbyType"></param>
        /// <returns></returns>
        private String getAscOrDesc(
            EnumSQLOrderBY orderbyType)
        {
            #region
            return (orderbyType == EnumSQLOrderBY.ASC) ? "ASC" : "DESC";
            #endregion
        }
    }
}
