using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mei.Models
{
    public class MainWindowModel
    {

        public int ItemID { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }

        public string? ItemCategory { get; set; }
        public string? ItemImg { get; set; }
        public int ItemQty { get; set; }

        public List<string>? Category { get; set; } = new List<string>();




    }
}
