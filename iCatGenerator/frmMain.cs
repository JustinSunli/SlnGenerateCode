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
        private delegate ConnectAction DLTestDBConnect();
        public static DBStructure _DBStructure { get; set; }
        public static Namespace _NSpace { get; set; }
        public static Copyright _Copyright { get; set; }
        public static List<string> _SelectTables { get; set; }
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
            this.teCreator.Text = _Copyright._Creater.ToString();
            this.teCopyright.Text = _Copyright._Company.ToString();
            this.deCreateDate.Properties.VistaDisplayMode = DefaultBoolean.True;
            this.deCreateDate.Properties.VistaEditTime = DefaultBoolean.True;
            this.deCreateDate.Text = Convert.ToDateTime(_Copyright._GenerateTime).ToString("yyyy-MM-dd HH:mm:ss");
            this.teSlnName.Text = _NSpace._Prefix.ToString();
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
            this.ckDBTableList.Items.Clear();
            _DBStructure = _dbService.GetDBStructure(connection);
            foreach (DataRow dr in _DBStructure._TablesData.Tables[0].Rows)
                this.ckDBTableList.Items.Add(dr[TablesData.name]);
            #endregion
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
            _dbService = (IDBService)SpringManager.GetObject(SpringKeys.DBService);
            ConnectActionCollection.Init();
            _Copyright = Copyright.GetParameters();
            _NSpace = Namespace.GetParameters();
            _SelectTables = new List<string>();

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
            dxValidationProvider1.SetValidationRule(this.deCreateDate, notempty);
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
                        if (_DBStructure != null)
                        { 
                            _DBStructure._TablesData.Tables[0].Rows.Clear();
                            this.ckDBTableList.Items.Clear();
                        }
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
                BaseCheckedListBoxControl.CheckedItemCollection ck 
                    = this.ckDBTableList.CheckedItems;
                if (ck.Count <= 0)
                {
                    ExtMessage.Show("请选择要生成代码的数据表！");
                    return;
                }
                this.saveConfig();
                _SelectTables.Clear();
                foreach (CheckedListBoxItem s in ck)
                    _SelectTables.Add(s.Value.ToString());

                (new frmGenInfor()).ShowDialog();
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
            _NSpace._Prefix = slnname;
            _Copyright._Creater = creator;
            _Copyright._GenerateTime = creattime;
            _Copyright._Company = company;
            #endregion
        }
        /// <summary>
        /// 全选表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtnDBTableAllCheck_Click(
            object sender, EventArgs e)
        {
            #region
            foreach (CheckedListBoxItem obj in this.ckDBTableList.Items)
                obj.CheckState = CheckState.Checked;
            #endregion
        }
        /// <summary>
        /// 全不选表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtnDBTableNoneCheck_Click(
            object sender, EventArgs e)
        {
            #region
            foreach (CheckedListBoxItem obj in this.ckDBTableList.Items)
                obj.CheckState = CheckState.Unchecked;
            #endregion
        }
        /// <summary>
        /// 反选表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtnDBTableReverseCheck_Click(
            object sender, EventArgs e)
        {
            #region
            foreach (CheckedListBoxItem obj in this.ckDBTableList.Items)
                obj.CheckState = 
                    (obj.CheckState == CheckState.Checked)
                    ?CheckState.Unchecked
                    :CheckState.Checked;
            #endregion
        }
        /// <summary>
        /// 刷新连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtnRefresh_Click(
            object sender, EventArgs e)
        {
            #region
            lueditDBList_EditValueChanged(null, null);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbDBConifg_Click(
            object sender, EventArgs e)
        {
            #region
            (new frmSetConnect()).ShowDialog();
            #endregion
        }
    }
}
