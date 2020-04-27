using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_App;

namespace DataMangement
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopData db = new ShopData();

            using (db)
            {
                Shop S1 = new Shop() { ShopID = 1 , ShopName = "GamesTop" , ShopLocation = "Sligo,Ireland" };
                Item I1 = new Item() {ID = 1 , Name = "Need For Speed : Heat" , Price = 59.99f,  ShopID = 1, Shop = S1  }; 
                Item I2 = new Item() {ID = 2 , Name = "Doom Eternal" , Price = 69.99f,  ShopID = 1, Shop = S1  }; 
                Item I3 = new Item() {ID = 3 , Name = "Mandalorian POP Toy" , Price = 21.99f,  ShopID = 1, Shop = S1  }; 
                Item I4 = new Item() {ID = 4 , Name = "League Of Legends Keyring" , Price = 9.99f,  ShopID = 1, Shop = S1  }; 
                Item I5 = new Item() {ID = 5 , Name = "Subnautica" , Price = 20.99f,  ShopID = 1, Shop = S1  };

                Shop S2 = new Shop() { ShopID = 2, ShopName = "Steam", ShopLocation = "Online,Eu" };
                Item I6 = new Item() { ID = 6, Name = "Dark Souls : Remastered", Price = 59.99f, ShopID = 2, Shop = S2 };
                Item I7 = new Item() { ID = 7, Name = "Doom Eternal", Price = 49.99f, ShopID = 2, Shop = S2 };
                Item I8 = new Item() { ID = 8, Name = "CSGO", Price = 0.00f, ShopID = 2, Shop = S2 };
                Item I9 = new Item() { ID = 9, Name = "Pulsar", Price = 14.99f, ShopID = 2, Shop = S2 };
                Item I10 = new Item() { ID = 10, Name = "Subnautica", Price = 11.99f, ShopID = 2, Shop = S2 };

                Shop S3 = new Shop() { ShopID = 3, ShopName = "Origin", ShopLocation = "Online,Eu" };
                Item I11 = new Item() { ID = 11, Name = "Need For Speed : Heat", Price = 29.99f, ShopID = 3, Shop = S3 };
                Item I12 = new Item() { ID = 12, Name = "BattleField V", Price = 39.99f, ShopID = 3, Shop = S3 };
                Item I13 = new Item() { ID = 13, Name = "DeadSpace 3", Price = 10.99f, ShopID = 3, Shop = S3 };
                Item I14 = new Item() { ID = 14, Name = "Apex Legends", Price = 0.00f, ShopID = 3, Shop = S3 };
                Item I15 = new Item() { ID = 15, Name = "Jedi Fallen Order", Price = 55.99f, ShopID = 3, Shop = S3 };

                Shop S4 = new Shop() { ShopID = 4, ShopName = "Cex", ShopLocation = "Sligo,Ireland" };
                Item I16 = new Item() { ID = 16, Name = "Halo 3", Price = 3.99f, ShopID = 4, Shop = S4 };
                Item I17 = new Item() { ID = 17, Name = "MasterCheif Collection", Price = 29.99f, ShopID = 4, Shop = S4 };
                Item I18 = new Item() { ID = 18, Name = "Doom Eternal", Price = 31.99f, ShopID = 4, Shop = S4 };
                Item I19 = new Item() { ID = 19, Name = "Call Of Duty : Modern Warefare", Price = 39.99f, ShopID = 4, Shop = S4 };
                Item I20 = new Item() { ID = 20, Name = "Subnautica", Price = 9.99f, ShopID = 4, Shop = S4 };

                db.Shops.Add(S1);
                db.Shops.Add(S2);
                db.Shops.Add(S3);
                db.Shops.Add(S4);

                Console.WriteLine("Added Shops to db");

                db.Items.Add(I1);
                db.Items.Add(I2);
                db.Items.Add(I3);
                db.Items.Add(I4);
                db.Items.Add(I5);
                db.Items.Add(I6);
                db.Items.Add(I7);
                db.Items.Add(I8);
                db.Items.Add(I9);
                db.Items.Add(I10);
                db.Items.Add(I11);
                db.Items.Add(I12);
                db.Items.Add(I13);
                db.Items.Add(I14);
                db.Items.Add(I15);
                db.Items.Add(I16);
                db.Items.Add(I17);
                db.Items.Add(I18);
                db.Items.Add(I19);
                db.Items.Add(I20);

                Console.WriteLine("Added Items to db");

                db.SaveChanges();

                Console.WriteLine("Saved Changes");
            }
        }
    }
}
