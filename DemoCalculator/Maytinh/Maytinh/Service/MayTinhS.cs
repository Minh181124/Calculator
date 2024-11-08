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
                case "mod":
                    ketqua = n1 % n2;
                    break;
                case "yroot":
                    ketqua = canBac(n1,n2);
                    break;
                case "^":
                    ketqua = luyThua(n1, n2);
                    break;
                default:
                    break;
            }
            return ketqua.ToString();
        }
        public double luyThua(double n1,double m)
        {
            double ketqua=Math.Pow(n1,m);
            return ketqua;
        }
        public double canBac(double n1, double m)
        {
            double ketqua = 0;
            ketqua=Math.Pow((double)n1,1/m);
            return ketqua ;
        }
        public double giaithua(double n1)
        {
            double ketqua = 1;
            int i = 1;
            while (i <= n1)
            {
                ketqua *= i;
                i++;
            }
            return ketqua;
        }
    }
}
