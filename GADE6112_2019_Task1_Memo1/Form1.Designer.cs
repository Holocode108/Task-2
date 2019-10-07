namespace GADETask2
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
			this.components = new System.ComponentModel.Container();
			this.grpMap = new System.Windows.Forms.GroupBox();
			this.lblRound = new System.Windows.Forms.Label();
			this.btnPause = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtInfo = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SaveBttn = new System.Windows.Forms.Button();
			this.ReadBttn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// grpMap
			// 
			this.grpMap.Location = new System.Drawing.Point(51, 45);
			this.grpMap.Name = "grpMap";
			this.grpMap.Size = new System.Drawing.Size(687, 449);
			this.grpMap.TabIndex = 0;
			this.grpMap.TabStop = false;
			// 
			// lblRound
			// 
			this.lblRound.AutoSize = true;
			this.lblRound.Location = new System.Drawing.Point(762, 59);
			this.lblRound.Name = "lblRound";
			this.lblRound.Size = new System.Drawing.Size(45, 13);
			this.lblRound.TabIndex = 1;
			this.lblRound.Text = "Round: ";
			this.lblRound.Click += new System.EventHandler(this.lblRound_Click);
			// 
			// btnPause
			// 
			this.btnPause.Location = new System.Drawing.Point(663, 514);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(75, 23);
			this.btnPause.TabIndex = 2;
			this.btnPause.Text = "Pause";
			this.btnPause.UseVisualStyleBackColor = true;
			this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(572, 514);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
			// 
			// txtInfo
			// 
			this.txtInfo.Location = new System.Drawing.Point(763, 89);
			this.txtInfo.Multiline = true;
			this.txtInfo.Name = "txtInfo";
			this.txtInfo.Size = new System.Drawing.Size(271, 405);
			this.txtInfo.TabIndex = 4;
			this.txtInfo.TextChanged += new System.EventHandler(this.TxtInfo_TextChanged);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// SaveBttn
			// 
			this.SaveBttn.Location = new System.Drawing.Point(972, 513);
			this.SaveBttn.Name = "SaveBttn";
			this.SaveBttn.Size = new System.Drawing.Size(75, 23);
			this.SaveBttn.TabIndex = 5;
			this.SaveBttn.Text = "Save";
			this.SaveBttn.UseVisualStyleBackColor = true;
			this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
			// 
			// ReadBttn
			// 
			this.ReadBttn.Location = new System.Drawing.Point(972, 542);
			this.ReadBttn.Name = "ReadBttn";
			this.ReadBttn.Size = new System.Drawing.Size(75, 23);
			this.ReadBttn.TabIndex = 5;
			this.ReadBttn.Text = "Read";
			this.ReadBttn.UseVisualStyleBackColor = true;
			this.ReadBttn.Click += new System.EventHandler(this.ReadBttn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1076, 697);
			this.Controls.Add(this.ReadBttn);
			this.Controls.Add(this.SaveBttn);
			this.Controls.Add(this.txtInfo);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.lblRound);
			this.Controls.Add(this.grpMap);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button SaveBttn;
    private System.Windows.Forms.Button ReadBttn;
  }
}

