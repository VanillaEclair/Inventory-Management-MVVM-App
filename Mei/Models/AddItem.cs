using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Models
{
    public class AddItem : MainWindowModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCategory { get; set; }
        public int ItemQuantity { get; set; }

        public AddItem(int id, string name, string ItemType, string category, int qty)
        {
            Id = id;
            ItemName = name;
            ItemDescription = ItemType;
            ItemCategory = category;
            ItemQuantity = qty;
        }
    }
}
