using BLL.BLL;
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
    /// Interaction logic for ShowCarsOnFerry.xaml
    /// </summary>
    public partial class ShowCarsOnFerry : Window
    {
        public ShowCarsOnFerry(Ferry selectedFerry)
        {
            InitializeComponent();
            this.ferry = selectedFerry;
        }

        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();
        Ferry ferry;
        Car car;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void CarsOnFerryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car selectedCar = (Car)CarsOnFerryList.SelectedItem;
            if (selectedCar != null)
            {
                CarPassengersList.Items.Clear();
                foreach (var passenger in carBLL.GetPassengersInCar(selectedCar))
                {
                    CarPassengersList.Items.Add(passenger);
                }

                CarIDTxt.Text = selectedCar.CarID.ToString();
                CarNameTxt.Text = selectedCar.Name;
                CarModelTxt.Text = selectedCar.Model;
                CarLicensePlateTxt.Text = selectedCar.LicensePlate;
                CarNumberOfPassengersTxt.Text = selectedCar.NumberOfPassengers.ToString();//CarPassengersList.Items.Count.ToString();

               
            }
        }

        private void CarPassengersList_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CarsOnFerryList_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddPassengerToCarBtn_Click(object sender, RoutedEventArgs e)
        {
            Car selectedCar = (Car)CarsOnFerryList.SelectedItem;
            if (selectedCar != null)
            {
                AddPassengerToCarWindow aptc = new AddPassengerToCarWindow(ferry, selectedCar);
                aptc.Show();
            }
            else
            {
                MessageBox.Show("Vælg en bil");
            }
        }

        private void UpdateCarBtn_Click(object sender, RoutedEventArgs e)
        {
            car = new Car(int.Parse(CarIDTxt.Text),CarNameTxt.Text, CarModelTxt.Text, CarLicensePlateTxt.Text);
            carBLL.UpdateCar(car);
        }

        private void ShowCarsBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsOnFerryList.Items.Clear();
            foreach (var car in ferryBLL.GetCars(ferry))
            {
                CarsOnFerryList.Items.Add(car);
            }
        }

        private void RemoveCarBtn_Click(object sender, RoutedEventArgs e)
        {
            Car selectedCar = (Car)CarsOnFerryList.SelectedItem;
            if (selectedCar != null)
            {
                carBLL.RemoveCar(selectedCar);
            }
            else
            {
                MessageBox.Show("Vælg en bil");
            }
        }
    }
}
