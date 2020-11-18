namespace Lab5_WindowApllication
{
    partial class frmTimKiem
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
            this.txbTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.rdMa = new System.Windows.Forms.RadioButton();
            this.rdLop = new System.Windows.Forms.RadioButton();
            this.rdTen = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txbTim
            // 
            this.txbTim.Location = new System.Drawing.Point(107, 92);
            this.txbTim.Name = "txbTim";
            this.txbTim.Size = new System.Drawing.Size(263, 22);
            this.txbTim.TabIndex = 0;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(398, 92);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(88, 23);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tim";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // rdMa
            // 
            this.rdMa.AutoSize = true;
            this.rdMa.Location = new System.Drawing.Point(107, 38);
            this.rdMa.Name = "rdMa";
            this.rdMa.Size = new System.Drawing.Size(85, 21);
            this.rdMa.TabIndex = 2;
            this.rdMa.TabStop = true;
            this.rdMa.Text = "Theo Mã";
            this.rdMa.UseVisualStyleBackColor = true;
            // 
            // rdLop
            // 
            this.rdLop.AutoSize = true;
            this.rdLop.Location = new System.Drawing.Point(398, 38);
            this.rdLop.Name = "rdLop";
            this.rdLop.Size = new System.Drawing.Size(90, 21);
            this.rdLop.TabIndex = 3;
            this.rdLop.TabStop = true;
            this.rdLop.Text = "Theo Lớp";
            this.rdLop.UseVisualStyleBackColor = true;
            // 
            // rdTen
            // 
            this.rdTen.AutoSize = true;
            this.rdTen.Location = new System.Drawing.Point(236, 38);
            this.rdTen.Name = "rdTen";
            this.rdTen.Size = new System.Drawing.Size(91, 21);
            this.rdTen.TabIndex = 4;
            this.rdTen.TabStop = true;
            this.rdTen.Text = "Theo Tên";
            this.rdTen.UseVisualStyleBackColor = true;
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 169);
            this.Controls.Add(this.rdTen);
            this.Controls.Add(this.rdLop);
            this.Controls.Add(this.rdMa);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txbTim);
            this.Name = "frmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimKiem";
            this.Load += new System.EventHandler(this.frmTimKiem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.RadioButton rdMa;
        private System.Windows.Forms.RadioButton rdLop;
        private System.Windows.Forms.RadioButton rdTen;
    }
}