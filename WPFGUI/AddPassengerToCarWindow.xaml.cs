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
    /// Interaction logic for AddPassengerToCarWindow.xaml
    /// </summary>
    public partial class AddPassengerToCarWindow : Window
    {
        public AddPassengerToCarWindow(Ferry selectedFerry, Car selectedCar)
        {
            InitializeComponent();
            this.ferry = selectedFerry;
            this.car = selectedCar;
        }
        CarBLL carBLL = new CarBLL();
        FerryBLL ferryBLL = new FerryBLL();
        Car car;
        Ferry ferry;

        private void AddPassengerToCarBtn_Click(object sender, RoutedEventArgs e)
        {
            Passenger selectedPassenger = (Passenger)PassengersList.SelectedItem;
            try
            {
                car.Passengers = carBLL.GetPassengersInCar(car);

                if (car.Passengers.Count >= 5)
                {
                    MessageBox.Show("Der kan kun være 5 gæster i en bil");
                    return;
                }

                carBLL.AddPassengerToCar(car, selectedPassenger);

                MessageBox.Show("Gæst tilføjet til bil");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PassengersList_Loaded(object sender, RoutedEventArgs e)
        {
            PassengersList.Items.Clear();
            foreach (var passenger in ferryBLL.GetPassengers(ferry))
            {
                PassengersList.Items.Add(passenger);
            }
        }
    }
}
