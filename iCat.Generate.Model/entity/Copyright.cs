using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class Copyright
    {
        private const string _template = @"/****************************************
***生成器版本：{0}
***创建人：{1}
***生成时间：{2}
***公司：{3}
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/";

        private string _creater;

        public string _Creater
        {
            get { return _creater; }
            set { _creater = value; }
        }
        private string _company;

        public string _Company
        {
            get { return _company; }
            set { _company = value; }
        }
        private string _version;

        public string _Version
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
            args[2] = DateTime.Now;
            args[3] = _company;
            return string.Format(_template, args);
            #endregion
        }
    }
}
