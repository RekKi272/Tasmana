namespace DangNhap
{
    partial class FaceDetectLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceDetectLogin));
            this.PB_Camera = new System.Windows.Forms.PictureBox();
            this.PB_Capture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_Opencam = new System.Windows.Forms.Button();
            this.BTN_save = new System.Windows.Forms.Button();
            this.BTN_detect = new System.Windows.Forms.Button();
            this.TXB_MatKhau = new System.Windows.Forms.TextBox();
            this.TXB_userId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_login = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTN_close = new Guna.UI.WinForms.GunaButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Camera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Capture)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Camera
            // 
            this.PB_Camera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.PB_Camera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PB_Camera.Location = new System.Drawing.Point(29, 101);
            this.PB_Camera.Name = "PB_Camera";
            this.PB_Camera.Size = new System.Drawing.Size(610, 387);
            this.PB_Camera.TabIndex = 0;
            this.PB_Camera.TabStop = false;
            // 
            // PB_Capture
            // 
            this.PB_Capture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.PB_Capture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PB_Capture.Location = new System.Drawing.Point(836, 101);
            this.PB_Capture.Name = "PB_Capture";
            this.PB_Capture.Size = new System.Drawing.Size(150, 150);
            this.PB_Capture.TabIndex = 1;
            this.PB_Capture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(26, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "CAMERA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(859, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "CAPTURE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(696, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã người dùng";
            // 
            // BTN_Opencam
            // 
            this.BTN_Opencam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Opencam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Opencam.ForeColor = System.Drawing.Color.White;
            this.BTN_Opencam.Location = new System.Drawing.Point(30, 553);
            this.BTN_Opencam.Name = "BTN_Opencam";
            this.BTN_Opencam.Size = new System.Drawing.Size(135, 66);
            this.BTN_Opencam.TabIndex = 6;
            this.BTN_Opencam.Text = "Mở camera";
            this.BTN_Opencam.UseVisualStyleBackColor = true;
            this.BTN_Opencam.Click += new System.EventHandler(this.BTN_Opencam_Click);
            // 
            // BTN_save
            // 
            this.BTN_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_save.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_save.ForeColor = System.Drawing.Color.White;
            this.BTN_save.Location = new System.Drawing.Point(312, 553);
            this.BTN_save.Name = "BTN_save";
            this.BTN_save.Size = new System.Drawing.Size(172, 66);
            this.BTN_save.TabIndex = 7;
            this.BTN_save.Text = "Lưu thông tin";
            this.BTN_save.UseVisualStyleBackColor = true;
            this.BTN_save.Click += new System.EventHandler(this.BTN_save_Click);
            // 
            // BTN_detect
            // 
            this.BTN_detect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_detect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_detect.ForeColor = System.Drawing.Color.White;
            this.BTN_detect.Location = new System.Drawing.Point(171, 553);
            this.BTN_detect.Name = "BTN_detect";
            this.BTN_detect.Size = new System.Drawing.Size(135, 66);
            this.BTN_detect.TabIndex = 8;
            this.BTN_detect.Text = "Nhận dạng";
            this.BTN_detect.UseVisualStyleBackColor = true;
            this.BTN_detect.Click += new System.EventHandler(this.BTN_detect_Click);
            // 
            // TXB_MatKhau
            // 
            this.TXB_MatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.TXB_MatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXB_MatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXB_MatKhau.ForeColor = System.Drawing.Color.White;
            this.TXB_MatKhau.Location = new System.Drawing.Point(701, 459);
            this.TXB_MatKhau.Multiline = true;
            this.TXB_MatKhau.Name = "TXB_MatKhau";
            this.TXB_MatKhau.PasswordChar = '*';
            this.TXB_MatKhau.Size = new System.Drawing.Size(420, 26);
            this.TXB_MatKhau.TabIndex = 9;
            // 
            // TXB_userId
            // 
            this.TXB_userId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.TXB_userId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXB_userId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXB_userId.ForeColor = System.Drawing.Color.White;
            this.TXB_userId.Location = new System.Drawing.Point(700, 367);
            this.TXB_userId.Multiline = true;
            this.TXB_userId.Name = "TXB_userId";
            this.TXB_userId.Size = new System.Drawing.Size(420, 26);
            this.TXB_userId.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(697, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mật khẩu";
            // 
            // BTN_login
            // 
            this.BTN_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_login.ForeColor = System.Drawing.Color.White;
            this.BTN_login.Location = new System.Drawing.Point(844, 553);
            this.BTN_login.Name = "BTN_login";
            this.BTN_login.Size = new System.Drawing.Size(135, 66);
            this.BTN_login.TabIndex = 12;
            this.BTN_login.Text = "Đăng nhập";
            this.BTN_login.UseVisualStyleBackColor = true;
            this.BTN_login.Click += new System.EventHandler(this.BTN_login_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(1, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1164, 1);
            this.panel7.TabIndex = 109;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(1, 678);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1164, 1);
            this.panel6.TabIndex = 108;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1165, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 679);
            this.panel5.TabIndex = 107;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 679);
            this.panel4.TabIndex = 106;
            // 
            // BTN_close
            // 
            this.BTN_close.AnimationHoverSpeed = 0.07F;
            this.BTN_close.AnimationSpeed = 0.03F;
            this.BTN_close.BackColor = System.Drawing.Color.Transparent;
            this.BTN_close.BaseColor = System.Drawing.Color.Transparent;
            this.BTN_close.BorderColor = System.Drawing.Color.Black;
            this.BTN_close.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_close.FocusedColor = System.Drawing.Color.Empty;
            this.BTN_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_close.ForeColor = System.Drawing.Color.White;
            this.BTN_close.Image = ((System.Drawing.Image)(resources.GetObject("BTN_close.Image")));
            this.BTN_close.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_close.ImageSize = new System.Drawing.Size(10, 10);
            this.BTN_close.Location = new System.Drawing.Point(1105, 0);
            this.BTN_close.Name = "BTN_close";
            this.BTN_close.OnHoverBaseColor = System.Drawing.Color.Red;
            this.BTN_close.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.BTN_close.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_close.OnHoverImage = null;
            this.BTN_close.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_close.Size = new System.Drawing.Size(60, 30);
            this.BTN_close.TabIndex = 110;
            this.BTN_close.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_close.Click += new System.EventHandler(this.BTN_close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(700, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 2);
            this.panel2.TabIndex = 111;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(701, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 2);
            this.panel1.TabIndex = 112;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 32);
            this.label4.TabIndex = 113;
            this.label4.Text = "FACEID LOGIN";
            // 
            // FaceDetectLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1166, 679);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.BTN_close);
            this.Controls.Add(this.BTN_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXB_userId);
            this.Controls.Add(this.TXB_MatKhau);
            this.Controls.Add(this.BTN_detect);
            this.Controls.Add(this.BTN_save);
            this.Controls.Add(this.BTN_Opencam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PB_Capture);
            this.Controls.Add(this.PB_Camera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FaceDetectLogin";
            this.Text = "FaceDetectLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Faceid_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Faceid_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Faceid_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Camera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Capture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Camera;
        private System.Windows.Forms.PictureBox PB_Capture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_Opencam;
        private System.Windows.Forms.Button BTN_save;
        private System.Windows.Forms.Button BTN_detect;
        private System.Windows.Forms.TextBox TXB_MatKhau;
        private System.Windows.Forms.TextBox TXB_userId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_login;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI.WinForms.GunaButton BTN_close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}