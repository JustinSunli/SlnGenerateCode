using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCatGenerator
{
    class ConnectActionCollection
    {
        private static List<ConnectAction> 
            _connectActions;

        public static List<ConnectAction> _ConnectActions
        {
            get { return _connectActions; }
            set { _connectActions = value; }
        }
        private static readonly object IsLock = "True";
        public static int MaxCID { get; set; }
        private static ConnectAction _newObj = null;
        public static ConnectAction AddNew()
        {
            #region
            ConnectAction action = null;            
            lock (IsLock)
            { 
                foreach (ConnectAction temp in _ConnectActions)
                    temp._IsConnecting = false;

                action = new ConnectAction()
                {
                    _CID = MaxCID+1,
                    _IsConnecting = true
                };
                _ConnectActions.Add(action);
                MaxCID++;
            }
            return action;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldCustomer"></param>
        /// <returns></returns>
        private static bool existCID(
            ConnectAction oldObj)
        {
            #region

            return (_newObj._CID == oldObj._CID);
            #endregion
        }

        public static void Remove(
            ConnectAction action)
        {
            #region
            lock (IsLock)
            { 
                _newObj = action;
                ConnectAction findobj = _connectActions.Find(existCID);
                if (findobj != null)
                    _ConnectActions.Remove(findobj);
            }
            #endregion
        }

        public static void Init()
        {
            _ConnectActions = new List<ConnectAction>();
            MaxCID = 0;
        }

        public static void ViewToConsole()
        {
            #region
            Console.WriteLine("当前测试连接最大ID为：{0}", MaxCID);

            foreach (ConnectAction t in _ConnectActions)
                Console.WriteLine(
                    "cid:{0},issuccess:{1},isconnecting:{2}", 
                    t._CID, 
                    t._IsSuccess, 
                    t._IsConnecting);
            #endregion
        }
    }

    class ConnectAction
    {
        private int _cid;

        public int _CID
        {
            get { return _cid; }
            set { _cid = value; }
        }

        private bool _isSuccess;

        public bool _IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }
        

        private bool _isConnecting;

        public bool _IsConnecting
        {
            get { return _isConnecting; }
            set { _isConnecting = value; }
        }
        private Connection _connection;

        public Connection _Connection
        {
            get { return _connection; }
            set { _connection = value; }

        }
        
    }
}
