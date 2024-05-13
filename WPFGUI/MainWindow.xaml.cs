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

        FærgeBLL færgeBLL = new FærgeBLL();
        Færge færge;

        private void VisFærger_Click(object sender, RoutedEventArgs e)
        {
            FærgeList.Items.Clear();
            for (int i = 1; i == 20; i++)
            {
                færge = færgeBLL.getFærge(i);
                if (færge != null)
                {
                    FærgeList.Items.Add(færge.ToString());
                }
            }
        }
    }
}
