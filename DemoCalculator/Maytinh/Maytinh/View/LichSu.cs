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
        public event SendMessage Senderback;

        public LichSu()
        {
            InitializeComponent();
            //Tao con tro toi ham GetMessage
            Sender = new SendMessage(GetMessage);
        }
        private void GetMessage(double so1, double so2, double ketqua, string dau)
        {
            if (dau != string.Empty)
            {
                LichSuMayTinhM ls = new LichSuMayTinhM(so1, so2, ketqua, dau);
                dsls.AddToHistory(ls);
                lst_history.Items.Add(ls);
            }
        }
        LichSuMayTinhS dsls = new LichSuMayTinhS();

        private void btn_clear_Click(object sender, EventArgs e)
        {
            lst_history.Items.Clear();
            dsls.Xoads();
        }

        private void lst_history_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_history.SelectedIndex != -1)
            {
                foreach (var ls in dsls.GetHistory())
                {
                    if (ls.Equals(lst_history.Items[lst_history.SelectedIndex]))
                    {
                        Senderback?.Invoke(ls.Num1, ls.Num2, ls.Result, ls.Dau);
                    }
                }
            }
        }
        private void LichSu_Load(object sender, EventArgs e)
        {
            if (lst_history.Items.Count == 0)
            {
                foreach (var ls in dsls.GetHistory())
                {
                    lst_history.Items.Add(ls);
                }
            }
        }
    }
}
