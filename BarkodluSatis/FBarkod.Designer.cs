
namespace BarkodluSatis
{
    partial class FBarkod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBarkod));
            this.label1 = new System.Windows.Forms.Label();
            this.TCode = new System.Windows.Forms.TextBox();
            this.BBarkod = new System.Windows.Forms.Button();
            this.BQr = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod No:";
            // 
            // TCode
            // 
            this.TCode.Location = new System.Drawing.Point(97, 14);
            this.TCode.Name = "TCode";
            this.TCode.Size = new System.Drawing.Size(249, 26);
            this.TCode.TabIndex = 1;
            // 
            // BBarkod
            // 
            this.BBarkod.Location = new System.Drawing.Point(97, 46);
            this.BBarkod.Name = "BBarkod";
            this.BBarkod.Size = new System.Drawing.Size(106, 35);
            this.BBarkod.TabIndex = 2;
            this.BBarkod.Text = "Oluştur";
            this.BBarkod.UseVisualStyleBackColor = true;
            this.BBarkod.Click += new System.EventHandler(this.BBarkod_Click);
            // 
            // BQr
            // 
            this.BQr.Location = new System.Drawing.Point(240, 46);
            this.BQr.Name = "BQr";
            this.BQr.Size = new System.Drawing.Size(106, 35);
            this.BQr.TabIndex = 3;
            this.BQr.Text = "Oto";
            this.BQr.UseVisualStyleBackColor = true;
            this.BQr.Click += new System.EventHandler(this.BQr_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(97, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 47);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FBarkod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(391, 109);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BQr);
            this.Controls.Add(this.BBarkod);
            this.Controls.Add(this.TCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FBarkod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barkod Oluştur";
            this.Load += new System.EventHandler(this.FBarkod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TCode;
        private System.Windows.Forms.Button BBarkod;
        private System.Windows.Forms.Button BQr;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}