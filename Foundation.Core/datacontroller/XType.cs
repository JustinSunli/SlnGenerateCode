using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class XType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static string getCSharpTypeName(
            string typeId)
        {
            #region
            string typeName = "";
            switch (typeId)
            {
                case "56":
                    {
                        typeName = "Int32";
                        break;
                    }
                case "52":
                    {
                        typeName = "Int16";
                        break;
                    }
                case "127":
                    {
                        typeName = "Int64";
                        break;
                    }
                case "231":
                    {
                        typeName = "String";
                        break;
                    }
                case "61":
                    {
                        typeName = "DateTime";
                        break;
                    }
                case "48":
                    {
                        typeName = "Byte";
                        break;
                    }
                case "104":
                    {
                        typeName = "Boolean";
                        break;
                    }
                case "106":
                    {
                        typeName = "Decimal";
                        break;
                    }
                default:
                    {
                        typeName = "Object";
                        break;
                    }
            }
            return typeName;
            #endregion
        }
        /// <summary>
        /// 根据数据库中的xtype值，获取参数类型
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static string getTypeName(
            string typeId)
        {
            #region
            string typeName = "";
            switch (typeId)
            {
                case "56":
                    {
                        typeName = "int";
                        break;
                    }
                case "52":
                    {
                        typeName = "int";
                        break;
                    }
                case "127":
                    {
                        typeName = "int";
                        break;
                    }
                case "231":
                    {
                        typeName = "string";
                        break;
                    }
                case "61":
                    {
                        typeName = "DateTime";
                        break;
                    }
                case "48":
                    {
                        typeName = "int";
                        break;
                    }
                case "104":
                    {
                        typeName = "bool";
                        break;
                    }
                case "106":
                    {
                        typeName = "decimal";
                        break;
                    }
                default:
                    {
                        typeName = "object";
                        break;
                    }
            }
            return typeName;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static string getUIModelTypeName(
            string typeId)
        {
            #region
            string typeName = "";
            switch (typeId)
            {
                case "56":
                    {
                        typeName = "int";
                        break;
                    }
                case "127":
                    {
                        typeName = "int";
                        break;
                    }
                case "52":
                    {
                        typeName = "int";
                        break;
                    }
                case "231":
                    {
                        typeName = "string";
                        break;
                    }
                case "61":
                    {
                        typeName = "date";
                        break;
                    }
                case "48":
                    {
                        typeName = "int";
                        break;
                    }
                case "104":
                    {
                        typeName = "bool";
                        break;
                    }
                case "106":
                    {
                        typeName = "auto";
                        break;
                    }
                default:
                    {
                        typeName = "auto";
                        break;
                    }
            }
            return typeName;
            #endregion
        }
        /// <summary>
        /// 获取业务层赋值转换方法名
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static string getFuncName(
            string typeId)
        {
            #region
            string funcName = "";
            switch (typeId)
            {
                case "56":
                    {
                        funcName = "ConvertStrToIntForSQL";
                        break;
                    }
                case "127":
                    {
                        funcName = "ConvertStrToIntForSQL";
                        break;
                    }
                case "231":
                    {
                        funcName = "ConvertStrForSQL";
                        break;
                    }
                case "61":
                    {
                        funcName = "ConvertDtForSQL";
                        break;
                    }
                case "48":
                    {
                        funcName = "ConvertIntForSQL";
                        break;
                    }
                case "104":
                    {
                        funcName = "ConvertBoolForSQL";
                        break;
                    }
                case "106":
                    {
                        funcName = "ConvertDecimalForSQL";
                        break;
                    }
                default:
                    {
                        funcName = "ConvertObjForSQL";
                        break;
                    }
            }
            return funcName;
            #endregion
        }
    }
}
