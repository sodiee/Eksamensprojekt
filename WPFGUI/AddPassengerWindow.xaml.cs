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
    /// Interaction logic for AddPassengerWindow.xaml
    /// </summary>
    public partial class AddPassengerWindow : Window
    {
        public AddPassengerWindow(Ferry selectedFerry)
        {
            InitializeComponent();
            this.ferry = selectedFerry;
        }

        FerryBLL ferryBLL = new FerryBLL();
        PassengerBLL passengerBLL = new PassengerBLL();
        Ferry ferry;
        Passenger passengerToAdd;

        private void AddPassengerBtn_Click(object sender, RoutedEventArgs e)
        {
            //opret
            passengerToAdd = new Passenger(PassengerNameTxt.Text, PassengerGenderTxt.Text, int.Parse(PassengerAgeTxt.Text), PassengerBirthdayDaPi.SelectedDate.Value.Date);

            //gem - tror den bliver tilføjet dobbelt her uden ferryid
            //passengerBLL.AddPassenger(passengerToAdd);

            //tilføj til færge
            ferryBLL.AddPassengerToFerry(ferry, passengerToAdd);

            //update færge
            //ferryBLL.UpdateFerry(ferry);

            MessageBox.Show("Gæst er tilføjet til færge");

            this.Close();
        }
    }
}
 