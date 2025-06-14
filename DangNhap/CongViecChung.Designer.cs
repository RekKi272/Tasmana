
namespace DangNhap
{
    partial class CongViecChung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CongViecChung));
            this.BTN_themcongviec = new Guna.UI.WinForms.GunaGradientButton();
            this.GGC_hienthicongviec = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.CBB_loaicv = new System.Windows.Forms.ComboBox();
            this.CBB_phanquyen = new System.Windows.Forms.ComboBox();
            this.LB_loai = new System.Windows.Forms.Label();
            this.LB_quyen = new System.Windows.Forms.Label();
            this.BTN_excel = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_PDF = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_in = new Guna.UI.WinForms.GunaGradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.GGC_hienthicongviec)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_themcongviec
            // 
            resources.ApplyResources(this.BTN_themcongviec, "BTN_themcongviec");
            this.BTN_themcongviec.Animated = true;
            this.BTN_themcongviec.AnimationHoverSpeed = 0.3F;
            this.BTN_themcongviec.AnimationSpeed = 0.03F;
            this.BTN_themcongviec.BackColor = System.Drawing.Color.Transparent;
            this.BTN_themcongviec.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.BTN_themcongviec.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(90)))), ((int)(((byte)(184)))));
            this.BTN_themcongviec.BorderColor = System.Drawing.Color.White;
            this.BTN_themcongviec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_themcongviec.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_themcongviec.FocusedColor = System.Drawing.Color.Empty;
            this.BTN_themcongviec.ForeColor = System.Drawing.Color.White;
            this.BTN_themcongviec.Image = null;
            this.BTN_themcongviec.ImageSize = new System.Drawing.Size(15, 15);
            this.BTN_themcongviec.Name = "BTN_themcongviec";
            this.BTN_themcongviec.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(40)))), ((int)(((byte)(184)))));
            this.BTN_themcongviec.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(40)))), ((int)(((byte)(184)))));
            this.BTN_themcongviec.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BTN_themcongviec.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_themcongviec.OnHoverImage = null;
            this.BTN_themcongviec.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_themcongviec.Radius = 5;
            this.BTN_themcongviec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_themcongviec.Click += new System.EventHandler(this.BTN_themcongviec_Click);
            // 
            // GGC_hienthicongviec
            // 
            resources.ApplyResources(this.GGC_hienthicongviec, "GGC_hienthicongviec");
            this.GGC_hienthicongviec.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.GGC_hienthicongviec.BackColor = System.Drawing.SystemColors.Window;
            this.GGC_hienthicongviec.Name = "GGC_hienthicongviec";
            this.GGC_hienthicongviec.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.GGC_hienthicongviec.UseRightToLeftCompatibleTextBox = true;
            this.GGC_hienthicongviec.VersionInfo = "25.1462.39";
            this.GGC_hienthicongviec.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.GGC_hienthicongviec_TableControlCellDoubleClick);
            // 
            // CBB_loaicv
            // 
            resources.ApplyResources(this.CBB_loaicv, "CBB_loaicv");
            this.CBB_loaicv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CBB_loaicv.ForeColor = System.Drawing.Color.White;
            this.CBB_loaicv.FormattingEnabled = true;
            this.CBB_loaicv.Items.AddRange(new object[] {
            resources.GetString("CBB_loaicv.Items"),
            resources.GetString("CBB_loaicv.Items1"),
            resources.GetString("CBB_loaicv.Items2")});
            this.CBB_loaicv.Name = "CBB_loaicv";
            this.CBB_loaicv.SelectedIndexChanged += new System.EventHandler(this.CBB_loaicv_SelectedIndexChanged);
            // 
            // CBB_phanquyen
            // 
            resources.ApplyResources(this.CBB_phanquyen, "CBB_phanquyen");
            this.CBB_phanquyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CBB_phanquyen.ForeColor = System.Drawing.Color.White;
            this.CBB_phanquyen.FormattingEnabled = true;
            this.CBB_phanquyen.Items.AddRange(new object[] {
            resources.GetString("CBB_phanquyen.Items"),
            resources.GetString("CBB_phanquyen.Items1"),
            resources.GetString("CBB_phanquyen.Items2"),
            resources.GetString("CBB_phanquyen.Items3")});
            this.CBB_phanquyen.Name = "CBB_phanquyen";
            this.CBB_phanquyen.SelectedIndexChanged += new System.EventHandler(this.CBB_phanquyen_SelectedIndexChanged);
            // 
            // LB_loai
            // 
            resources.ApplyResources(this.LB_loai, "LB_loai");
            this.LB_loai.ForeColor = System.Drawing.Color.White;
            this.LB_loai.Name = "LB_loai";
            // 
            // LB_quyen
            // 
            resources.ApplyResources(this.LB_quyen, "LB_quyen");
            this.LB_quyen.ForeColor = System.Drawing.Color.White;
            this.LB_quyen.Name = "LB_quyen";
            // 
            // BTN_excel
            // 
            resources.ApplyResources(this.BTN_excel, "BTN_excel");
            this.BTN_excel.AnimationHoverSpeed = 0.07F;
            this.BTN_excel.AnimationSpeed = 0.03F;
            this.BTN_excel.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(95)))), ((int)(((byte)(45)))));
            this.BTN_excel.BaseColor2 = System.Drawing.Color.Green;
            this.BTN_excel.BorderColor = System.Drawing.Color.White;
            this.BTN_excel.BorderSize = 1;
            this.BTN_excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_excel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_excel.FocusedColor = System.Drawing.Color.Empty;
            this.BTN_excel.ForeColor = System.Drawing.Color.White;
            this.BTN_excel.Image = ((System.Drawing.Image)(resources.GetObject("BTN_excel.Image")));
            this.BTN_excel.ImageSize = new System.Drawing.Size(15, 15);
            this.BTN_excel.Name = "BTN_excel";
            this.BTN_excel.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(95)))), ((int)(((byte)(45)))));
            this.BTN_excel.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(95)))), ((int)(((byte)(45)))));
            this.BTN_excel.OnHoverBorderColor = System.Drawing.Color.White;
            this.BTN_excel.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_excel.OnHoverImage = null;
            this.BTN_excel.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_excel.TextOffsetX = 3;
            this.BTN_excel.Click += new System.EventHandler(this.BTN_excel_Click);
            // 
            // BTN_PDF
            // 
            resources.ApplyResources(this.BTN_PDF, "BTN_PDF");
            this.BTN_PDF.AnimationHoverSpeed = 0.07F;
            this.BTN_PDF.AnimationSpeed = 0.03F;
            this.BTN_PDF.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(131)))), ((int)(((byte)(18)))));
            this.BTN_PDF.BaseColor2 = System.Drawing.Color.Coral;
            this.BTN_PDF.BorderColor = System.Drawing.Color.White;
            this.BTN_PDF.BorderSize = 1;
            this.BTN_PDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_PDF.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_PDF.FocusedColor = System.Drawing.Color.Empty;
            this.BTN_PDF.ForeColor = System.Drawing.Color.White;
            this.BTN_PDF.Image = ((System.Drawing.Image)(resources.GetObject("BTN_PDF.Image")));
            this.BTN_PDF.ImageSize = new System.Drawing.Size(15, 15);
            this.BTN_PDF.Name = "BTN_PDF";
            this.BTN_PDF.OnHoverBaseColor1 = System.Drawing.Color.OrangeRed;
            this.BTN_PDF.OnHoverBaseColor2 = System.Drawing.Color.OrangeRed;
            this.BTN_PDF.OnHoverBorderColor = System.Drawing.Color.White;
            this.BTN_PDF.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_PDF.OnHoverImage = null;
            this.BTN_PDF.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_PDF.TextOffsetX = 3;
            this.BTN_PDF.Click += new System.EventHandler(this.BTN_PDF_Click);
            // 
            // BTN_in
            // 
            resources.ApplyResources(this.BTN_in, "BTN_in");
            this.BTN_in.AnimationHoverSpeed = 0.07F;
            this.BTN_in.AnimationSpeed = 0.03F;
            this.BTN_in.BaseColor1 = System.Drawing.Color.Silver;
            this.BTN_in.BaseColor2 = System.Drawing.Color.DimGray;
            this.BTN_in.BorderColor = System.Drawing.Color.White;
            this.BTN_in.BorderSize = 1;
            this.BTN_in.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_in.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_in.FocusedColor = System.Drawing.Color.Empty;
            this.BTN_in.ForeColor = System.Drawing.Color.White;
            this.BTN_in.Image = ((System.Drawing.Image)(resources.GetObject("BTN_in.Image")));
            this.BTN_in.ImageSize = new System.Drawing.Size(15, 15);
            this.BTN_in.Name = "BTN_in";
            this.BTN_in.OnHoverBaseColor1 = System.Drawing.Color.DimGray;
            this.BTN_in.OnHoverBaseColor2 = System.Drawing.Color.DimGray;
            this.BTN_in.OnHoverBorderColor = System.Drawing.Color.White;
            this.BTN_in.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_in.OnHoverImage = null;
            this.BTN_in.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_in.TextOffsetX = 3;
            this.BTN_in.Click += new System.EventHandler(this.BTN_in_Click);
            // 
            // CongViecChung
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.LB_quyen);
            this.Controls.Add(this.LB_loai);
            this.Controls.Add(this.CBB_phanquyen);
            this.Controls.Add(this.CBB_loaicv);
            this.Controls.Add(this.GGC_hienthicongviec);
            this.Controls.Add(this.BTN_in);
            this.Controls.Add(this.BTN_PDF);
            this.Controls.Add(this.BTN_excel);
            this.Controls.Add(this.BTN_themcongviec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CongViecChung";
            this.Load += new System.EventHandler(this.CongViecChung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GGC_hienthicongviec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton BTN_themcongviec;
        private Guna.UI.WinForms.GunaGradientButton BTN_excel;
        private Guna.UI.WinForms.GunaGradientButton BTN_PDF;
        private Guna.UI.WinForms.GunaGradientButton BTN_in;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl GGC_hienthicongviec;
        private System.Windows.Forms.ComboBox CBB_loaicv;
        private System.Windows.Forms.ComboBox CBB_phanquyen;
        private System.Windows.Forms.Label LB_loai;
        private System.Windows.Forms.Label LB_quyen;
    }
}