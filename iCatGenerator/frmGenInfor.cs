using CustomSpring.Core;
using DevExpress.XtraEditors;
using Foundation.Core;
using iCat.Generate.IService;
using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCatGenerator
{
    public partial class frmGenInfor : XtraForm
    {
        private ISlnCreatorService _slnService;
        private const string infoformat = @"当前共选择生成{0}个数据表的代码！

{1}

友情提示：无关键字的数据表在进行代码生成时，虽然可以正常生成，但在运用到实际项目时会产生各种问题，比如编辑或删除表数据操作就不可以正常进行！";
        public frmGenInfor()
        {
            InitializeComponent();
        }

        private void sbtnStartGen_Click(
            object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() 
                == System.Windows.Forms.DialogResult.OK)
            {
                string path = this.folderBrowserDialog1.SelectedPath;
                _slnService.Generate(
                    frmMain._Copyright, 
                    frmMain._NSpace, 
                    frmMain._DBStructure, 
                    path);
                ExtMessage.Show(string.Format("成功生成到目录{0}！", path));
            }
        }

        private void sbtnCancel_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }
        private void fillTablesIsGen(
            DBStructure _dbStructure,
            IList<string> tables)
        {
            #region
            foreach (TableStructure t in _dbStructure._Tables)
                t._IsGen = false;

            foreach (string s in tables)
            {
                foreach (TableStructure t in _dbStructure._Tables)
                {
                    if (s == t._Name)
                    {
                        t._IsGen = true;//?
                        break;
                    }
                }
            }
            #endregion
        }
        private string getInValidTables(ref int isGenTables)
        {
            #region
            StringBuilder temp = new StringBuilder();
            IList<TableStructure> tables = frmMain._DBStructure._Tables;
            int errorcount = 0;
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i]._IsGen)
                {
                    isGenTables++;
                    if (tables[i]._PrimaryKeys.Count <= 0)
                    {
                        temp.Append(string.Format("[{0}],", tables[i]._Name));
                        errorcount++;
                    }
                }
            }
            string ret = temp.ToString();
            if (errorcount > 0)
                ret = ret.Remove(ret.Length - 1, 1);
            return ret;
            #endregion
        }

        private void frmGenInfor_Load(object sender, EventArgs e)
        {
            _slnService = (ISlnCreatorService)SpringManager.GetObject("slnGenService");
            fillTablesIsGen(frmMain._DBStructure, frmMain._SelectTables);
            string error = "警告：当前所选表中无关键字的数据表有{0} !";
            int isgentables = 0;
            string invalidtables = this.getInValidTables(ref isgentables);
            error = string.IsNullOrEmpty(invalidtables)
                ? "当前选择的数据表都可正常生成代码！"
                :string.Format(error, invalidtables);

            this.meditCodeInfor.Text = string.Format(infoformat, isgentables, error);

        }
    }
}
