namespace iCatGenerator
{
    partial class frmGenInfor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenInfor));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.meditCodeInfor = new DevExpress.XtraEditors.MemoEdit();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnStartGen = new DevExpress.XtraEditors.SimpleButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.meditCodeInfor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "提示消息：";
            // 
            // meditCodeInfor
            // 
            this.meditCodeInfor.Location = new System.Drawing.Point(14, 51);
            this.meditCodeInfor.Name = "meditCodeInfor";
            this.meditCodeInfor.Properties.ReadOnly = true;
            this.meditCodeInfor.Size = new System.Drawing.Size(495, 208);
            this.meditCodeInfor.TabIndex = 1;
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbtnCancel.Appearance.Options.UseFont = true;
            this.sbtnCancel.Location = new System.Drawing.Point(54, 275);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(134, 30);
            this.sbtnCancel.TabIndex = 2;
            this.sbtnCancel.Text = "取消生成";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnStartGen
            // 
            this.sbtnStartGen.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbtnStartGen.Appearance.Options.UseFont = true;
            this.sbtnStartGen.Location = new System.Drawing.Point(331, 275);
            this.sbtnStartGen.Name = "sbtnStartGen";
            this.sbtnStartGen.Size = new System.Drawing.Size(134, 30);
            this.sbtnStartGen.TabIndex = 3;
            this.sbtnStartGen.Text = "开始生成";
            this.sbtnStartGen.Click += new System.EventHandler(this.sbtnStartGen_Click);
            // 
            // frmGenInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 320);
            this.Controls.Add(this.sbtnStartGen);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.meditCodeInfor);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenInfor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成向导";
            this.Load += new System.EventHandler(this.frmGenInfor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.meditCodeInfor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit meditCodeInfor;
        private DevExpress.XtraEditors.SimpleButton sbtnCancel;
        private DevExpress.XtraEditors.SimpleButton sbtnStartGen;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}