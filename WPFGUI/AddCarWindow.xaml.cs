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
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
        }

        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();
        Ferry ferry;
        Car carToAdd;

        private void AddCarBtn_Click(object sender, RoutedEventArgs e)
        {
            carToAdd = new Car((Passenger)CarDriverCboBox.SelectedItem, int.Parse(CarNumberOfPassengersTxt.Text), CarNameTxt.Text, CarModelTxt.Text, CarLicensePlateTxt.Text);

            carBLL.AddCar(carToAdd);

            MessageBox.Show("Bilen er tilføjet til færge");

            this.Close();
        }

        private void CarDriverCboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
