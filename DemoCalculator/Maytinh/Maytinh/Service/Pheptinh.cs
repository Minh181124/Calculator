using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Maytinh.Service
{
    public abstract class Pheptinh
    {
        public abstract double tinhtoan(double n1, double n2);
        
    }
    public class phepCong : Pheptinh 
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 + n2;
        }
    }
    public class phepTru : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 - n2;
        }
    }
    public class phepNhan : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 * n2;
        }
    }
    public class phepChia : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 / n2;
        }
    }
    public class Chialaydu : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return n1 % n2;
        }
    }
    public class canBac : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.Pow((double)n1, 1 / n2);
        }
    }
    public class luyThua : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.Pow(n1, n2);
        }
    }
    public class giaiThua : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
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
            return Math.E;
        }
    }
    public class PI : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.PI;
        }
    }
    public class LN : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.Log(n1);
        }
    }
    public class Log : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.Log10(n1);
        }
    }
    public class EXP : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
           return Math.Exp(n1);
        }
    }
    public class ABS : Pheptinh
    {
        public override double tinhtoan(double n1, double n2)
        {
            return Math.Abs(n1);
        }
    }
}
