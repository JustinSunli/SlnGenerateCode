﻿using Foundation.Core;
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
        private const string _dbMappingFormat
            = "{0}.DBMapping";
        private const string _idaoFormat
            = "{0}.IDao";
        private const string _serviceFormat
            = "{0}.Service";
        private const string _iserviceFormat
            = "{0}.IService";
        private const string _modelFormat
            = "{0}.Model";
        private const string _appFormat
            = "{0}.Client";
        private const string _businessFormat
            = "{0}.Business";

        public const string KeyNameProjectName = "ProjectName";
        public const string KeyNameWCFName = "WCFName";
        public const string KeyNameFoundation = "FoundationAssemblyName";
        public const string KeyNameSpringCoreName = "SpringCoreName";
        private object _prefix = "iCat.Assembly";

        public object _Prefix
        {
            get { return _prefix; }
            set { 
                _prefix = value;
                this._dao = string.Format(_daoFormat, _prefix);
                this._dbMapping = string.Format(_dbMappingFormat, _prefix);
                this._iDao = string.Format(_idaoFormat, _prefix);
                this._service = string.Format(_serviceFormat, _prefix);
                this._iService = string.Format(_iserviceFormat, _prefix);
                this._model = string.Format(_modelFormat, _prefix);
                this._app = string.Format(_appFormat, _prefix);
                this._business = string.Format(_businessFormat, _prefix);
            }
        }

        private object _wcfName = "NormalDocumentOffice.WinServer";

        public object _WCFName
        {
            get { return _wcfName; }
            set { _wcfName = value; }
        }

        private object _foundationCore = "Foundation.Core";

        public object _FoundationCore
        {
            get { return _foundationCore; }
            set { _foundationCore = value; }
        }

        private object _customSpring = "CustomSpring.Core";

        public object _CustomSpring
        {
            get { return _customSpring; }
            set { _customSpring = value; }
        }
        private string _dbMapping;

        public string _DBMapping
        {
            get { return _dbMapping; }
            set { _dbMapping = value; }
        }

        private string _dao;

        public string _Dao
        {
            get { return _dao; }
        }
        private string _business;

        public string _Business
        {
            get { return _business; }
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

        private string _app;

        public string _App
        {
            get { return _app; }
            set { _app = value; }
        }
        

        public static Namespace GetParameters()
        {
            Namespace nspace = new Namespace();

            Config.Get(KeyNameProjectName, ref nspace._prefix);
            Config.Get(KeyNameWCFName, ref nspace._wcfName);
            Config.Get(KeyNameFoundation, ref nspace._foundationCore);
            Config.Get(KeyNameSpringCoreName, ref nspace._customSpring);
            nspace._Prefix = nspace._prefix;
            return nspace;

        }
    }
}
