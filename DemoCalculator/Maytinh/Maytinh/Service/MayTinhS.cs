using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Maytinh.Models;

namespace Maytinh.Service
{
    internal class MayTinhS
    {
        MayTinhM data = new MayTinhM();
        public string Tinh(double n1, double n2, string operation)
        {
            double ketqua = 0;
            switch (operation)
            {
                case "+":
                    Pheptinh cong = new phepCong();
                    ketqua = cong.tinhtoan(n1, n2);
                    break;
                case "-":
                    Pheptinh tru = new phepTru();
                    ketqua = tru.tinhtoan(n1, n2);
                    break;
                case "*":
                    Pheptinh nhan = new phepNhan();
                    ketqua = nhan.tinhtoan(n1, n2);
                    break;
                case "/":
                    Pheptinh chia = new phepChia();
                    ketqua = chia.tinhtoan(n1, n2);
                    break;
                case "mod":
                    Pheptinh mod = new Chialaydu();
                    ketqua = mod.tinhtoan(n1, n2);
                    break;
                case "yroot":
                    Pheptinh yroot = new canBac();
                    ketqua = yroot.tinhtoan(n1, n2);
                    break;
                case "^":
                    Pheptinh luythua = new luyThua();
                    ketqua = luythua.tinhtoan(n1, n2);
                    break;
                case "AND":
                    Pheptinh and = new AND();
                    ketqua = (double)and.tinhtoan(n1, n2); 
                    break;
                case "OR":
                    Pheptinh or = new OR();
                    ketqua = (double)or.tinhtoan(n1, n2);
                    break;
                case "XOR":
                    Pheptinh xor = new XOR();
                    ketqua = (double)xor.tinhtoan(n1, n2);
                    break;
                case "NAND":
                    Pheptinh nand = new NAND();
                    ketqua = (double)nand.tinhtoan(n1, n2);
                    break;
                case "NOR":
                    Pheptinh nor = new NOR();
                    ketqua = (double)nor.tinhtoan(n1, n2);
                    break;
                case "Rsh":
                    Pheptinh rsh = new RSH();
                    ketqua = (double)rsh.tinhtoan(n1, n2);
                    break;
                case "Lsh":
                    Pheptinh lsh = new LSH();
                    ketqua = (double)lsh.tinhtoan(n1, n2);
                    break;
                default:
                    break;
            }
            return ketqua.ToString();
        }
    }
}
