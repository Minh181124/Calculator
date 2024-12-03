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

namespace Maytinh.View
{
    public partial class ProgammerV : Form
    {
        public ProgammerV()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
            Child.Senderback += GetMessage;
        }

        bool enter_value = false;
        MayTinhM data = new MayTinhM();
        MayTinhS s = new MayTinhS();
        LichSuMayTinhS dsls = new LichSuMayTinhS();
        LichSu Child = new LichSu();
        public delegate void SendMessage(double so1, double so2, double ketqua, string dau);
        public SendMessage Sender;
        ProgammerS converter = new ProgammerS();
        const int bin = 2, hex = 16, dec = 10, oct = 8;
        int Presentbase = dec;
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
                a = Double.Parse(converter.ConvertBetweenBases(txt_Display.Text, Presentbase, dec)) * (-1.0);
                txt_Display.Text = System.Convert.ToString(a);
            }
            catch (Exception ex) { }
        }
        static string GetLastWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            } // Tách chuỗi thành mảng các từ
            string[] words = input.Split(' '); // Lấy từ cuối cùng
            return words[words.Length - 1];
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
                    data.n1 = Double.Parse(converter.ConvertBetweenBases(txt_Display.Text, Presentbase, dec));
                    txt_Display.Text = "";
                    txt_show.Text = System.Convert.ToString(converter.ConvertBetweenBases(Convert.ToString(data.n1), dec, Presentbase).ToUpper()) + " " + data.operation;
                    enter_value = false;
                }
                else
                {
                    bang();
                    Button num = (Button)sender;
                    data.operation = num.Text;
                    if (txt_Display.Text == "")
                    {
                        string lastword = GetLastWord(txt_show.Text);
                        if (lastword != data.operation)
                        {
                            txt_show.Text = txt_show.Text.Replace(lastword, data.operation);
                        }
                    }
                    else
                    {
                        data.n1 = Double.Parse(converter.ConvertBetweenBases(txt_Display.Text, Presentbase, dec));
                        txt_Display.Text = "";
                        txt_show.Text = System.Convert.ToString(data.n1) + " " + data.operation;
                        enter_value = false;
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void xuat(double n1, double n2, string operation)
        {
            string so1 = converter.ConvertBetweenBases(Convert.ToString(n1), dec, Presentbase).ToUpper();
            string so2 = converter.ConvertBetweenBases(Convert.ToString(n2), dec, Presentbase).ToUpper();
            if (n2 < 0)
                txt_show.Text = so1 + " " + operation + " " + "(" + so2 + ")" + " = ";
            else if (n1 < 0)
                txt_show.Text = "(" + so1 + ")" + " " + operation + " " + so2 + " = ";
            else
                txt_show.Text = so1 + " " + operation + " " + so2 + " = ";
            enter_value = true;
        }
        private void bang()
        {
            try
            {
                data.n2 = Double.Parse(converter.ConvertBetweenBases(txt_Display.Text, Presentbase, dec));
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
                        txt_Display.Text = converter.ConvertBetweenBases(s.Tinh(data.n1, data.n2, data.operation), dec, Presentbase).ToUpper();
                        xuat(data.n1, data.n2, data.operation);
                    }
                }
                else
                {
                    txt_Display.Text = converter.ConvertBetweenBases(s.Tinh(data.n1, data.n2, data.operation), dec, Presentbase).ToUpper();
                    xuat(data.n1, data.n2, data.operation);
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
                double ketqua = Double.Parse(converter.ConvertBetweenBases(txt_Display.Text, Presentbase, dec));
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
        //doi may tinh khac
        #region Doi may tinh
        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Child.Visible)
                {
                    Child.Close();
                }
                View.ScientificV scientificfrm = new View.ScientificV();
                this.Hide();
                scientificfrm.ShowDialog();
                this.Show();
                Application.Exit();
            }
            catch (Exception ex) { }
        }
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Child.Visible)
                {
                    Child.Close();
                }
                View.StandardV standardfrm = new View.StandardV();
                this.Hide();
                standardfrm.ShowDialog();
                this.Show();
                Application.Exit();
            }
            catch (Exception ex) { };
        }

        #endregion

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
        private void GetMessage(double so1, double so2, double ketqua, string dau)
        {
            txt_Display.Text = ketqua.ToString();
            xuat(so1, so2, dau);
        }

        private void rd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                if (radio.Text == "DEC")
                {
                    ResetC();
                    pnl_HEX.Enabled = false;
                    pnl_OCT.Enabled = true;
                    btn_2.Enabled = true;
                    btn_3.Enabled = true;
                    btn_4.Enabled = true;
                    btn_5.Enabled = true;
                    btn_6.Enabled = true;
                    btn_7.Enabled = true;
                    Presentbase = dec;
                    txt_Display.Text = lb_dec.Text;
                }
                if (radio.Text == "HEX")
                {
                    ResetC();
                    pnl_HEX.Enabled = true;
                    pnl_OCT.Enabled = true;
                    btn_2.Enabled = true;
                    btn_3.Enabled = true;
                    btn_4.Enabled = true;
                    btn_5.Enabled = true;
                    btn_6.Enabled = true;
                    btn_7.Enabled = true;
                    Presentbase = hex;
                    txt_Display.Text = lb_hex.Text;
                }
                if (radio.Text == "BIN")
                {
                    ResetC();
                    pnl_HEX.Enabled = false;
                    pnl_OCT.Enabled = false;
                    btn_2.Enabled = false;
                    btn_3.Enabled = false;
                    btn_4.Enabled = false;
                    btn_5.Enabled = false;
                    btn_6.Enabled = false;
                    btn_7.Enabled = false;
                    Presentbase = bin;
                    txt_Display.Text = lb_bin.Text;
                }
                if (radio.Text == "OCT")
                {
                    ResetC();
                    pnl_HEX.Enabled = false;
                    pnl_OCT.Enabled = false;
                    btn_2.Enabled = true;
                    btn_3.Enabled = true;
                    btn_4.Enabled = true;
                    btn_5.Enabled = true;
                    btn_6.Enabled = true;
                    btn_7.Enabled = true;
                    Presentbase = oct;
                    txt_Display.Text = lb_oct.Text;
                }
            }
        }

        private void txt_Display_TextChanged(object sender, EventArgs e)
        {
            if (txt_Display.Text != "")
            {
                string value = txt_Display.Text.Replace(" ", "");
                lb_bin.Text = converter.ConvertBetweenBases(value, Presentbase, bin).ToUpper();
                lb_hex.Text = converter.ConvertBetweenBases(value, Presentbase, hex).ToUpper();
                lb_dec.Text = converter.ConvertBetweenBases(value, Presentbase, dec).ToUpper();
                lb_oct.Text = converter.ConvertBetweenBases(value, Presentbase, oct).ToUpper();
            }
        }

        private void lb_bin_TextChanged(object sender, EventArgs e)
        {
            // Phương thức định dạng lại chuỗi với dấu cách sau mỗi 4 chữ số
            string FormatStringWithSpaces(string input)
            {
                int spaceInterval = 4;
                int inputLength = input.Length;
                int insertPosition = spaceInterval;
                while (input.Length % 4 != 0)
                {
                    input = "0" + input;
                }
                while (insertPosition < inputLength)
                {
                    input = input.Insert(insertPosition, " ");
                    insertPosition += spaceInterval + 1;
                    inputLength++;
                }
                return input;
            } // Cập nhật nội dung của Label theo nội dung của TextBox
            string formattedText = FormatStringWithSpaces(lb_bin.Text.Replace(" ", ""));
            lb_bin.Text = formattedText;
        }

        private void btn_not_Click(object sender, EventArgs e)
        {
            try
            {
                string input=txt_Display.Text;
                int s1 = int.Parse(converter.ConvertBetweenBases(input,Presentbase,dec));
                txt_Display.Text = System.Convert.ToString(~s1);
                txt_show.Text = "NOT(" + input + ")";
                enter_value = true;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_sh_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                string input = txt_Display.Text;
                data.n1 = Double.Parse(converter.ConvertBetweenBases(txt_Display.Text, Presentbase, dec));
                if (num.Text == ">>")
                {
                    txt_Display.Text = "";
                    data.operation = "Rsh";
                    txt_show.Text = input + " Rsh";
                }
                if (num.Text == "<<")
                {
                    txt_Display.Text = "";
                    data.operation = "Lsh";
                    txt_show.Text = input + " Lsh";
                }
            }
            catch (Exception ex) { data.n1 = 0; }
        }
    }
}