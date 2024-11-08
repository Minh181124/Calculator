using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maytinh.Models;

namespace Maytinh.Service
{
    internal class MayTinhS
    {
        MayTinhM data= new MayTinhM();
        public string Tinh(double n1, double n2, string operation)
        {
            double ketqua = 0;
            switch (operation)
            {
                case "+":
                    ketqua = n1 + n2;
                    break;
                case "-":
                    ketqua = n1 - n2;
                    break;
                case "*":
                    ketqua = n1 * n2;
                    break;
                case "/":
                    ketqua = n1 / n2;
                    break;
                default:
                    break;
            }
            return ketqua.ToString();
        }
        public string luyThua(double n1,double m)
        {
            double ketqua=Math.Pow(n1,m);
            return ketqua.ToString();
        }
        public string canBac(double n1, double m)
        {
            double ketqua = 0;
            ketqua=Math.Pow((double)n1,1/m);
            return ketqua.ToString();
        }
    }
}
