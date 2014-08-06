using Foundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class Namespace
    {
        private const string _daoFormat
            = "{0}.Dao";
        private const string _idaoFormat
            = "{0}.IDao";
        private const string _serviceFormat
            = "{0}.Service";
        private const string _iserviceFormat
            = "{0}.IService";
        private const string _modelFormat
            = "{0}.Model";

        public const string KeyNameProjectName = "ProjectName";
        private object _prefix = "iCat.Assembly";

        public object _Prefix
        {
            get { return _prefix; }
            set { 
                _prefix = value;
                this._dao = string.Format(_daoFormat, _prefix);
                this._iDao = string.Format(_idaoFormat, _prefix);
                this._service = string.Format(_serviceFormat, _prefix);
                this._iService = string.Format(_iserviceFormat, _prefix);
                this._model = string.Format(_modelFormat, _prefix);
            }
        }

        private string _foundationCore;

        public string _FoundationCore
        {
            get { return _foundationCore; }
            set { _foundationCore = value; }
        }

        private string _customSpring;

        public string _CustomSpring
        {
            get { return _customSpring; }
            set { _customSpring = value; }
        }
        
        private string _dao;

        public string _Dao
        {
            get { return _dao; }
        }

        private string _iDao;

        public string _IDao
        {
            get { return _iDao; }
        }
        private string _service;

        public string _Service
        {
            get { return _service; }
        }

        private string _iService;

        public string _IService
        {
            get { return _iService; }
        }

        private string _model;

        public string _Model
        {
            get { return _model; }
        }

        public static Namespace GetParameters()
        {
            Namespace nspace = new Namespace();

            Config.Get(KeyNameProjectName, ref nspace._prefix);
            nspace._Prefix = nspace._prefix;
            return nspace;

        }
    }
}
