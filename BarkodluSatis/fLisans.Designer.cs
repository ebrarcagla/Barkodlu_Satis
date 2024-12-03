namespace BarkodluSatis
{
    partial class fLisans
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
            this.tLisansNo = new BarkodluSatis.tNumeric();
            this.lSandart1 = new BarkodluSatis.lSandart();
            this.lKontrolNo = new BarkodluSatis.lSandart();
            this.bTamam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tLisansNo
            // 
            this.tLisansNo.BackColor = System.Drawing.Color.White;
            this.tLisansNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tLisansNo.Location = new System.Drawing.Point(81, 112);
            this.tLisansNo.Name = "tLisansNo";
            this.tLisansNo.Size = new System.Drawing.Size(118, 26);
            this.tLisansNo.TabIndex = 0;
            this.tLisansNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lSandart1
            // 
            this.lSandart1.AutoSize = true;
            this.lSandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lSandart1.ForeColor = System.Drawing.Color.DarkCyan;
            this.lSandart1.Location = new System.Drawing.Point(77, 41);
            this.lSandart1.Name = "lSandart1";
            this.lSandart1.Size = new System.Drawing.Size(111, 20);
            this.lSandart1.TabIndex = 1;
            this.lSandart1.Text = "KONTROL NO";
            // 
            // lKontrolNo
            // 
            this.lKontrolNo.AutoSize = true;
            this.lKontrolNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lKontrolNo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lKontrolNo.Location = new System.Drawing.Point(81, 65);
            this.lKontrolNo.Name = "lKontrolNo";
            this.lKontrolNo.Size = new System.Drawing.Size(78, 20);
            this.lKontrolNo.TabIndex = 2;
            this.lKontrolNo.Text = "lSandart2";
            // 
            // bTamam
            // 
            this.bTamam.Location = new System.Drawing.Point(124, 144);
            this.bTamam.Name = "bTamam";
            this.bTamam.Size = new System.Drawing.Size(75, 23);
            this.bTamam.TabIndex = 3;
            this.bTamam.Text = "Tamam";
            this.bTamam.UseVisualStyleBackColor = true;
            this.bTamam.Click += new System.EventHandler(this.bTamam_Click);
            // 
            // fLisans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 248);
            this.Controls.Add(this.bTamam);
            this.Controls.Add(this.lKontrolNo);
            this.Controls.Add(this.lSandart1);
            this.Controls.Add(this.tLisansNo);
            this.Name = "fLisans";
            this.Text = "LİSANS İŞLEMİ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private tNumeric tLisansNo;
        private lSandart lSandart1;
        private System.Windows.Forms.Button bTamam;
        internal lSandart lKontrolNo;
    }
}