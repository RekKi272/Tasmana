using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class ChiTietThongBao : Form
    {
        private readonly Notice notice;
        public ChiTietThongBao(Notice notice)
        {
            InitializeComponent();
            this.notice = notice;
            TXB_content.Text = notice.Content;
            TXB_title.Text = notice.Title;
            LB_author.Text = $"{notice.Author} {notice.Date}";
            if(notice.File != null)
            {
                LLB_hienfile.Text = notice.FileName;
                LLB_hienfile.Visible = true;
                LB_filedinhkem.Visible = true;
            }

        }

        private void LLB_hienfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = $"File (*{notice.FileExten})|*{notice.FileExten}",
                FileName = LLB_hienfile.Text,
            };
            bool ErrorMessage = false;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName))
                {
                    try
                    {
                        File.Delete(save.FileName);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = true;
                        MessageBox.Show("Unable to write data in disk" + ex.Message);
                    }
                }
                if (!ErrorMessage)
                {
                    try
                    {
                        byte[] bytes = notice.File;
                        File.WriteAllBytes(save.FileName, bytes);
                        MessageBox.Show("Successful", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while downloading" + ex.Message);
                    }
                }
            }

        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void ChiTietThongBao_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ChiTietThongBao_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ChiTietThongBao_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
