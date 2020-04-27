using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_App
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public int ShopID { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
