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
        public ShowCarsOnFerry()
        {
            InitializeComponent();
        }

        private void CarsOnFerryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
