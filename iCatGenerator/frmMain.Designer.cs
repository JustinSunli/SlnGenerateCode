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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.sbDBConifg = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.icbDBList = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
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
            this.deCreateDate = new DevExpress.XtraEditors.DateEdit();
            this.teCreateTime = new DevExpress.XtraEditors.TimeEdit();
            this.textEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbDBList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCopyright.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSlnName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckDBTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.sbDBConifg);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.icbDBList);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(720, 115);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "数据库";
            // 
            // sbDBConifg
            // 
            this.sbDBConifg.Location = new System.Drawing.Point(566, 34);
            this.sbDBConifg.Name = "sbDBConifg";
            this.sbDBConifg.Size = new System.Drawing.Size(140, 22);
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
            // icbDBList
            // 
            this.icbDBList.Location = new System.Drawing.Point(148, 35);
            this.icbDBList.Name = "icbDBList";
            this.icbDBList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbDBList.Size = new System.Drawing.Size(412, 21);
            this.icbDBList.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.teCreateTime);
            this.groupControl3.Controls.Add(this.deCreateDate);
            this.groupControl3.Controls.Add(this.sbGenerateCode);
            this.groupControl3.Controls.Add(this.teCopyright);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.teCreator);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.teSlnName);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl3.Location = new System.Drawing.Point(0, 115);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(241, 311);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "代码配置";
            // 
            // sbGenerateCode
            // 
            this.sbGenerateCode.Location = new System.Drawing.Point(15, 240);
            this.sbGenerateCode.Name = "sbGenerateCode";
            this.sbGenerateCode.Size = new System.Drawing.Size(212, 22);
            this.sbGenerateCode.TabIndex = 10;
            this.sbGenerateCode.Text = "代码生成";
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
            this.teCreator.TabIndex = 5;
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
            this.teSlnName.TabIndex = 3;
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
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(241, 115);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(479, 311);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "数据表选择";
            // 
            // ckDBTableList
            // 
            this.ckDBTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckDBTableList.Location = new System.Drawing.Point(2, 23);
            this.ckDBTableList.Name = "ckDBTableList";
            this.ckDBTableList.Size = new System.Drawing.Size(475, 286);
            this.ckDBTableList.TabIndex = 0;
            // 
            // deCreateDate
            // 
            this.deCreateDate.EditValue = null;
            this.deCreateDate.Location = new System.Drawing.Point(14, 153);
            this.deCreateDate.Name = "deCreateDate";
            this.deCreateDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreateDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCreateDate.Size = new System.Drawing.Size(108, 21);
            this.deCreateDate.TabIndex = 11;
            // 
            // teCreateTime
            // 
            this.teCreateTime.EditValue = new System.DateTime(2014, 8, 5, 0, 0, 0, 0);
            this.teCreateTime.Location = new System.Drawing.Point(126, 153);
            this.teCreateTime.Name = "teCreateTime";
            this.teCreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teCreateTime.Size = new System.Drawing.Size(100, 21);
            this.teCreateTime.TabIndex = 12;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(148, 62);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(558, 38);
            this.textEdit1.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 426);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iCat代码生成器";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbDBList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCopyright.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSlnName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckDBTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.CheckedListBoxControl ckDBTableList;
        private DevExpress.XtraEditors.SimpleButton sbDBConifg;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbDBList;
        private DevExpress.XtraEditors.SimpleButton sbGenerateCode;
        private DevExpress.XtraEditors.TextEdit teCopyright;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit teCreator;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit teSlnName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TimeEdit teCreateTime;
        private DevExpress.XtraEditors.DateEdit deCreateDate;
        private DevExpress.XtraEditors.MemoEdit textEdit1;
    }
}

