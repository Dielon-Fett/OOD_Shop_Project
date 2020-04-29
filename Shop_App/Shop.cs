using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_App
{
    public class Shop 
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopLocation { get; set; }
        public string ShopImg { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}
