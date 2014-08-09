namespace iCatGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.sbtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lbcDBConnectStatus = new DevExpress.XtraEditors.LabelControl();
            this.lueditDBList = new DevExpress.XtraEditors.LookUpEdit();
            this.sbDBConifg = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teConnectString = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.deCreateDate = new DevExpress.XtraEditors.DateEdit();
            this.sbGenerateCode = new DevExpress.XtraEditors.SimpleButton();
            this.teCopyright = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.teCreator = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.teSlnName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.ckDBTableList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sbtnDBTableAllCheck = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnDBTableNoneCheck = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnDBTableReverseCheck = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueditDBList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teConnectString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCopyright.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSlnName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckDBTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.sbtnRefresh);
            this.groupControl1.Controls.Add(this.lbcDBConnectStatus);
            this.groupControl1.Controls.Add(this.lueditDBList);
            this.groupControl1.Controls.Add(this.sbDBConifg);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.teConnectString);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(766, 132);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "数据库";
            // 
            // sbtnRefresh
            // 
            this.sbtnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnRefresh.Appearance.Options.UseFont = true;
            this.sbtnRefresh.Location = new System.Drawing.Point(539, 36);
            this.sbtnRefresh.Name = "sbtnRefresh";
            this.sbtnRefresh.Size = new System.Drawing.Size(61, 26);
            this.sbtnRefresh.TabIndex = 8;
            this.sbtnRefresh.Text = "刷新";
            // 
            // lbcDBConnectStatus
            // 
            this.lbcDBConnectStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbcDBConnectStatus.Location = new System.Drawing.Point(589, 92);
            this.lbcDBConnectStatus.Name = "lbcDBConnectStatus";
            this.lbcDBConnectStatus.Size = new System.Drawing.Size(117, 14);
            this.lbcDBConnectStatus.TabIndex = 7;
            this.lbcDBConnectStatus.Text = "数据库状态：未连接";
            // 
            // lueditDBList
            // 
            this.lueditDBList.Location = new System.Drawing.Point(148, 35);
            this.lueditDBList.Name = "lueditDBList";
            this.lueditDBList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueditDBList.Size = new System.Drawing.Size(376, 21);
            this.lueditDBList.TabIndex = 4;
            // 
            // sbDBConifg
            // 
            this.sbDBConifg.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDBConifg.Appearance.Options.UseFont = true;
            this.sbDBConifg.Location = new System.Drawing.Point(606, 36);
            this.sbDBConifg.Name = "sbDBConifg";
            this.sbDBConifg.Size = new System.Drawing.Size(145, 26);
            this.sbDBConifg.TabIndex = 2;
            this.sbDBConifg.Text = "配置数据库";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "请选择目标数据库：";
            // 
            // teConnectString
            // 
            this.teConnectString.Enabled = false;
            this.teConnectString.Location = new System.Drawing.Point(15, 62);
            this.teConnectString.Name = "teConnectString";
            this.teConnectString.Size = new System.Drawing.Size(509, 64);
            this.teConnectString.TabIndex = 5;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.deCreateDate);
            this.groupControl3.Controls.Add(this.sbGenerateCode);
            this.groupControl3.Controls.Add(this.teCopyright);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.teCreator);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.teSlnName);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl3.Location = new System.Drawing.Point(525, 132);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(241, 294);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "代码配置";
            // 
            // deCreateDate
            // 
            this.deCreateDate.EditValue = null;
            this.deCreateDate.Location = new System.Drawing.Point(14, 153);
            this.deCreateDate.Name = "deCreateDate";
            this.deCreateDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreateDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deCreateDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deCreateDate.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.deCreateDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCreateDate.Size = new System.Drawing.Size(212, 21);
            this.deCreateDate.TabIndex = 8;
            // 
            // sbGenerateCode
            // 
            this.sbGenerateCode.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbGenerateCode.Appearance.Options.UseFont = true;
            this.sbGenerateCode.Location = new System.Drawing.Point(15, 262);
            this.sbGenerateCode.Name = "sbGenerateCode";
            this.sbGenerateCode.Size = new System.Drawing.Size(212, 26);
            this.sbGenerateCode.TabIndex = 11;
            this.sbGenerateCode.Text = "代码生成";
            this.sbGenerateCode.Click += new System.EventHandler(this.sbGenerateCode_Click);
            // 
            // teCopyright
            // 
            this.teCopyright.Location = new System.Drawing.Point(14, 200);
            this.teCopyright.Name = "teCopyright";
            this.teCopyright.Size = new System.Drawing.Size(213, 21);
            this.teCopyright.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 180);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "版权所属：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "创建时刻：";
            // 
            // teCreator
            // 
            this.teCreator.Location = new System.Drawing.Point(14, 106);
            this.teCreator.Name = "teCreator";
            this.teCreator.Size = new System.Drawing.Size(212, 21);
            this.teCreator.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "创建人：";
            // 
            // teSlnName
            // 
            this.teSlnName.Location = new System.Drawing.Point(15, 59);
            this.teSlnName.Name = "teSlnName";
            this.teSlnName.Size = new System.Drawing.Size(212, 21);
            this.teSlnName.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "项目名称：";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.ckDBTableList);
            this.groupControl4.Controls.Add(this.panelControl1);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(0, 132);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(525, 294);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "数据表选择";
            // 
            // ckDBTableList
            // 
            this.ckDBTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckDBTableList.HorizontalScrollbar = true;
            this.ckDBTableList.Location = new System.Drawing.Point(2, 23);
            this.ckDBTableList.MultiColumn = true;
            this.ckDBTableList.Name = "ckDBTableList";
            this.ckDBTableList.Size = new System.Drawing.Size(521, 235);
            this.ckDBTableList.TabIndex = 10;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sbtnDBTableReverseCheck);
            this.panelControl1.Controls.Add(this.sbtnDBTableNoneCheck);
            this.panelControl1.Controls.Add(this.sbtnDBTableAllCheck);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 258);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(521, 34);
            this.panelControl1.TabIndex = 11;
            // 
            // sbtnDBTableAllCheck
            // 
            this.sbtnDBTableAllCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnDBTableAllCheck.Appearance.Options.UseFont = true;
            this.sbtnDBTableAllCheck.Location = new System.Drawing.Point(4, 4);
            this.sbtnDBTableAllCheck.Name = "sbtnDBTableAllCheck";
            this.sbtnDBTableAllCheck.Size = new System.Drawing.Size(84, 26);
            this.sbtnDBTableAllCheck.TabIndex = 12;
            this.sbtnDBTableAllCheck.Text = "全选";
            this.sbtnDBTableAllCheck.Click += new System.EventHandler(this.sbtnDBTableAllCheck_Click);
            // 
            // sbtnDBTableNoneCheck
            // 
            this.sbtnDBTableNoneCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnDBTableNoneCheck.Appearance.Options.UseFont = true;
            this.sbtnDBTableNoneCheck.Location = new System.Drawing.Point(94, 4);
            this.sbtnDBTableNoneCheck.Name = "sbtnDBTableNoneCheck";
            this.sbtnDBTableNoneCheck.Size = new System.Drawing.Size(84, 26);
            this.sbtnDBTableNoneCheck.TabIndex = 13;
            this.sbtnDBTableNoneCheck.Text = "全不选";
            this.sbtnDBTableNoneCheck.Click += new System.EventHandler(this.sbtnDBTableNoneCheck_Click);
            // 
            // sbtnDBTableReverseCheck
            // 
            this.sbtnDBTableReverseCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnDBTableReverseCheck.Appearance.Options.UseFont = true;
            this.sbtnDBTableReverseCheck.Location = new System.Drawing.Point(184, 4);
            this.sbtnDBTableReverseCheck.Name = "sbtnDBTableReverseCheck";
            this.sbtnDBTableReverseCheck.Size = new System.Drawing.Size(84, 26);
            this.sbtnDBTableReverseCheck.TabIndex = 14;
            this.sbtnDBTableReverseCheck.Text = "反选";
            this.sbtnDBTableReverseCheck.Click += new System.EventHandler(this.sbtnDBTableReverseCheck_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 426);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iCat代码生成器";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueditDBList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teConnectString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCopyright.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSlnName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckDBTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.CheckedListBoxControl ckDBTableList;
        private DevExpress.XtraEditors.SimpleButton sbDBConifg;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbGenerateCode;
        private DevExpress.XtraEditors.TextEdit teCopyright;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit teCreator;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit teSlnName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deCreateDate;
        private DevExpress.XtraEditors.MemoEdit teConnectString;
        private DevExpress.XtraEditors.LookUpEdit lueditDBList;
        private DevExpress.XtraEditors.LabelControl lbcDBConnectStatus;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.SimpleButton sbtnRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnDBTableReverseCheck;
        private DevExpress.XtraEditors.SimpleButton sbtnDBTableNoneCheck;
        private DevExpress.XtraEditors.SimpleButton sbtnDBTableAllCheck;
    }
}

