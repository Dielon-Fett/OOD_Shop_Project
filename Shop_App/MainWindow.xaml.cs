using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Shop> allShops = new List<Shop>();
        List<Item> allItems = new List<Item>();


        ShopData db = new ShopData();
        static Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {

            TimeSpan t = endDate - startDate;
            int numberOfDays = t.Days;
            DateTime newDate = startDate.AddDays(r.Next(numberOfDays));
            return newDate;

            
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            //what has the user selected
            Item selectedItem = Items_lbxDisplay.SelectedItem as Item;

            if (selectedItem != null && selectedItem.ShopID != 5)
            {
                //Move Item
                allItems.Remove(selectedItem);
                Items_lbxDisplay.ItemsSource = null;
                Items_lbxDisplay.ItemsSource = allItems;



                //Remove From Shop

                selectedItem.ShopID = 5;
                db.Items.AddOrUpdate(selectedItem);
                db.SaveChanges();

                //Place in invetory
                Invetory_lbxDisplay.ItemsSource = null;
                Invetory_lbxDisplay.ItemsSource = allItems.Where(i => i.ShopID == 5);

            }



        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            Item selectedItem = Items_lbxDisplay.SelectedItem as Item;

            if (selectedItem != null && selectedItem.ShopID == 5)
            {
                allItems.Remove(selectedItem);
                Items_lbxDisplay.ItemsSource = null;
                Items_lbxDisplay.ItemsSource = allItems;
            }
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            var query = from s in db.Shops
                        orderby s.ShopID
                        select s;


            allShops = query.ToList();

            
            
            Shops_lbxDisplay.ItemsSource = allShops;

          

            Shops_lbxDisplay.SelectedItem = 0;
        

            
            _Date.Text = GetRandomDate(DateTime.Now, DateTime.Now).ToString();

        }

        private void Shops_lbxDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            
            int SelectedShopID = Convert.ToInt32(Shops_lbxDisplay.SelectedValue);


            var query = from i in db.Items
                        where i.ShopID == SelectedShopID
                        orderby i.Name
                        select i;


            allItems = query.ToList();
            Invetory_lbxDisplay.ItemsSource = allItems.Where(i => i.ShopID == 5);


            string imageName = (Shops_lbxDisplay.SelectedItem as Shop).ShopImg;
            logo.Source = new BitmapImage(new Uri($"/Images/{imageName}", UriKind.Relative));

            string shopLocation = (Shops_lbxDisplay.SelectedItem as Shop).ShopLocation;

            _Location.Text = shopLocation;
            Items_lbxDisplay.ItemsSource = allItems;    
            _Date.Text = GetRandomDate(DateTime.Now, DateTime.Now).ToString();
            

        }

        private void Items_lbxDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int item = Convert.ToInt32(Items_lbxDisplay.SelectedValue);

            if (item <= 0 )
            {
                _Money.Text = "";
                return;
            }
            var query = from i in db.Items
                        where i.ID == item                        
                        select i.Price;
            float price = query.ToList().First();
            
            _Date.Text = GetRandomDate(DateTime.Now, DateTime.Now).ToString();
            _Money.Text = string.Format("{0:c}",price);
        }
    }
}
