namespace WeponForceTestForDNF
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.CanHuamDisturb = new System.Windows.Forms.CheckBox();
            this.WeponSourceList = new System.Windows.Forms.RichTextBox();
            this.ResultShow = new System.Windows.Forms.RichTextBox();
            this.CanUserAdvanceC = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Round = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.securityCount = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CanHuamDisturb
            // 
            this.CanHuamDisturb.AutoSize = true;
            this.CanHuamDisturb.Location = new System.Drawing.Point(27, 12);
            this.CanHuamDisturb.Name = "CanHuamDisturb";
            this.CanHuamDisturb.Size = new System.Drawing.Size(96, 16);
            this.CanHuamDisturb.TabIndex = 1;
            this.CanHuamDisturb.Text = "是否人工干扰";
            this.CanHuamDisturb.UseVisualStyleBackColor = true;
            // 
            // WeponSourceList
            // 
            this.WeponSourceList.Location = new System.Drawing.Point(27, 57);
            this.WeponSourceList.Name = "WeponSourceList";
            this.WeponSourceList.Size = new System.Drawing.Size(211, 255);
            this.WeponSourceList.TabIndex = 2;
            this.WeponSourceList.Text = "";
            // 
            // ResultShow
            // 
            this.ResultShow.Location = new System.Drawing.Point(281, 57);
            this.ResultShow.Name = "ResultShow";
            this.ResultShow.Size = new System.Drawing.Size(621, 255);
            this.ResultShow.TabIndex = 3;
            this.ResultShow.Text = "";
            // 
            // CanUserAdvanceC
            // 
            this.CanUserAdvanceC.AutoSize = true;
            this.CanUserAdvanceC.Location = new System.Drawing.Point(157, 12);
            this.CanUserAdvanceC.Name = "CanUserAdvanceC";
            this.CanUserAdvanceC.Size = new System.Drawing.Size(72, 16);
            this.CanUserAdvanceC.TabIndex = 4;
            this.CanUserAdvanceC.Text = "AdvanceC";
            this.CanUserAdvanceC.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "ReSet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(580, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "循环测试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Round
            // 
            this.Round.Location = new System.Drawing.Point(580, 339);
            this.Round.Name = "Round";
            this.Round.Size = new System.Drawing.Size(100, 21);
            this.Round.TabIndex = 7;
            this.Round.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // securityCount
            // 
            this.securityCount.Location = new System.Drawing.Point(700, 339);
            this.securityCount.Name = "securityCount";
            this.securityCount.Size = new System.Drawing.Size(40, 21);
            this.securityCount.TabIndex = 7;
            this.securityCount.Text = "8";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(27, 366);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "彩票";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 436);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.securityCount);
            this.Controls.Add(this.Round);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CanUserAdvanceC);
            this.Controls.Add(this.ResultShow);
            this.Controls.Add(this.WeponSourceList);
            this.Controls.Add(this.CanHuamDisturb);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CanHuamDisturb;
        private System.Windows.Forms.RichTextBox WeponSourceList;
        private System.Windows.Forms.RichTextBox ResultShow;
        private System.Windows.Forms.CheckBox CanUserAdvanceC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox Round;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox securityCount;
        private System.Windows.Forms.Button button4;
    }
}

