using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class DBCondition
    {
        private const string conditionInitFormat 
            = " ([{0}] {1} '{2}') {3} ";
        private const string conditionLeftLikeFormat 
            = " ([{0}] {1} '%{2}') {3} ";
        private const string conditionRightLikeFormat 
            = " ([{0}] {1} '{2}%') {3} ";
        private const string conditionBothLikeFormat 
            = " ([{0}] {1} '%{2}%') {3} ";
        private const string conditionEmptyIsNullFormat 
            = " ([{0}] is null) {1} ";
        private const string conditionIsNotNullFormat 
            = " ([{0}] is not null) {1} ";
        private const string conditionInValuesFormat 
            = " ([{0}] in ({1})) {2} ";

        private string _paramsName;

        public string _ParamsName
        {
            get { return _paramsName; }
            set { _paramsName = value; }
        }

        private string _fieldName;

        public string _FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        private object _paramValue;

        public object _ParamValue
        {
            get { return _paramValue; }
            set { _paramValue = value; }
        }

        private EnumCondition _enumCondition;

        public EnumCondition _EnumCondition
        {
            get { return _enumCondition; }
            set { _enumCondition = value; }
        }

        private EnumConditionsRelation _conditionsRelation;

        public EnumConditionsRelation _ConditionsRelation
        {
            get { return _conditionsRelation; }
            set { _conditionsRelation = value; }
        }

        private EnumSqlType _fieldType;

        public EnumSqlType _FieldType
        {
            get { return _fieldType; }
            set { _fieldType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditionType"></param>
        /// <param name="fieldName"></param>
        /// <param name="paramValue"></param>
        /// <param name="fieldtype"></param>
        /// <param name="conditionsRelation"></param>
        /// <returns></returns>
        public string ToString(
            EnumCondition conditionType,
    object fieldName, object paramValue, 
            EnumSqlType fieldtype,
    EnumConditionsRelation conditionsRelation)
        {
            #region
            string condition = "";
            string relation = (conditionsRelation == EnumConditionsRelation.And) ? "and" : "or";
            switch (conditionType)
            {
                case EnumCondition.IsNotNull:
                    if (paramValue.ToString() == string.Empty)
                        condition += String.Format(conditionIsNotNullFormat,
                            fieldName, relation);
                    break;
                case EnumCondition.EmptyIsNull:
                    if (paramValue.ToString() == string.Empty)
                        condition += String.Format(conditionEmptyIsNullFormat,
                            fieldName, relation);
                    else
                        condition += String.Format(conditionInitFormat,
                            fieldName, "=", paramValue, relation);
                    break;
                case EnumCondition.Equal:
                    if (paramValue != null)
                    {
                        if (fieldtype == EnumSqlType.bit)
                            paramValue = Convert.ToBoolean(paramValue) ? "1" : "0";
                        condition += String.Format(conditionInitFormat,
                            fieldName, "=", paramValue, relation);
                    }
                    break;
                case EnumCondition.LikeBoth:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionBothLikeFormat,
                            fieldName, "like", paramValue, relation);
                    break;
                case EnumCondition.LikeLeft:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionLeftLikeFormat,
                            fieldName, "like", paramValue, relation);
                    break;
                case EnumCondition.LikeRight:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionRightLikeFormat,
                            fieldName, "like", paramValue, relation);
                    break;
                case EnumCondition.Greater:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionInitFormat,
                            fieldName, ">", paramValue, relation);
                    break;
                case EnumCondition.GreaterOrEqual:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionInitFormat,
                            fieldName, ">=", paramValue, relation);
                    break;
                case EnumCondition.LessOrEqual:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionInitFormat,
                            fieldName, "<=", paramValue, relation);
                    break;
                case EnumCondition.Less:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionInitFormat,
                            fieldName, "<", paramValue, relation);
                    break;
                case EnumCondition.InValues:
                    if (paramValue.ToString() != string.Empty)
                        condition += String.Format(conditionInValuesFormat,
                            fieldName, paramValue, relation);
                    break;
                default:
                    break;
            }
            return condition;
            #endregion
        }

    }
}
 