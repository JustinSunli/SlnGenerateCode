using CustomSpring.Core;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatGenerator
{
    public partial class frmMain : XtraForm
    {
        public static ConnectionsData _ConnectionsData { get; set; }
        private IDBService _dbService;
        private ISlnCreatorService _slnService;
        private delegate ConnectAction DLTestDBConnect();
        private DBStructure _dbStructure;
        private Namespace _nSpace;
        public static Copyright _copyright { get; set; }
        public frmMain()
        {
            InitializeComponent();

            UserLookAndFeel.Default.SetSkinStyle(
                SkinManager.Default.Skins[5].SkinName
                );
        }
        /// <summary>
        /// 
        /// </summary>
        private void bindCodeConfig()
        {
            #region
            this.teCreator.Text = _copyright._Creater.ToString();
            this.teCopyright.Text = _copyright._Company.ToString();
            this.deCreateDate.Properties.VistaDisplayMode = DefaultBoolean.True;
            this.deCreateDate.Properties.VistaEditTime = DefaultBoolean.True;
            this.deCreateDate.Text = Convert.ToDateTime(_copyright._GenerateTime).ToString("yyyy-MM-dd HH:mm:ss");
            this.teSlnName.Text = _nSpace._Prefix.ToString();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        private void bindTables(
            Connection connection)
        {
            #region
            _dbStructure = _dbService.GetDBStructure(connection);
            this.ckDBTableList.DataSource = _dbStructure._TablesData.Tables[0].DefaultView;
            this.ckDBTableList.DisplayMember = TablesData.name;
            this.ckDBTableList.ValueMember = TablesData.name;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(
            object sender, EventArgs e)
        {
            #region
            SpringManager.Init();
            _dbService = (IDBService)SpringManager.GetObject("dbService");
            _slnService = (ISlnCreatorService)SpringManager.GetObject("slnGenService");
            ConnectActionCollection.Init();
            _copyright = Copyright.GetParameters();
            _nSpace = Namespace.GetParameters();

            DBComboBoxController dbcombocontroller = 
                new DBComboBoxController(this.lueditDBList);
            _ConnectionsData = dbcombocontroller.GetConnections("Connection.xml");
            dbcombocontroller.BindDBList(lueditDBList_EditValueChanged);
            this.bindCodeConfig();
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lueditDBList_EditValueChanged(
            object sender, EventArgs e)
        {
            #region
            DataRow dr = _ConnectionsData.Tables[0]
                .Rows.Find(this.lueditDBList.EditValue);

            if (dr != null)
            { 
                this.teConnectString.Text =
                    dr[ConnectionsData.connectionString].ToString();

                DLTestDBConnect dltestdb = new DLTestDBConnect(testDBConnect);
                AsyncCallback callback = new AsyncCallback(testDBCallback);
                dltestdb.BeginInvoke(callback, dltestdb);
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ConnectAction testDBConnect()
        {
            #region
            Connection connection = _ConnectionsData
                        .GetEntity<Connection>(new object[1] 
                        { 
                            this.lueditDBList.EditValue 
                        });
            ConnectAction action = ConnectActionCollection.AddNew();
            if(this.InvokeRequired)
            { 
                this.Invoke(new MethodInvoker(() =>{
                    this.lbcDBConnectStatus.Text = "数据库状态：连接中…";
                    this.lbcDBConnectStatus.ForeColor = Color.Black;
                }));
            }
            action._Connection = connection;
            action._IsSuccess = _dbService.IsSuccessConnectDB(connection);

            return action;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ia"></param>
        private void testDBCallback(
            IAsyncResult ia)
        {
            #region
            DLTestDBConnect obj = (DLTestDBConnect)ia.AsyncState;
            ConnectAction action = obj.EndInvoke(ia);
            if (this.InvokeRequired && action._IsConnecting)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    string msg = "";
                    if (action._IsSuccess)
                    {
                        this.lbcDBConnectStatus.ForeColor = Color.LimeGreen;
                        msg = "数据库状态：已连接";
                        this.bindTables(action._Connection);
                    }
                    else
                    {
                        this.lbcDBConnectStatus.ForeColor = Color.Red;
                        msg = "数据库状态：连接失败";
                        if (_dbStructure != null)
                            _dbStructure._TablesData.Tables[0].Rows.Clear();
                    }
                    this.lbcDBConnectStatus.Text = msg;
                }));

            }
            ConnectActionCollection.Remove(action);
            #endregion
        }

        private void sbGenerateCode_Click(
            object sender, EventArgs e)
        {
            _slnService.GenerateAll(_copyright, _nSpace, _dbStructure, "c:\\work");
        }
    }
}
