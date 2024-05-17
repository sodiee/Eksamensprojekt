using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using BLL.BLL;
using DTO.Model;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();
        PassengerBLL passengerBLL = new PassengerBLL();
        Ferry ferry;
        Car car;
        Passenger passenger;

        private void VisFærger_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void FerryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FerryList.SelectedItem != null)
            {
                ferry = (Ferry)FerryList.SelectedItem;

                FerryIDTxt.Text = ferry.FerryID.ToString();
                FerryNameTxt.Text = ferry.Name;
                FerryNumberOfPassengersTxt.Text = ferry.MaxNumberOfPassengers.ToString();
                FerryNumberOfCarsTxt.Text = ferry.MaxNumberOfCars.ToString();
                FerryPriceCarsTxt.Text = ferry.PriceCars.ToString();
                FerryPricePassengersTxt.Text = ferry.PricePassengers.ToString();
            }
        }

        private void EditFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            Ferry temp = (Ferry)FerryList.SelectedItem;
            ferry = new Ferry(temp.FerryID, 
                FerryNameTxt.Text, 
                int.Parse(FerryNumberOfPassengersTxt.Text), 
                int.Parse(FerryNumberOfCarsTxt.Text), 
                int.Parse(FerryPricePassengersTxt.Text), 
                int.Parse(FerryPriceCarsTxt.Text), 
                (List<Passenger>)temp.Passengers, 
                (List<Car>)temp.Cars);
            ferryBLL.UpdateFerry(ferry);
            Reload();
        }

        private void FindFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FerryIDSearchFieldTxt != null)
            {
                string input = FerryIDSearchFieldTxt.Text;

                Regex regex = new Regex(@"^\d+$");

                if (regex.IsMatch(input))
                {
                    int ferryId = int.Parse(input);

                    bool containsFerryId = ferryBLL.GetFerryList().Any(f => f.FerryID == ferryId);

                    if (containsFerryId)
                    {
                        Ferry res = ferryBLL.GetFerry(ferryId);

                        FerryIDSearchFieldTxt.Text = "";
                        FerryList.Items.Clear();
                        FerryList.Items.Add(res);
                    }
                    else
                    {
                        MessageBox.Show("Færge ID ikke fundet i listen.");
                    }
                }
                else
                {
                    MessageBox.Show("Indtast venligst kun et heltal for færge ID.");
                }
            }
        }

        private void ShowPassengersOnFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FerryList.SelectedItem != null)
            {
                Ferry selectedFerry = (Ferry)FerryList.SelectedItem;
            ShowPassengersWindow spw = new ShowPassengersWindow(selectedFerry);
            spw.Show();
            }
            else
            {
                MessageBox.Show("Vælg en færge");
            }
            Reload();
        }

        private void ShowCarsOnFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FerryList.SelectedItem != null)
            {
                Ferry selectedFerry = (Ferry)FerryList.SelectedItem;
                ShowCarsOnFerry scf = new ShowCarsOnFerry(selectedFerry);
                scf.Show();
                Reload();
            }
            else
            {
                MessageBox.Show("Vælg en færge");
            }

        }

        private void AddPassengerToSelectedFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FerryList.SelectedItem != null)
            {
                Ferry selectedFerry = (Ferry)FerryList.SelectedItem;
                AddPassengerWindow apw = new AddPassengerWindow(selectedFerry);
                apw.Show();
                Reload();
            }
            else
            {
                MessageBox.Show("Vælg en færge");
            }

        }

        private void AddCarToSelectedFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FerryList.SelectedItem != null)
            {
                Ferry selectedFerry = (Ferry)FerryList.SelectedItem;
                AddCarWindow acw = new AddCarWindow(selectedFerry);
                acw.Show();
                Reload();
            }
            else
            {
                MessageBox.Show("Vælg en færge");
            }
            
        }

        private void Reload()
        {
            FerryList.Items.Clear();
            foreach (var ferry in ferryBLL.GetFerryList())
            {
                FerryList.Items.Add(ferry);
            }

            FerryIDTxt.Text = "";
            FerryNameTxt.Text = "";
            FerryPriceCarsTxt.Text = "";
            FerryPricePassengersTxt.Text = "";
            FerryNumberOfPassengersTxt.Text = "";
            FerryNumberOfCarsTxt.Text = "";
        }

        private void FerryProfitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FerryList.SelectedItem != null)
            {
                Ferry selectedFerry = (Ferry)FerryList.SelectedItem;
                ShowFerryProfit sfp = new ShowFerryProfit(selectedFerry);
                sfp.Show();
            }
            else
            {
                MessageBox.Show("Vælg en færge");
            }
            Reload();
        }

        private void APIBtn_Click(object sender, RoutedEventArgs e)
        {
            APIWindow aw = new APIWindow();
            aw.Show();
            Reload();
        }
    }
}
