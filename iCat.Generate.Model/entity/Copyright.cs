using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class Copyright
    {
        /*
***版权声明：本生成器版权归【李峰艳】
***         所有，若复制本软件或利用
***         本软件进行代码生成时未经
***         本人同意，为侵权行为。
         **/
        private const string _template = @"/****************************************
***生成器版本：{0}
***创建人：{1}
***生成时间：{2}
***公司：{3}
***友情提示：本文件为生成器自动生成，
***         如发现任何编译和运行时的
***         错误，请联系QQ：330669393。
*****************************************/";
        public const string KeyNameCreator = "Creator";
        public const string KeyNameCompany = "Company";
        public const string KeyNameVersion = "SoftwareVersion";
        public const string KeyNameCreatTime = "CreatTime";

        private object _creater = "lifengyan";

        public object _Creater
        {
            get { return _creater; }
            set { _creater = value; }
        }
        private object _company = "iCat Studio";

        public object _Company
        {
            get { return _company; }
            set { _company = value; }
        }
        private object _version = "V2.0";
        private object _generateTime = DateTime.Now;

        public object _GenerateTime
        {
            get { return _generateTime; }
            set { _generateTime = value; }
        }
        
        public object _Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public override string ToString()
        {
            #region
            object[] args = new object[4];
            args[0] = _version;
            args[1] = _creater;
            args[2] = _generateTime;
            args[3] = _company;
            return string.Format(_template, args);
            #endregion
        }

        public static Copyright GetParameters()
        {
            Copyright copyright = new Copyright();

            Config.Get(KeyNameCreator, ref copyright._creater);
            Config.Get(KeyNameCompany, ref copyright._company);
            Config.Get(KeyNameVersion, ref copyright._version);
            Config.Get(KeyNameCreatTime, ref copyright._generateTime);

            return copyright;
        }
    }
}
