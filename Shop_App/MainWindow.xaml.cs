using System;
using System.Collections.Generic;
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

        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            var query = from s in db.Shops
                        orderby s.ShopID
                        select s;

           

            var shops = query.ToList();
            
            Shops_lbxDisplay.ItemsSource = shops;

          

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




            
           
            string imageName = (Shops_lbxDisplay.SelectedItem as Shop).ShopImg;
            logo.Source = new BitmapImage(new Uri($"/Images/{imageName}", UriKind.Relative));

            string shopLocation = (Shops_lbxDisplay.SelectedItem as Shop).ShopLocation;

            _Location.Text = shopLocation;
            Items_lbxDisplay.ItemsSource = query.ToList();    
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
