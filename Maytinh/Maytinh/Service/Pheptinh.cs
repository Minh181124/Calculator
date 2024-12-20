﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Maytinh.Service
{
    public abstract class Pheptinh
    {
        public abstract double tinhtoan(double n1, double n2);
        public abstract double tinhtoan(double n1);
    }
    public class phepCong : Pheptinh 
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 + n2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class phepTru : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 - n2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class phepNhan : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 * n2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class phepChia : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 / n2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class Chialaydu : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 % n2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class canBac : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.Pow((double)n1, 1 / n2);
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class luyThua : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.Pow(n1, n2);
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class giaiThua : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
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
    public class E : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.E;
        }
    }
    public class PI : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.PI;
        }
    }
    public class LN : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Log(n1);
        }
    }
    public class Log : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Log10(n1);
        }
    }
    public class EXP : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Exp(n1);
        }
    }
    public class ABS : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Abs(n1);
        }
    }
    public class Sin : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Sin(n1);
        }
    }
    public class ASin : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Asin(n1);
        }
    }
    public class Cos : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Cos(n1);
        }
    }
    public class ACos : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Acos(n1);
        }
    }
    public class Tan : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Tan(n1);
        }
    }
    public class ATan : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.Atan(n1);
        }
    }
    public class Cot : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return 1 / Math.Tan(n1);
        }
    }
    public class ACot : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return tinhtoan(n1);
        }
        public override double tinhtoan(double n1)
        {
            return Math.PI / 2 - Math.Atan(n1);
        }
    }
    public class AND : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            int s1 = (int)n1;
            int s2 = (int)n2;
            return s1 & s2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class OR : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            int s1 = (int)n1;
            int s2 = (int)n2;
            return s1 | s2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class XOR : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            int s1 = (int)n1;
            int s2 = (int)n2;
            return s1 ^ s2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class NAND : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            int s1 = (int)n1;
            int s2 = (int)n2;
            return ~(s1 & s2);
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class NOR : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            int s1 = (int)n1;
            int s2 = (int)n2;
            return ~(s1 | s2);
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class RSH : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            int s1 = (int)n1;
            int s2 = (int)n2;
            return s1>>s2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
    public class LSH : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            int s1 = (int)n1;
            int s2 = (int)n2;
            return s1<<s2;
        }
        public override double tinhtoan(double n1)
        {
            return 0;
        }
    }
}
