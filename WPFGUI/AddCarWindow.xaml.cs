﻿using BLL.BLL;
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
        public AddCarWindow(Ferry selectedFerry)
        {
            InitializeComponent();
            this.ferry = selectedFerry;
            CarDriverCboBox.Items.Clear();
            foreach (var passenger in ferryBLL.GetPassengers(ferry))
            {
                CarDriverCboBox.Items.Add(passenger);
            }
        }

        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();
        Ferry ferry;
        Car carToAdd;

        private void AddCarBtn_Click(object sender, RoutedEventArgs e)
        {
            carToAdd = new Car(CarNameTxt.Text, CarModelTxt.Text, CarLicensePlateTxt.Text);

            //carBLL.AddCar(carToAdd);
            ferryBLL.AddCarToFerry(ferry, carToAdd);

            MessageBox.Show("Bilen er tilføjet til færge");

            this.Close();
        }

        /*private void CarDriverCboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarDriverCboBox.Items.Clear();
            foreach (var passenger in ferryBLL.GetPassengers(ferry))
            {
                CarDriverCboBox.Items.Add(passenger);
            }
        }*/
    }
}
