﻿using Maytinh.Models;
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
        bool enter_value = false;
        MayTinhM data = new MayTinhM();
        MayTinhS s = new MayTinhS();
        LichSu Child = new LichSu();
        //sự kiện click number
        private void btn_click(object sender, EventArgs e)
        {
            if ((txt_Display.Text == "0") || (enter_value))
            {
                txt_Display.Text = "";
                txt_show.Text = "";
            }
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
                if (data.operation == string.Empty)
                {
                    Button num = (Button)sender;
                    data.operation = num.Text;
                    data.n1 = Double.Parse(txt_Display.Text);
                    txt_Display.Text = "";
                    txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation;
                    enter_value = false;
                }
                else
                {
                    bang();
                    Button num = (Button)sender;
                    data.operation = num.Text;
                    if (txt_Display.Text == "")
                    {
                        string lastchar = txt_show.Text.Substring(txt_show.TextLength - 1, 1);
                        if (lastchar != data.operation)
                        {
                            txt_show.Text = txt_show.Text.Replace(lastchar, data.operation);
                        }
                    }
                    else
                    {
                        data.n1 = Double.Parse(txt_Display.Text);
                        txt_Display.Text = "";
                        txt_show.Text += System.Convert.ToString(data.n1) + " " + data.operation;
                        enter_value = false;
                    }
                }
            }
            catch (Exception ex) { }
        }
        //Hàm xuất vào phép tính
        private void xuat()
        {
            if (data.n2 < 0)
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation + " " + "(" + System.Convert.ToString(data.n2) + ")";
            else if (data.n1 < 0)
                txt_show.Text = "(" + System.Convert.ToString(data.n1) + ")" + " " + data.operation + " " + System.Convert.ToString(data.n2);
            else
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation + " " + System.Convert.ToString(data.n2);
            enter_value = true;
        }
        //sự kiện =
        private void btn_bang_Click(object sender, EventArgs e)
        {
            try
            {
                bang();
                double ketqua = double.Parse(txt_Display.Text);
                Child.Sender(data.n1, data.n2, ketqua, data.operation); //Gọi delegate
                data.operation = string.Empty;
            }
            catch (Exception ex) { MessageBox.Show("Hãy xóa đi và nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void bang()
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
            catch (Exception ex) { }
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
        private void ResetC()
        {
            txt_Display.Text = "0";
            txt_show.Text = "";
            data.n1 = 0;
            data.n2 = 0;
            data.operation = "";
            enter_value = false;
        }
        private void ResetCE()
        {
            if (enter_value == true)
            {
                ResetC();
            }
            else
            {
                txt_Display.Text = "";
                data.n2 = 0;
                enter_value = false;
            }
        }
        //sự kiện C
        private void btn_C_Click(object sender, EventArgs e)
        {
            ResetC();
        }
        //sự kiện CE
        private void btn_CE_Click(object sender, EventArgs e)
        {
            ResetCE();
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
                enter_value = true;
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
                    enter_value = true;
                }
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        //sự kiện bình phương
        private void btn_binhphuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (data.n1 == 0)
                {
                    Button num = (Button)sender;
                    Pheptinh lt2 = new luyThua();
                    data.n1 = Double.Parse(txt_Display.Text);
                    txt_Display.Text = lt2.tinhtoan(data.n1, 2).ToString();
                    txt_show.Text = System.Convert.ToString(data.n1) + "^" + "2";
                    enter_value = true;
                }
                else
                {
                    Button num = (Button)sender;
                    Pheptinh lt2 = new luyThua();
                    data.n2 = Double.Parse(txt_Display.Text);
                    txt_Display.Text = lt2.tinhtoan(data.n2, 2).ToString();
                    txt_show.Text = System.Convert.ToString(data.n1) + data.operation + System.Convert.ToString(data.n2) + "^" + "2" + " = ";
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
        }
        //sự kiện btn căn bậc 2
        private void btn_canbac2_Click(object sender, EventArgs e)
        {
            try
            {
                if (data.n1 == 0)
                {
                    Button num = (Button)sender;
                    Pheptinh cb2 = new canBac();
                    data.n1 = Double.Parse(txt_Display.Text);
                    txt_Display.Text = cb2.tinhtoan(data.n1, 2).ToString();
                    txt_show.Text = "√" + System.Convert.ToString(data.n1) + " = ";
                    enter_value = true;
                }
                else
                {
                    Button num = (Button)sender;
                    Pheptinh cb2 = new canBac();
                    data.n2 = Double.Parse(txt_Display.Text);
                    txt_Display.Text = cb2.tinhtoan(data.n2, 2).ToString();
                    txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "√" + System.Convert.ToString(data.n2);
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
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
                enter_value = true;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_triTuyetDoi_Click(object sender, EventArgs e)
        {
            try
            {
                Pheptinh Abs = new ABS();
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = Abs.tinhtoan(data.n1,data.n2).ToString();
                txt_show.Text = "|" + System.Convert.ToString(data.n1) + "|" + " = ";
                enter_value = true;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_giaithua_Click(object sender, EventArgs e)
        {
            try
            {
                Pheptinh giaithua= new giaiThua();
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = giaithua.tinhtoan(data.n1,data.n2).ToString();
                txt_show.Text = System.Convert.ToString(data.n1) + "!" + " = ";
                enter_value = true;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            try
            {
                Pheptinh log = new Log();
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
                    txt_Display.Text = log.tinhtoan(data.n1,data.n2).ToString();
                    txt_show.Text = num.Text + "(" + System.Convert.ToString(data.n1) + ")" + " = ";
                    enter_value = true;
                }
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_ln_Click(object sender, EventArgs e)
        {
            try
            {
                Pheptinh Ln= new LN();
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
                    txt_Display.Text = Ln.tinhtoan(data.n1,data.n2).ToString();
                    txt_show.Text = num.Text + "(" + System.Convert.ToString(data.n1) + ")" + " = ";
                    enter_value = true;
                }
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_exp_Click(object sender, EventArgs e)
        {
            try
            {
                Pheptinh Exp= new EXP();
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = Exp.tinhtoan(data.n1,data.n2).ToString();
                txt_show.Text = num.Text + "(" + System.Convert.ToString(data.n1) + ")" + " = ";
                enter_value = true;
            }
            catch (Exception ex) { data.n1 = 0; }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Child.Visible)
                {
                    Child.Hide();
                }
                else
                {
                    Child.Show();
                }
            }
            catch (Exception ex) { }
        }
        private void btn_e_Click(object sender, EventArgs e)
        {
            Pheptinh E = new E();
            txt_Display.Text=E.tinhtoan(data.n1, data.n2).ToString();
        }

        private void btn_pi_Click(object sender, EventArgs e)
        {
            Pheptinh Pi = new PI();
            txt_Display.Text = Pi.tinhtoan(data.n1, data.n2).ToString();
        }
    }
}