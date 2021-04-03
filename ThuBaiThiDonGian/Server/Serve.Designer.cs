namespace Server
{
    partial class Serve
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
            this.btnChatAll = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lsvMain = new System.Windows.Forms.ListView();
            this.btnSendStudents = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSetTime = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChatAll
            // 
            this.btnChatAll.Location = new System.Drawing.Point(464, 393);
            this.btnChatAll.Name = "btnChatAll";
            this.btnChatAll.Size = new System.Drawing.Size(102, 45);
            this.btnChatAll.TabIndex = 5;
            this.btnChatAll.Text = "Chat All";
            this.btnChatAll.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(102, 393);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(356, 45);
            this.txtInput.TabIndex = 4;
            // 
            // lsvMain
            // 
            this.lsvMain.Location = new System.Drawing.Point(102, 12);
            this.lsvMain.Name = "lsvMain";
            this.lsvMain.Size = new System.Drawing.Size(464, 375);
            this.lsvMain.TabIndex = 3;
            this.lsvMain.UseCompatibleStateImageBehavior = false;
            this.lsvMain.View = System.Windows.Forms.View.List;
            // 
            // btnSendStudents
            // 
            this.btnSendStudents.Location = new System.Drawing.Point(12, 12);
            this.btnSendStudents.Name = "btnSendStudents";
            this.btnSendStudents.Size = new System.Drawing.Size(84, 45);
            this.btnSendStudents.TabIndex = 6;
            this.btnSendStudents.Text = "Send List";
            this.btnSendStudents.UseVisualStyleBackColor = true;
            this.btnSendStudents.Click += new System.EventHandler(this.btnSendStudents_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(12, 179);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(84, 45);
            this.btnBegin.TabIndex = 7;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(12, 230);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(84, 45);
            this.btnFinish.TabIndex = 8;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(12, 63);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(84, 45);
            this.btnSendFile.TabIndex = 9;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTimeLeft);
            this.groupBox1.Location = new System.Drawing.Point(12, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 64);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Left:";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(16, 26);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(54, 20);
            this.lblTimeLeft.TabIndex = 11;
            this.lblTimeLeft.Text = "00:00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSetTime);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(84, 59);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Time:";
            // 
            // txtSetTime
            // 
            this.txtSetTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetTime.Location = new System.Drawing.Point(6, 19);
            this.txtSetTime.Name = "txtSetTime";
            this.txtSetTime.Size = new System.Drawing.Size(72, 31);
            this.txtSetTime.TabIndex = 13;
            this.txtSetTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Serve
            // 
            this.AcceptButton = this.btnChatAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.btnSendStudents);
            this.Controls.Add(this.btnChatAll);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lsvMain);
            this.Name = "Serve";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Serve_FormClosing);
            this.Load += new System.EventHandler(this.Serve_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChatAll;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ListView lsvMain;
        private System.Windows.Forms.Button btnSendStudents;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSetTime;
    }
}

