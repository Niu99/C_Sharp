
namespace LicenseTest
{
    partial class FormLicenseTestfalse
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRegistInfo = new System.Windows.Forms.Label();
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRegistInfo
            // 
            this.lbRegistInfo.AutoSize = true;
            this.lbRegistInfo.Location = new System.Drawing.Point(260, 80);
            this.lbRegistInfo.Name = "lbRegistInfo";
            this.lbRegistInfo.Size = new System.Drawing.Size(41, 12);
            this.lbRegistInfo.TabIndex = 0;
            this.lbRegistInfo.Text = "label1";
            // 
            // btnRegist
            // 
            this.btnRegist.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegist.Location = new System.Drawing.Point(243, 220);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(94, 33);
            this.btnRegist.TabIndex = 1;
            this.btnRegist.Text = "注册";
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(414, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormLicenseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.lbRegistInfo);
            this.Name = "FormLicenseTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormLicenseTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRegistInfo;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnSave;
    }
}

