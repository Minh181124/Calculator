using Maytinh.Models;
using Maytinh.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Maytinh.View
{
    public partial class ScientificV : Form
    {
        public ScientificV()
        {
            InitializeComponent();
        }
        int flag = 0;
        bool enter_value = false;
        MayTinhM data = new MayTinhM();
        MayTinhS s = new MayTinhS();
        //sự kiện click number
        private void btn_click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                txt_Display.Text = "0";
                txt_show.Text = "";
                flag = 0;
            }
            if ((txt_Display.Text == "0") || (enter_value))
                txt_Display.Text = "";
            enter_value = false;

            Button num = (Button)sender;
            if (num.Text == ".")
            {
                if (!txt_Display.Text.Contains("."))
                    txt_Display.Text = txt_Display.Text + num.Text;
            }
            else
                txt_Display.Text = txt_Display.Text + num.Text;
        }
        //sự kiện click +/-
        private void btn_doidau_Click(object sender, EventArgs e)
        {
            try
            {
                Double a;
                a = Convert.ToDouble(txt_Display.Text) * (-1.0);
                txt_Display.Text = System.Convert.ToString(a);
            }
            catch (Exception ex) { }
        }
        //sự kiện click + _ * /
        private void btn_operator_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.operation = num.Text;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = "";
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation;
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //Hàm xuất vào phép tính
        private void xuat()
        {
            if (data.n2 < 0)
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation + " " + "(" + System.Convert.ToString(data.n2) + ")" + " = ";
            else if (data.n1 < 0)
                txt_show.Text = "(" + System.Convert.ToString(data.n1) + ")" + " " + data.operation + " " + System.Convert.ToString(data.n2) + " = ";
            else
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation + " " + System.Convert.ToString(data.n2) + " = ";
            flag = 1;
        }
        //sự kiện =
        private void btn_bang_Click(object sender, EventArgs e)
        {
            try
            {
                data.n2 = Double.Parse(txt_Display.Text);
                if (data.operation == string.Empty)
                {
                    txt_show.Text = System.Convert.ToString(data.n2) + " = ";
                    txt_Display.Text = System.Convert.ToString(data.n2);
                }
                else if (data.n2 == 0)
                {
                    if (data.operation == "/" || data.operation == "mod" || data.operation == "yroot")
                    {
                        MessageBox.Show("Không thể chia cho 0");
                        txt_Display.Text = "0";
                        txt_show.Text = "";
                    }
                    else
                    {
                        txt_Display.Text = s.Tinh(data.n1, data.n2, data.operation);
                        xuat();
                    }
                }
                else
                {
                    txt_Display.Text = s.Tinh(data.n1, data.n2, data.operation);
                    xuat();
                }
            }
            catch (Exception ex) { MessageBox.Show("Hãy xóa đi và nhập lại"); }
        }
        //sự kiện ⌫
        private void btn_backspace_Click(object sender, EventArgs e)
        {
            if (txt_Display.Text.Length > 0)
            {
                txt_Display.Text = txt_Display.Text.Remove(txt_Display.Text.Length - 1, 1);
            }
            if (txt_Display.Text == "")
            {
                txt_Display.Text = "0";
            }
        }
        //Hàm reset
        private void Reset()
        {
            txt_Display.Text = "0";
            txt_show.Text = "";
            data.n1 = 0;
            data.n2 = 0;
            data.operation = "";
            enter_value = false;
            flag = 0;
        }
        //sự kiện C
        private void btn_C_Click(object sender, EventArgs e)
        {
            Reset();
        }
        //sự kiện CE
        private void btn_CE_Click(object sender, EventArgs e)
        {
            Reset();
        }
        //sự kiện phần trăm
        private void btn_phantram_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = (data.n1 / 100).ToString();
                txt_show.Text = System.Convert.ToString(data.n1) + num.Text + " = ";
                flag = 1;
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //sự kiện 1/n
        private void btn_motPhan_Click(object sender, EventArgs e)
        {
            try
            {
                data.n1 = Double.Parse(txt_Display.Text);
                if (data.n1 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0");
                    txt_Display.Text = "0";
                    txt_show.Text = "";
                }
                else
                {
                    txt_Display.Text = s.Tinh(1, data.n1, "/");
                    txt_show.Text = "1/" + System.Convert.ToString(data.n1) + " = ";
                    flag = 1;
                }
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //sự kiện bình phương
        private void btn_binhphuong_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = s.luyThua(data.n1, 2).ToString();
                txt_show.Text = System.Convert.ToString(data.n1) + "^" + "2" + " = ";
                flag = 1;
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //sự kiện btn căn bậc 2
        private void btn_canbac2_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = s.canBac(data.n1, 2).ToString();
                txt_show.Text = "√" + System.Convert.ToString(data.n1) + " = ";
                flag = 1;
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //sự kiện chuyển đổi sang máy tính cơ bản
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                View.StandardV standardfrm = new View.StandardV();
                this.Hide();
                standardfrm.ShowDialog();
                this.Show();
                Application.Exit();
            }
            catch (Exception ex) { };
        }
        //sự kiện btn_mod (chia lấy dư)
        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.operation = "mod";
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = "";
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation;
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //sự kiện btn căn bậc y
        private void btn_canBacy_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.operation = "yroot";
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = "";
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation;
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //sự kiện lũy thừa n
        private void btn_luythuaN_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.operation = "^";
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = "";
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_phanNgan_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = (data.n1 / 1000).ToString();
                txt_show.Text = System.Convert.ToString(data.n1) + num.Text + " = ";
                flag = 1;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_triTuyetDoi_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = Math.Abs(data.n1).ToString();
                txt_show.Text = "|" + System.Convert.ToString(data.n1) + "|" + " = ";
                flag = 1;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_giaithua_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = s.giaithua(data.n1).ToString();
                txt_show.Text = System.Convert.ToString(data.n1) + "!" + " = ";
                flag = 1;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                if (data.n1 <= 0)
                {
                    MessageBox.Show("Invalid Input");
                    txt_Display.Text = "0";
                    txt_show.Text = "";
                }
                else
                {
                    txt_Display.Text = Math.Log10(data.n1).ToString();
                    txt_show.Text = num.Text + "(" + System.Convert.ToString(data.n1) + ")" + " = ";
                    flag = 1;
                }
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_ln_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                if (data.n1 <= 0)
                {
                    MessageBox.Show("Invalid Input");
                    txt_Display.Text = "0";
                    txt_show.Text = "";
                }
                else
                {
                    txt_Display.Text = Math.Log(data.n1).ToString();
                    txt_show.Text = num.Text + "(" + System.Convert.ToString(data.n1) + ")" + " = ";
                    flag = 1;
                }
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_exp_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = Math.Exp(data.n1).ToString();
                txt_show.Text = num.Text + "(" + System.Convert.ToString(data.n1) + ")" + " = ";
                flag = 1;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_ngoacMo_Click(object sender, EventArgs e)
        {

        }
    }
}