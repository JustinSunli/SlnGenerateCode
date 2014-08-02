using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    class Copyright
    {
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
        
    }
}
