using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maytinh.Models
{
    internal class MayTinhM
    {
        public double n1 { get; set; }
        public double n2 { get; set; }
        public string operation { get; set; }

        public MayTinhM() 
        {
            this.n1 = 0;
            this.n2 = 0;
            this.operation = string.Empty;
        }
    }
}
