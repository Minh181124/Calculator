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
            Sender = new SendMessage(GetMessage);
            Child.Senderback += GetMessage;
        }
        bool enter_value = false;
        MayTinhM data = new MayTinhM();
        MayTinhS s = new MayTinhS();
        LichSu Child = new LichSu();
        public delegate void SendMessage(double so1, double so2, double ketqua, string dau);
        public SendMessage Sender;
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
        static string GetLastWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            } // Tách chuỗi thành mảng các từ
            string[] words = input.Split(' '); // Lấy từ cuối cùng
            return words[words.Length - 1];
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
                    if (num.Text == "xⁿ") data.operation = "^";
                    if (num.Text== "ⁿ√x") data.operation= "yroot";
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
                    if (num.Text == "xⁿ") data.operation = "^";
                    if (num.Text == "ⁿ√x") data.operation = "yroot";
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
        private void xuat(double n1, double n2, string operation)
        {
            if (n2 < 0)
                txt_show.Text = System.Convert.ToString(n1) + " " + operation + " " + "(" + System.Convert.ToString(n2) + ")" + " = ";
            else if (n1 < 0)
                txt_show.Text = "(" + System.Convert.ToString(n1) + ")" + " " + operation + " " + System.Convert.ToString(n2) + " = ";
            else
                txt_show.Text = System.Convert.ToString(n1) + " " + operation + " " + System.Convert.ToString(n2) + " = ";
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
                        xuat(data.n1, data.n2, data.operation);
                    }
                }
                else
                {
                    txt_Display.Text = s.Tinh(data.n1, data.n2, data.operation);
                    xuat(data.n1, data.n2, data.operation);
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
                if (data.operation == string.Empty)

                    if (data.operation == string.Empty)

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
                if (data.operation == string.Empty)
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
                txt_Display.Text = Abs.tinhtoan(data.n1).ToString();
                txt_show.Text = "|" + System.Convert.ToString(data.n1) + "|" + " = ";
                enter_value = true;
            }
            catch (Exception ex) { data.n1 = 0; }
        }

        private void btn_giaithua_Click(object sender, EventArgs e)
        {
            try
            {
                Pheptinh giaithua = new giaiThua();
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = giaithua.tinhtoan(data.n1).ToString();
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
                    txt_Display.Text = log.tinhtoan(data.n1).ToString();
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

                Pheptinh Ln = new LN();
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
                    txt_Display.Text = Ln.tinhtoan(data.n1).ToString();
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
                Pheptinh Exp = new EXP();
                Button num = (Button)sender;
                data.n1 = Double.Parse(txt_Display.Text);
                txt_Display.Text = Exp.tinhtoan(data.n1).ToString();
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
            txt_Display.Text = E.tinhtoan(data.n1).ToString();
        }

        private void btn_pi_Click(object sender, EventArgs e)
        {
            Pheptinh Pi = new PI();
            txt_Display.Text = Pi.tinhtoan(data.n1).ToString();
        }
        private void GetMessage(double so1, double so2, double ketqua, string dau)
        {
            txt_Display.Text = ketqua.ToString();
            xuat(so1, so2, dau);
        }

        private void progammerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Child.Visible)
                {
                    Child.Close();
                }
                View.ProgammerV progammerfrm = new View.ProgammerV();
                this.Hide();
                progammerfrm.ShowDialog();
                this.Show();
                Application.Exit();
            }
            catch (Exception ex) { }
        }

        private void btn_Trigonometry_Click(object sender, EventArgs e)
        {
            if (pnl_Trigonometry.Visible)
            {
                pnl_Trigonometry.Visible = false;
            }
            else
            {
                pnl_Trigonometry.Visible = true;
            }
        }
        string Aunit = "radians"; //đơn vị đo góc
        int arc = 0;
        private void btn_Aunit_Click(object sender, EventArgs e)
        {
            if (Aunit == "degrees")
            {
                Aunit = "radians";
                btn_Aunit.Text = "Rad";
            }
            else if (Aunit == "radians")
            {
                Aunit = "degrees";
                btn_Aunit.Text = "Deg";
            }
        }
        private void btn_2nd_Click(object sender, EventArgs e)
        {
            if (arc == 0)
            {
                btn_sin.Text = "Asin";
                btn_cos.Text = "Acos";
                btn_tan.Text = "Atan";
                btn_cot.Text = "Acot";
                arc = -1;
            }
            else
            {
                btn_sin.Text = "Sin";
                btn_cos.Text = "Cos";
                btn_tan.Text = "Tan";
                btn_cot.Text = "Cot";
                arc = 0;
            }
        }
        private void btn_sin_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                Pheptinh sin = new Sin();
                Pheptinh asin = new ASin();
                if (data.operation == string.Empty)
                {
                    data.n1 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc==-1)
                    {
                        if (Aunit == "radians")
                        {
                            x = asin.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = asin.tinhtoan(data.n1) * 180 / Math.PI;
                        }
                        txt_show.Text = "Asin(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = sin.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = sin.tinhtoan(data.n1 * Math.PI / 180);
                        }
                        txt_show.Text = "Sin(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
                else
                {
                    data.n2 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc == -1)
                    {
                        if (Aunit == "radians")
                        {
                            x = asin.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = asin.tinhtoan(data.n2) * 180 / Math.PI;
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Asin(" + System.Convert.ToString(data.n2) + ")";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = sin.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = sin.tinhtoan(data.n2 * Math.PI / 180);
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Sin(" + System.Convert.ToString(data.n2) + ")";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
        }

        private void btn_cos_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                Pheptinh cos = new Cos();
                Pheptinh acos = new ACos();
                if (data.operation == string.Empty)
                {
                    data.n1 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc == -1)
                    {
                        if (Aunit == "radians")
                        {
                            x = acos.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = acos.tinhtoan(data.n1) * 180 / Math.PI;
                        }
                        txt_show.Text = "Acos(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = cos.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = cos.tinhtoan(data.n1 * Math.PI / 180);
                        }
                        txt_show.Text = "Cos(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
                else
                {
                    data.n2 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc == -1)
                    {
                        if (Aunit == "radians")
                        {
                            x = acos.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = acos.tinhtoan(data.n2) * 180 / Math.PI;
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Acos(" + System.Convert.ToString(data.n2) + ")";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = cos.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = cos.tinhtoan(data.n2 * Math.PI / 180);
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Cos(" + System.Convert.ToString(data.n2) + ")";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
        }

        private void btn_tan_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                Pheptinh tan = new Tan();
                Pheptinh atan = new ATan();
                if (data.operation == string.Empty)
                {
                    data.n1 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc == -1)
                    {
                        if (Aunit == "radians")
                        {
                            x = atan.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = atan.tinhtoan(data.n1) * 180 / Math.PI;
                        }
                        txt_show.Text = "Atan(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = tan.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = tan.tinhtoan(data.n1 * Math.PI / 180);
                        }
                        txt_show.Text = "Tan(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
                else
                {
                    data.n2 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc == -1)
                    {
                        if (Aunit == "radians")
                        {
                            x = atan.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = atan.tinhtoan(data.n2) * 180 / Math.PI;
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Atan(" + System.Convert.ToString(data.n2) + ")";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = tan.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = tan.tinhtoan(data.n2 * Math.PI / 180);
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Tan(" + System.Convert.ToString(data.n2) + ")";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
        }

        private void btn_cot_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                Pheptinh cot = new Cot();
                Pheptinh acot = new ACot();
                if (data.operation == string.Empty)
                {
                    data.n1 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc == -1)
                    {
                        if (Aunit == "radians")
                        {
                            x = acot.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = acot.tinhtoan(data.n1) * 180 / Math.PI;
                        }
                        txt_show.Text = "Acot(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = cot.tinhtoan(data.n1);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = cot.tinhtoan(data.n1 * Math.PI / 180);
                        }
                        txt_show.Text = "Cot(" + System.Convert.ToString(data.n1) + ") = ";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
                else
                {
                    data.n2 = Double.Parse(txt_Display.Text);
                    double x = 0;
                    if (arc == -1)
                    {
                        if (Aunit == "radians")
                        {
                            x = acot.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = acot.tinhtoan(data.n2) * 180 / Math.PI;
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Acot(" + System.Convert.ToString(data.n2) + ")";
                    }
                    else
                    {
                        if (Aunit == "radians")
                        {
                            x = cot.tinhtoan(data.n2);
                        }
                        else if (Aunit == "degrees")
                        {
                            x = cot.tinhtoan(data.n2 * Math.PI / 180);
                        }
                        txt_show.Text = System.Convert.ToString(data.n1) + data.operation + "Cot(" + System.Convert.ToString(data.n2) + ")";
                    }
                    txt_Display.Text = x.ToString();
                    enter_value = true;
                }
            }
            catch (Exception ex) { ResetCE(); }
        }
    }
}