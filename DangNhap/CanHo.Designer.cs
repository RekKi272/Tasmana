
namespace DangNhap
{
    partial class CanHo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanHo));
            this.GGC_danhsachnv = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.GGC_canho = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.CBB_choice = new System.Windows.Forms.ComboBox();
            this.LB_loai = new System.Windows.Forms.Label();
            this.BTN_XemHoaDon = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_in = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_PDF = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_excel = new Guna.UI.WinForms.GunaGradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.GGC_danhsachnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GGC_canho)).BeginInit();
            this.SuspendLayout();
            // 
            // GGC_danhsachnv
            // 
            resources.ApplyResources(this.GGC_danhsachnv, "GGC_danhsachnv");
            this.GGC_danhsachnv.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.GGC_danhsachnv.BackColor = System.Drawing.SystemColors.Window;
            this.GGC_danhsachnv.Name = "GGC_danhsachnv";
            this.GGC_danhsachnv.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.GGC_danhsachnv.UseRightToLeftCompatibleTextBox = true;
            this.GGC_danhsachnv.VersionInfo = "25.1462.39";
            // 
            // GGC_canho
            // 
            resources.ApplyResources(this.GGC_canho, "GGC_canho");
            this.GGC_canho.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.GGC_canho.BackColor = System.Drawing.Color.White;
            this.GGC_canho.Name = "GGC_canho";
            this.GGC_canho.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.GGC_canho.UseRightToLeftCompatibleTextBox = true;
            this.GGC_canho.VersionInfo = "25.1462.39";
            this.GGC_canho.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.GGC_canho_TableControlCellDoubleClick);
            // 
            // CBB_choice
            // 
            resources.ApplyResources(this.CBB_choice, "CBB_choice");
            this.CBB_choice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CBB_choice.ForeColor = System.Drawing.Color.White;
            this.CBB_choice.FormattingEnabled = true;
            this.CBB_choice.Items.AddRange(new object[] {
            resources.GetString("CBB_choice.Items"),
            resources.GetString("CBB_choice.Items1")});
            this.CBB_choice.Name = "CBB_choice";
            this.CBB_choice.SelectedIndexChanged += new System.EventHandler(this.CBB_choice_SelectedIndexChanged);
            // 
            // LB_loai
            // 
            resources.ApplyResources(this.LB_loai, "LB_loai");
            this.LB_loai.ForeColor = System.Drawing.Color.White;
            this.LB_loai.Name = "LB_loai";
            // 
            // BTN_XemHoaDon
            // 
            resources.ApplyResources(this.BTN_XemHoaDon, "BTN_XemHoaDon");
            this.BTN_XemHoaDon.Animated = true;
            this.BTN_XemHoaDon.AnimationHoverSpeed = 0.3F;
            this.BTN_XemHoaDon.AnimationSpeed = 0.03F;
            this.BTN_XemHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.BTN_XemHoaDon.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(156)))), ((int)(((byte)(46)))));
            this.BTN_XemHoaDon.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(156)))), ((int)(((byte)(46)))));
            this.BTN_XemHoaDon.BorderColor = System.Drawing.Color.White;
            this.BTN_XemHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_XemHoaDon.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_XemHoaDon.FocusedColor = System.Drawing.Color.Empty;
            this.BTN_XemHoaDon.ForeColor = System.Drawing.Color.White;
            this.BTN_XemHoaDon.Image = null;
            this.BTN_XemHoaDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_XemHoaDon.ImageSize = new System.Drawing.Size(20, 20);
            this.BTN_XemHoaDon.Name = "BTN_XemHoaDon";
            this.BTN_XemHoaDon.OnHoverBaseColor1 = System.Drawing.Color.ForestGreen;
            this.BTN_XemHoaDon.OnHoverBaseColor2 = System.Drawing.Color.ForestGreen;
            this.BTN_XemHoaDon.OnHoverBorderColor = System.Drawing.Color.White;
            this.BTN_XemHoaDon.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_XemHoaDon.OnHoverImage = null;
            this.BTN_XemHoaDon.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_XemHoaDon.Radius = 5;
            this.BTN_XemHoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_XemHoaDon.Click += new System.EventHandler(this.BTN_XemHoaDon_Click);
            // 
            // BTN_in
            // 
            resources.ApplyResources(this.BTN_in, "BTN_in");
            this.BTN_in.AnimationHoverSpeed = 0.03F;
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
            // BTN_PDF
            // 
            resources.ApplyResources(this.BTN_PDF, "BTN_PDF");
            this.BTN_PDF.AnimationHoverSpeed = 0.03F;
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
            // BTN_excel
            // 
            resources.ApplyResources(this.BTN_excel, "BTN_excel");
            this.BTN_excel.AnimationHoverSpeed = 0.03F;
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
            // CanHo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.BTN_XemHoaDon);
            this.Controls.Add(this.LB_loai);
            this.Controls.Add(this.CBB_choice);
            this.Controls.Add(this.BTN_in);
            this.Controls.Add(this.BTN_PDF);
            this.Controls.Add(this.BTN_excel);
            this.Controls.Add(this.GGC_canho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CanHo";
            this.Load += new System.EventHandler(this.CanHo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GGC_danhsachnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GGC_canho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl GGC_danhsachnv;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl GGC_canho;
        private Guna.UI.WinForms.GunaGradientButton BTN_in;
        private Guna.UI.WinForms.GunaGradientButton BTN_PDF;
        private Guna.UI.WinForms.GunaGradientButton BTN_excel;
        private System.Windows.Forms.ComboBox CBB_choice;
        private System.Windows.Forms.Label LB_loai;
        private Guna.UI.WinForms.GunaGradientButton BTN_XemHoaDon;
    }
}