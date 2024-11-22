using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maytinh.Models
{
    internal class MayTinhM
    {
        public double n1 { get; set; }
        public double n2 { get; set; }
        public double n3 { get; set; }
        public string operation { get; set; }

        public MayTinhM() 
        {
            this.n1 = 0;
            this.n2 = 0;
            this.n3 = 0;
            this.operation = string.Empty;
        }
        public double Evaluate(string expression) 
        { 
            DataTable table = new DataTable(); 
            table.Columns.Add("expression", typeof(string), expression); 
            DataRow row = table.NewRow(); table.Rows.Add(row); 
            return double.Parse((string)row["expression"]); 
        }
    }
}
