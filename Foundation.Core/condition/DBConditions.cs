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
    public class DBConditions
    {
        /// <summary>
        /// 
        /// </summary>
        private List<DBCondition> _dbConditions;
        /// <summary>
        /// 
        /// </summary>
        public List<DBCondition> _DBConditions
        {
            get { return _dbConditions; }
            set { _dbConditions = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private void init()
        {
            #region
            if(this._DBConditions == null)
                _DBConditions = new List<DBCondition>();
            #endregion
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public DBConditions()
        {
            #region
            this.init();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private DBCondition newCondition = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldCustomer"></param>
        /// <returns></returns>
        private bool existContent(
            DBCondition oldCondition)
        {
            #region
            Console.WriteLine("以下为检测是否存在相同查询条件！");

            return ((newCondition._ParamValue == oldCondition._ParamValue) &&
                (newCondition._ParamsName == oldCondition._ParamsName) &&
                (newCondition._ConditionsRelation == oldCondition._ConditionsRelation) &&
                (newCondition._EnumCondition == oldCondition._EnumCondition) &&
                (newCondition._FieldName == oldCondition._FieldName));
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public DBCondition IsExist(
            DBCondition condition)
        {
            #region
            lock (condition)
            {
                newCondition = condition;
                if (_DBConditions.Count > 0)
                    return _DBConditions.Find(existContent);
                else
                    return null;
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public void Add(
            DBCondition condition)
        {
            #region
            this.init();
            if (this.IsExist(condition) == null)
                _DBConditions.Add(condition);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public void Remove(
            DBCondition customer)
        {
            #region
            foreach (DBCondition temp in _DBConditions)
            {
                if ((customer._ParamValue == temp._ParamValue) &&
                (customer._ParamsName == temp._ParamsName) &&
                (customer._ConditionsRelation == temp._ConditionsRelation) &&
                (customer._EnumCondition == temp._EnumCondition) &&
                (customer._FieldName == temp._FieldName))
                {
                    _DBConditions.Remove(temp);

                    break;
                }
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void ViewToConsole()
        {
            #region
            Console.Write(ToString());
            #endregion
        }
        /*
        /// <summary>
        /// 输出字符串未实现（？？？）
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            #region
            StringBuilder str = new StringBuilder();
            object[] param = new object[5];
            foreach (DBCondition temp in _DBConditions)
            {
                
                param[0] = temp._UId;
                param[1] = temp.IPAddress;
                param[2] = temp.Port;
                param[3] = temp._LogonTime;
                param[4] = temp._UpdateTime;

                str.AppendLine(string.Format("UID:{0},IPAddress:{1},ClientPort:{2},LoginTime:{3},UpdateTime:{4}",
                    param));
                 
            }
            return str.ToString();
            #endregion
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="conditionType"></param>
        /// <param name="paramValue"></param>
        /// <param name="fieldType"></param>
        public void AddAndCondition(string fieldName,
            EnumCondition conditionType
            , object paramValue, 
            EnumSqlType fieldType)
        {
            #region
            this.Add(new DBCondition(){
                _FieldName= fieldName, 
                _ParamsName = fieldName, 
                _ParamValue = paramValue, 
                _ConditionsRelation = EnumConditionsRelation.And,
                _EnumCondition = conditionType,
                _FieldType = fieldType
            });
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="conditionType"></param>
        /// <param name="paramValue"></param>
        /// <param name="fieldType"></param>
        public void AddOrCondition(string fieldName,
            EnumCondition conditionType, 
            object paramValue, 
            EnumSqlType fieldType)
        {
            #region
            this.Add(new DBCondition()
            {
                _FieldName = fieldName,
                _ParamsName = fieldName,
                _ParamValue = paramValue,
                _ConditionsRelation = EnumConditionsRelation.Or,
                _EnumCondition = conditionType,
                _FieldType = fieldType
            });
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            #region
            string allconditions = "";
            if (this._DBConditions != null)
            {
                for (int i = 0; i < this._DBConditions.Count; i++)
                {
                    DBCondition condition = this._DBConditions[i];
                    EnumCondition conditiontype = condition._EnumCondition;
                    EnumSqlType fieldtype = condition._FieldType;
                    EnumConditionsRelation conditionsrelation = condition._ConditionsRelation;
                    allconditions += condition.ToString(conditiontype, condition._FieldName,
                        condition._ParamValue, fieldtype, conditionsrelation);
                }
                if (allconditions != string.Empty)
                    allconditions = allconditions.Remove(allconditions.Length - 4, 4);
            }
            return allconditions;
            #endregion
        }

    }
}
