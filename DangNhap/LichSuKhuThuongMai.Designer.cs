namespace DangNhap
{
    partial class LichSuKhuThuongMai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichSuKhuThuongMai));
            this.TXB_doxe = new System.Windows.Forms.TextBox();
            this.TXB_dv = new System.Windows.Forms.TextBox();
            this.LB_doxe = new System.Windows.Forms.Label();
            this.TXB_congno = new System.Windows.Forms.TextBox();
            this.LB_congno = new System.Windows.Forms.Label();
            this.LB_phidichvu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXB_doxe
            // 
            resources.ApplyResources(this.TXB_doxe, "TXB_doxe");
            this.TXB_doxe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            this.TXB_doxe.ForeColor = System.Drawing.Color.White;
            this.TXB_doxe.Name = "TXB_doxe";
            // 
            // TXB_dv
            // 
            resources.ApplyResources(this.TXB_dv, "TXB_dv");
            this.TXB_dv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            this.TXB_dv.ForeColor = System.Drawing.Color.White;
            this.TXB_dv.Name = "TXB_dv";
            // 
            // LB_doxe
            // 
            resources.ApplyResources(this.LB_doxe, "LB_doxe");
            this.LB_doxe.ForeColor = System.Drawing.Color.White;
            this.LB_doxe.Name = "LB_doxe";
            // 
            // TXB_congno
            // 
            resources.ApplyResources(this.TXB_congno, "TXB_congno");
            this.TXB_congno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            this.TXB_congno.ForeColor = System.Drawing.Color.White;
            this.TXB_congno.Name = "TXB_congno";
            // 
            // LB_congno
            // 
            resources.ApplyResources(this.LB_congno, "LB_congno");
            this.LB_congno.ForeColor = System.Drawing.Color.White;
            this.LB_congno.Name = "LB_congno";
            // 
            // LB_phidichvu
            // 
            resources.ApplyResources(this.LB_phidichvu, "LB_phidichvu");
            this.LB_phidichvu.ForeColor = System.Drawing.Color.White;
            this.LB_phidichvu.Name = "LB_phidichvu";
            // 
            // LichSuKhuThuongMai
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.TXB_doxe);
            this.Controls.Add(this.TXB_dv);
            this.Controls.Add(this.LB_doxe);
            this.Controls.Add(this.TXB_congno);
            this.Controls.Add(this.LB_congno);
            this.Controls.Add(this.LB_phidichvu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LichSuKhuThuongMai";
            this.Load += new System.EventHandler(this.LichSuKhuThuongMai_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TXB_doxe;
        private System.Windows.Forms.TextBox TXB_dv;
        private System.Windows.Forms.Label LB_doxe;
        private System.Windows.Forms.TextBox TXB_congno;
        private System.Windows.Forms.Label LB_congno;
        private System.Windows.Forms.Label LB_phidichvu;
    }
}