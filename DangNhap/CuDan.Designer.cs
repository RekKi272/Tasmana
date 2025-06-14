
namespace DangNhap
{
    partial class CuDan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuDan));
            this.TM_nhanvien = new System.Windows.Forms.Timer(this.components);
            this.BTN_themcudan = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_in = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_PDF = new Guna.UI.WinForms.GunaGradientButton();
            this.BTN_excel = new Guna.UI.WinForms.GunaGradientButton();
            this.GGC_cudan = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.CBB_choice = new System.Windows.Forms.ComboBox();
            this.LB_loai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GGC_cudan)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_themcudan
            // 
            resources.ApplyResources(this.BTN_themcudan, "BTN_themcudan");
            this.BTN_themcudan.Animated = true;
            this.BTN_themcudan.AnimationHoverSpeed = 0.3F;
            this.BTN_themcudan.AnimationSpeed = 0.03F;
            this.BTN_themcudan.BackColor = System.Drawing.Color.Transparent;
            this.BTN_themcudan.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(156)))), ((int)(((byte)(46)))));
            this.BTN_themcudan.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(156)))), ((int)(((byte)(46)))));
            this.BTN_themcudan.BorderColor = System.Drawing.Color.White;
            this.BTN_themcudan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_themcudan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTN_themcudan.FocusedColor = System.Drawing.Color.Empty;
            this.BTN_themcudan.ForeColor = System.Drawing.Color.White;
            this.BTN_themcudan.Image = null;
            this.BTN_themcudan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_themcudan.ImageSize = new System.Drawing.Size(20, 20);
            this.BTN_themcudan.Name = "BTN_themcudan";
            this.BTN_themcudan.OnHoverBaseColor1 = System.Drawing.Color.ForestGreen;
            this.BTN_themcudan.OnHoverBaseColor2 = System.Drawing.Color.ForestGreen;
            this.BTN_themcudan.OnHoverBorderColor = System.Drawing.Color.White;
            this.BTN_themcudan.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_themcudan.OnHoverImage = null;
            this.BTN_themcudan.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_themcudan.Radius = 5;
            this.BTN_themcudan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTN_themcudan.Click += new System.EventHandler(this.BTN_themcudan_Click);
            // 
            // BTN_in
            // 
            resources.ApplyResources(this.BTN_in, "BTN_in");
            this.BTN_in.AnimationHoverSpeed = 0.3F;
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
            this.BTN_PDF.AnimationHoverSpeed = 0.3F;
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
            this.BTN_excel.AnimationHoverSpeed = 0.3F;
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
            this.BTN_excel.OnHoverBaseColor1 = System.Drawing.Color.ForestGreen;
            this.BTN_excel.OnHoverBaseColor2 = System.Drawing.Color.ForestGreen;
            this.BTN_excel.OnHoverBorderColor = System.Drawing.Color.White;
            this.BTN_excel.OnHoverForeColor = System.Drawing.Color.White;
            this.BTN_excel.OnHoverImage = null;
            this.BTN_excel.OnPressedColor = System.Drawing.Color.Black;
            this.BTN_excel.TextOffsetX = 3;
            this.BTN_excel.Click += new System.EventHandler(this.BTN_excel_Click);
            // 
            // GGC_cudan
            // 
            resources.ApplyResources(this.GGC_cudan, "GGC_cudan");
            this.GGC_cudan.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.GGC_cudan.BackColor = System.Drawing.SystemColors.Window;
            this.GGC_cudan.Name = "GGC_cudan";
            this.GGC_cudan.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.GGC_cudan.UseRightToLeftCompatibleTextBox = true;
            this.GGC_cudan.VersionInfo = "25.1462.39";
            this.GGC_cudan.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.GGC_cudan_TableControlCellDoubleClick);
            // 
            // CBB_choice
            // 
            resources.ApplyResources(this.CBB_choice, "CBB_choice");
            this.CBB_choice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CBB_choice.ForeColor = System.Drawing.Color.White;
            this.CBB_choice.FormattingEnabled = true;
            this.CBB_choice.Items.AddRange(new object[] {
            resources.GetString("CBB_choice.Items"),
            resources.GetString("CBB_choice.Items1"),
            resources.GetString("CBB_choice.Items2"),
            resources.GetString("CBB_choice.Items3")});
            this.CBB_choice.Name = "CBB_choice";
            this.CBB_choice.SelectedIndexChanged += new System.EventHandler(this.CBB_choice_SelectedIndexChanged);
            // 
            // LB_loai
            // 
            resources.ApplyResources(this.LB_loai, "LB_loai");
            this.LB_loai.BackColor = System.Drawing.Color.Transparent;
            this.LB_loai.ForeColor = System.Drawing.Color.White;
            this.LB_loai.Name = "LB_loai";
            // 
            // CuDan
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.LB_loai);
            this.Controls.Add(this.CBB_choice);
            this.Controls.Add(this.GGC_cudan);
            this.Controls.Add(this.BTN_in);
            this.Controls.Add(this.BTN_PDF);
            this.Controls.Add(this.BTN_excel);
            this.Controls.Add(this.BTN_themcudan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CuDan";
            this.Load += new System.EventHandler(this.CuDan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GGC_cudan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TM_nhanvien;
        private Guna.UI.WinForms.GunaGradientButton BTN_themcudan;
        private Guna.UI.WinForms.GunaGradientButton BTN_in;
        private Guna.UI.WinForms.GunaGradientButton BTN_PDF;
        private Guna.UI.WinForms.GunaGradientButton BTN_excel;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl GGC_cudan;
        private System.Windows.Forms.ComboBox CBB_choice;
        private System.Windows.Forms.Label LB_loai;
    }
}