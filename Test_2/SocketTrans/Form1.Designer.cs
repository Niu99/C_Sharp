
namespace SocketTrans
{
    partial class Form1
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
            this.richtxtResult = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBinUpgrade = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.btnREGRead = new System.Windows.Forms.Button();
            this.btnDMA = new System.Windows.Forms.Button();
            this.btnBinSelect = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtADDR = new System.Windows.Forms.TextBox();
            this.btnREGWrite = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richtxtResult
            // 
            this.richtxtResult.Location = new System.Drawing.Point(13, 382);
            this.richtxtResult.Name = "richtxtResult";
            this.richtxtResult.Size = new System.Drawing.Size(612, 151);
            this.richtxtResult.TabIndex = 8;
            this.richtxtResult.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(277, 354);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Result";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Length";
            // 
            // btnBinUpgrade
            // 
            this.btnBinUpgrade.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBinUpgrade.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBinUpgrade.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBinUpgrade.Location = new System.Drawing.Point(155, 275);
            this.btnBinUpgrade.Name = "btnBinUpgrade";
            this.btnBinUpgrade.Size = new System.Drawing.Size(128, 31);
            this.btnBinUpgrade.TabIndex = 4;
            this.btnBinUpgrade.Text = "BIN文件升级";
            this.btnBinUpgrade.UseVisualStyleBackColor = false;
            this.btnBinUpgrade.Click += new System.EventHandler(this.btnBinUpgrade_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(13, 237);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(270, 26);
            this.txtPath.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnBinUpgrade);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.txtLength);
            this.groupBox2.Controls.Add(this.btnREGRead);
            this.groupBox2.Controls.Add(this.btnDMA);
            this.groupBox2.Controls.Add(this.btnBinSelect);
            this.groupBox2.Controls.Add(this.txtData);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtADDR);
            this.groupBox2.Controls.Add(this.btnREGWrite);
            this.groupBox2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(316, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 326);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试功能项";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(155, 50);
            this.txtLength.Margin = new System.Windows.Forms.Padding(4);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(128, 26);
            this.txtLength.TabIndex = 11;
            // 
            // btnREGRead
            // 
            this.btnREGRead.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnREGRead.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnREGRead.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnREGRead.Location = new System.Drawing.Point(13, 183);
            this.btnREGRead.Name = "btnREGRead";
            this.btnREGRead.Size = new System.Drawing.Size(128, 31);
            this.btnREGRead.TabIndex = 9;
            this.btnREGRead.Text = "REG读";
            this.btnREGRead.UseVisualStyleBackColor = false;
            this.btnREGRead.Click += new System.EventHandler(this.btnREGRead_Click);
            // 
            // btnDMA
            // 
            this.btnDMA.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDMA.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDMA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDMA.Location = new System.Drawing.Point(13, 50);
            this.btnDMA.Name = "btnDMA";
            this.btnDMA.Size = new System.Drawing.Size(128, 31);
            this.btnDMA.TabIndex = 0;
            this.btnDMA.Text = "DMA写/读";
            this.btnDMA.UseVisualStyleBackColor = false;
            this.btnDMA.Click += new System.EventHandler(this.btnDMA_Click);
            // 
            // btnBinSelect
            // 
            this.btnBinSelect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBinSelect.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBinSelect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBinSelect.Location = new System.Drawing.Point(13, 275);
            this.btnBinSelect.Name = "btnBinSelect";
            this.btnBinSelect.Size = new System.Drawing.Size(128, 31);
            this.btnBinSelect.TabIndex = 8;
            this.btnBinSelect.Text = "BIN文件选择";
            this.btnBinSelect.UseVisualStyleBackColor = false;
            this.btnBinSelect.Click += new System.EventHandler(this.btnBinSelect_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(155, 183);
            this.txtData.Margin = new System.Windows.Forms.Padding(4);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(128, 26);
            this.txtData.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "ADDR";
            // 
            // txtADDR
            // 
            this.txtADDR.Location = new System.Drawing.Point(155, 119);
            this.txtADDR.Margin = new System.Windows.Forms.Padding(4);
            this.txtADDR.Name = "txtADDR";
            this.txtADDR.Size = new System.Drawing.Size(128, 26);
            this.txtADDR.TabIndex = 3;
            // 
            // btnREGWrite
            // 
            this.btnREGWrite.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnREGWrite.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnREGWrite.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnREGWrite.Location = new System.Drawing.Point(13, 118);
            this.btnREGWrite.Name = "btnREGWrite";
            this.btnREGWrite.Size = new System.Drawing.Size(128, 31);
            this.btnREGWrite.TabIndex = 2;
            this.btnREGWrite.Text = "REG写";
            this.btnREGWrite.UseVisualStyleBackColor = false;
            this.btnREGWrite.Click += new System.EventHandler(this.btnREGWrite_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConnect.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConnect.Location = new System.Drawing.Point(96, 125);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(115, 32);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(59, 64);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(198, 26);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "5025";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(280, 326);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(59, 25);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(198, 26);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.1.111";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 537);
            this.Controls.Add(this.richtxtResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richtxtResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBinUpgrade;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Button btnREGRead;
        private System.Windows.Forms.Button btnDMA;
        private System.Windows.Forms.Button btnBinSelect;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtADDR;
        private System.Windows.Forms.Button btnREGWrite;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
    }
}

