using CustomSpring.Core;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Foundation.Core;
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
        private static Copyright _copyright;
        public frmMain()
        {
            #region
            InitializeComponent();

            UserLookAndFeel.Default.SetSkinStyle(
                SkinManager.Default.Skins[5].SkinName
                );
            #endregion
        }
        /// <summary>
        /// 绑定代码生成配置
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
        /// 绑定数据表列表
        /// </summary>
        /// <param name="connection"></param>
        private void bindTables(
            Connection connection)
        {
            #region
            _dbStructure = _dbService.GetDBStructure(connection);
            foreach (DataRow dr in _dbStructure._TablesData.Tables[0].Rows)
                this.ckDBTableList.Items.Add(dr[TablesData.name]);
            //int idx = 0;
            //while (this.ckDBTableList.GetItem(idx) != null)
            //{
            //    Console.WriteLine(this.ckDBTableList.get.ToString());
            //    idx++;
            //}
            #endregion
        }

        private void table_MouseHover(object sender, EventArgs e)
        {
            CheckEdit col = sender as CheckEdit;

            Console.WriteLine(col.Text);
        }
        /// <summary>
        /// 页面载入
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
            this.initValidateRulers();


            #endregion
        }
        /// <summary>
        /// 初始化界面提交规则
        /// </summary>
        private void initValidateRulers()
        {
            #region
            ConditionValidationRule notempty = new ConditionValidationRule();
            notempty.ConditionOperator = ConditionOperator.IsNotBlank;
            notempty.ErrorText = "该项不能为空！";

            dxValidationProvider1.SetValidationRule(this.teSlnName, notempty);
            dxValidationProvider1.SetValidationRule(this.teCreator, notempty);
            dxValidationProvider1.SetValidationRule(this.teCopyright, notempty);
            dxValidationProvider1.SetValidationRule(this.lueditDBList, notempty);
            #endregion
        }
        /// <summary>
        /// 选择数据库后的事件
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
        /// 测试连接数据库
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
        /// 测试连接数据库后的操作
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
        /// <summary>
        /// 生成代码事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbGenerateCode_Click(
            object sender, EventArgs e)
        {
            #region
            if (dxValidationProvider1.Validate())
            {
                if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = this.folderBrowserDialog1.SelectedPath;
                    this.saveConfig();
                    _slnService.GenerateAll(_copyright, _nSpace, _dbStructure, path);
                    ExtMessage.Show(string.Format("成功生成到目录{0}！",path));
                }

            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void saveConfig()
        {
            #region
            object slnname, creator, creattime, company;
            slnname = this.teSlnName.Text;
            creator = this.teCreator.Text;
            creattime = this.deCreateDate.Text;
            company = this.teCopyright.Text;
            Config.Update(Namespace.KeyNameProjectName, ref slnname);
            Config.Update(Copyright.KeyNameCreator, ref creator);
            Config.Update(Copyright.KeyNameCreatTime, ref creattime);
            Config.Update(Copyright.KeyNameCompany, ref company);
            _nSpace._Prefix = slnname;
            _copyright._Creater = creator;
            _copyright._GenerateTime = creattime;
            _copyright._Company = company;
            #endregion
        }

        private void sbtnDBTableAllCheck_Click(
            object sender, EventArgs e)
        {

        }

        private void sbtnDBTableNoneCheck_Click(
            object sender, EventArgs e)
        {

        }

        private void sbtnDBTableReverseCheck_Click(
            object sender, EventArgs e)
        {

        }
    }
}
