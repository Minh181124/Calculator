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

namespace Maytinh.View
{
    public partial class TrigonometryV : Form
    {
        public TrigonometryV()
        {
            InitializeComponent();
        }
        bool enter_value = false;
        MayTinhM data = new MayTinhM();
        MayTinhS s = new MayTinhS();
        LichSuMayTinhS dsls = new LichSuMayTinhS();
        LichSu Child = new LichSu();
        //su kien click number
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
        //su kien click +/-
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
        //su kien click + - * /
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
                        txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation;
                        enter_value = false;
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void xuat()
        {
            if (data.n2 < 0)
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation + " " + "(" + System.Convert.ToString(data.n2) + ")" + " = ";
            else if (data.n1 < 0)
                txt_show.Text = "(" + System.Convert.ToString(data.n1) + ")" + " " + data.operation + " " + System.Convert.ToString(data.n2) + " = ";
            else
                txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation + " " + System.Convert.ToString(data.n2) + " = ";
            enter_value = true;
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

        //su kien click =
        private void btn_bang_Click(object sender, EventArgs e)
        {
            try
            {
                bang();
                double ketqua = double.Parse(txt_Display.Text);
                Child.Sender(data.n1, data.n2, ketqua, data.operation);//Gọi delegate
                data.operation = string.Empty;
            }
            catch (Exception ex) { MessageBox.Show("Hãy xóa đi và nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        //su kien click ⌫
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
        //Ham khoi dong lai
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
        //su kien click C
        private void btn_C_Click(object sender, EventArgs e)
        {
            ResetC();
        }
        //su kien click CE
        private void btn_CE_Click(object sender, EventArgs e)
        {
            ResetCE();
        }
        //su kien click %
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
        //su kien click 1/n 
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
        //su kien click x^2
        private void btn_luythua_Click(object sender, EventArgs e)
        {
            try
            {
                if (data.n1 == 0)
                {
                    Button num = (Button)sender;
                    Pheptinh lt2 = new luyThua();
                    data.n1 = Double.Parse(txt_Display.Text);
                    txt_Display.Text = lt2.tinhtoan(data.n1, 2).ToString();
                    txt_show.Text = System.Convert.ToString(data.n1) + "^" + "2" + " = ";
                    enter_value = true;
                }
                else
                {
                    Button num = (Button)sender;
                    Pheptinh lt2 = new luyThua();
                    data.n2 = Double.Parse(txt_Display.Text);
                    txt_Display.Text = lt2.tinhtoan(data.n2, 2).ToString();
                    txt_show.Text = data.n1 + data.operation + System.Convert.ToString(data.n2) + "^" + "2" + " = ";
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
        }
        //su kien click can bac 2
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
                    txt_show.Text = data.n1 + data.operation + "√" + System.Convert.ToString(data.n2) + " = ";
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
        }
        //doi may tinh khac
        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                View.ScientificV scientificfrm = new View.ScientificV();
                this.Hide();
                scientificfrm.ShowDialog();
                this.Show();
                Application.Exit();
            }
            catch (Exception ex) { }
        }

        private void lichSuToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}