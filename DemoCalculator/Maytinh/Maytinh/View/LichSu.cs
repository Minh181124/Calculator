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
    public partial class LichSu : Form
    {
        public delegate void SendMessage(double so1, double so2, double ketqua, string dau);
        public SendMessage Sender;
        public LichSu()
        {
            InitializeComponent();
            //Tao con tro toi ham GetMessage
            Sender = new SendMessage(GetMessage);
        }//Ham lay tham so truyen vao
        private void GetMessage(double so1, double so2, double ketqua, string dau)
        {
            LichSuMayTinhM ls = new LichSuMayTinhM(so1, so2, ketqua, dau);
            dsls.AddToHistory(ls);
            lst_history.Items.Add(ls);
        }
        MayTinhM data = new MayTinhM();
        MayTinhS s = new MayTinhS();
        LichSuMayTinhS dsls = new LichSuMayTinhS();

        private void btn_clear_Click(object sender, EventArgs e)
        {
            lst_history.Items.Clear();
        }
    }
}
