using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maytinh.Models
{
    internal class LichSuMayTinhM
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string Dau { get; set; }
        public double Result { get; set; }
        public DateTime Timestamp { get; set; }

        public LichSuMayTinhM(double so1,double so2,double ketqua,string dau) 
        {
            this.Num1 = so1;
            this.Num2 = so2;
            this.Dau = dau;
            this.Result = ketqua;
            this.Timestamp = DateTime.Now;
        }
        public override string ToString() { return $"{Timestamp}: {Num1} {Dau} {Num2} = {Result}"; }
    }
}
