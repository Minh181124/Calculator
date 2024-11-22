using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maytinh.Models;

namespace Maytinh.Service
{
    internal class LichSuMayTinhS
    {
        private List<LichSuMayTinhM> history; 
        public LichSuMayTinhS() 
        { 
            history = new List<LichSuMayTinhM>(); 
        }
        public List<LichSuMayTinhM> GetHistory() 
        {
            return history;
        }
        public void AddToHistory(LichSuMayTinhM ls)
        {
            history.Add(ls);
        }
    }
}
