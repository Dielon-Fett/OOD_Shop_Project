using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_App
{
    public class ShopData : DbContext
    {
        public ShopData() : base("MyShopData") { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
