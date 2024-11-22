using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return n1+n2;
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
}
