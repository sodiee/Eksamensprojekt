using BLL.BLL;
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
using DTO.Model;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for ShowPassengersWindow.xaml
    /// </summary>
    public partial class ShowPassengersWindow : Window
    {
        public ShowPassengersWindow(Ferry selectedFerry)
        {
            InitializeComponent();
            this.ferry = selectedFerry;
        }

        FerryBLL ferryBLL = new FerryBLL();
        PassengerBLL passengerBLL = new PassengerBLL();
        Ferry ferry;
        Passenger passengerToUpdate;

        private void ShowPassengersBtn_Click(object sender, RoutedEventArgs e)
        {
            PassengersOnFerryList.Items.Clear();
            foreach (var passenger in ferryBLL.GetPassengers(ferry))
            {
                PassengersOnFerryList.Items.Add(passenger);
            }
        }

        private void PassengersOnFerryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            passengerToUpdate = (Passenger)PassengersOnFerryList.SelectedItem;
            if (PassengersOnFerryList.SelectedItem != null) 
                {
                PassengerNameTxt.Text = passengerToUpdate.Name;
                PassengerGenderTxt.Text = passengerToUpdate.Gender;
                PassengerAgeTxt.Text = passengerToUpdate.Age.ToString();
                PassengerBirthdayDaPi.SelectedDate = passengerToUpdate.Birthday;
                }
        }

        private void RemovePassengerBtn_Click(object sender, RoutedEventArgs e)
        {
            Passenger selectedPassenger = (Passenger)PassengersOnFerryList.SelectedItem;

            if (selectedPassenger != null)
            {
                passengerBLL.RemovePassenger(selectedPassenger);
            }
            else
            {
                MessageBox.Show("Vælg venligst en passager at fjerne.");
            }
        }

        private void RefreshPassengerList()
        {
            // Fjern alle elementer fra ListBox'en
            PassengersOnFerryList.Items.Clear();

            // Tilføj passagererne på færgen til ListBox'en igen
            foreach (Passenger passenger in ferry.Passengers)
            {
                PassengersOnFerryList.Items.Add(passenger);
            }
        }

        private void UpdatePassengerBtn_Click(object sender, RoutedEventArgs e)
        {
            Passenger selectedPassenger = (Passenger)PassengersOnFerryList.SelectedItem;
            passengerToUpdate = new Passenger(selectedPassenger.PassengerID, PassengerNameTxt.Text, PassengerGenderTxt.Text, int.Parse(PassengerAgeTxt.Text), PassengerBirthdayDaPi.SelectedDate.Value.Date);
            passengerBLL.UpdatePassenger(passengerToUpdate);
        }
    }
}
