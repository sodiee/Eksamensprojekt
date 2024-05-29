using DTO.Model;
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
using System.Windows.Shapes;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for ShowFerryProfit.xaml
    /// </summary>
    public partial class ShowFerryProfit : Window
    {
        public ShowFerryProfit(Ferry Selectedferry)
        {
            InitializeComponent();
            this.ferry = Selectedferry;
        }

        Ferry ferry;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TotalPricePassengersTxt.Text = ferry.Passengers.Count * ferry.PricePassengers + "";
            TotalPriceCarsTxt.Text = ferry.Cars.Count * ferry.PriceCars + "";
            TotalPriceBothTxt.Text = int.Parse(TotalPricePassengersTxt.Text) + int.Parse(TotalPriceCarsTxt.Text) + "";
        }
    }
}
