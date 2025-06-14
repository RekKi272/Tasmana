namespace DangNhap
{
    partial class ThemQuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemQuanLy));
            this.LB_themmoi = new System.Windows.Forms.Label();
            this.LB_maphongban = new System.Windows.Forms.Label();
            this.CBB_phongban = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBB_nhanvien = new System.Windows.Forms.ComboBox();
            this.BTN_ok = new Guna.UI.WinForms.GunaGradientButton();
            this.PN_main = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_thoat = new Guna.UI.WinForms.GunaGradientButton();
            this.PN_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_themmoi
            // 
            resources.ApplyResources(this.LB_themmoi, "LB_themmoi");
            this.LB_themmoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LB_themmoi.Name = "LB_themmoi";
            // 
            // LB_maphongban
            // 
            resources.ApplyResources(this.LB_maphongban, "LB_maphongban");
            this.LB_maphongban.ForeColor = System.Drawing.Color.White;
            this.LB_maphongban.Name = "LB_maphongban";
            // 
            // CBB_phongban
            // 
            this.CBB_phongban.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.CBB_phongban, "CBB_phongban");
            this.CBB_phongban.ForeColor = System.Drawing.Color.White;
            this.CBB_phongban.FormattingEnabled = true;
            this.CBB_phongban.Name = "CBB_phongban";
            this.CBB_phongban.SelectedIndexChanged += new System.EventHandler(this.CBB_phongban_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // CBB_nhanvien
            // 
            this.CBB_nhanvien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.CBB_nhanvien, "CBB_nhanvien");
            this.CBB_nhanvien.ForeColor = System.Drawing.Color.White;
            this.CBB_nhanvien.FormattingEnabled = true;
            this.CBB_nhanvien.Name = "CBB_nhanvien";
            // 
            // BTN_ok
            // 
            this.BTN_ok.Animated = true;
            this.BTN_ok.AnimationHoverSpeed = 0.3F;
            this.BTN_ok.AnimationSpeed = 0.03F;
            this.BTN_ok.BackColor = System.Drawing.Color.Transparent;
            this.BTN_ok.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.BTN_ok.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(90)))), ((int)(((byte)(184)))));
            this.BTN_ok.BorderColor = System.Drawing.Color.Black;
            this.BTN_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_ok.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_ok.FocusedColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BTN_ok, "BTN_ok");
            this.BTN_ok.ForeColor = System.Drawing.Color.White;
            this.BTN_ok.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.BTN_ok.Image = null;
            this.BTN_ok.ImageSize = new System.Drawing.Size(20, 20);
            this.BTN_ok.Name = "BTN_ok";
            this.BTN_ok.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(40)))), ((int)(((byte)(184)))));
            this.BTN_ok.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(40)))), ((int)(((byte)(184)))));
            this.BTN_ok.OnHoverBorderColor = System.Drawing.Color.White;
            this.BTN_ok.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_ok.OnHoverImage = null;
            this.BTN_ok.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_ok.Radius = 5;
            this.BTN_ok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_ok.Click += new System.EventHandler(this.BTN_ok_Click);
            // 
            // PN_main
            // 
            this.PN_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.PN_main.Controls.Add(this.panel5);
            this.PN_main.Controls.Add(this.BTN_ok);
            this.PN_main.Controls.Add(this.LB_maphongban);
            this.PN_main.Controls.Add(this.CBB_phongban);
            this.PN_main.Controls.Add(this.label1);
            this.PN_main.Controls.Add(this.CBB_nhanvien);
            resources.ApplyResources(this.PN_main, "PN_main");
            this.PN_main.Name = "PN_main";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // BTN_thoat
            // 
            this.BTN_thoat.AnimationHoverSpeed = 0.5F;
            this.BTN_thoat.AnimationSpeed = 0.03F;
            this.BTN_thoat.BackColor = System.Drawing.Color.Transparent;
            this.BTN_thoat.BaseColor1 = System.Drawing.Color.Transparent;
            this.BTN_thoat.BaseColor2 = System.Drawing.Color.Transparent;
            this.BTN_thoat.BorderColor = System.Drawing.Color.Transparent;
            this.BTN_thoat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_thoat.FocusedColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BTN_thoat, "BTN_thoat");
            this.BTN_thoat.ForeColor = System.Drawing.Color.Black;
            this.BTN_thoat.Image = ((System.Drawing.Image)(resources.GetObject("BTN_thoat.Image")));
            this.BTN_thoat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_thoat.ImageSize = new System.Drawing.Size(10, 10);
            this.BTN_thoat.Name = "BTN_thoat";
            this.BTN_thoat.OnHoverBaseColor1 = System.Drawing.Color.Red;
            this.BTN_thoat.OnHoverBaseColor2 = System.Drawing.Color.Red;
            this.BTN_thoat.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BTN_thoat.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_thoat.OnHoverImage = null;
            this.BTN_thoat.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_thoat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_thoat.Click += new System.EventHandler(this.BTN_thoat_Click);
            // 
            // ThemQuanLy
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTN_thoat);
            this.Controls.Add(this.LB_themmoi);
            this.Controls.Add(this.PN_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThemQuanLy";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ThemQuanLy_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ThemQuanLy_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ThemQuanLy_MouseUp);
            this.PN_main.ResumeLayout(false);
            this.PN_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_themmoi;
        private System.Windows.Forms.Label LB_maphongban;
        private System.Windows.Forms.ComboBox CBB_phongban;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBB_nhanvien;
        private Guna.UI.WinForms.GunaGradientButton BTN_ok;
        private System.Windows.Forms.Panel PN_main;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaGradientButton BTN_thoat;
    }
}