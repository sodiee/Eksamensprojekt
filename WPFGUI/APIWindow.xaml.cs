using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Text.Json;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for APIWindow.xaml
    /// </summary>
    public partial class APIWindow : Window
    {
        public APIWindow()
        {
            InitializeComponent();
        }

        private void GetFerriesBtn_Click(object sender, RoutedEventArgs e)
        {
            testTxt.Text = ApiGetAllFerries();
        }

        private string ApiGetAllFerries()
        {
            /*var client = new HttpClient();
            string content = "";
            HttpResponseMessage response = await client.GetAsync("https://localhost:44332/api/Ferry/getferry/1");
            response.EnsureSuccessStatusCode();
            content = await response.Content.ReadAsStringAsync();
            return content;
            */
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            Task<string> task = client.GetStringAsync("https://localhost:44332/api/Ferry/getferry/1");

            String msg = task.Result;

            Ferry person = JsonSerializer.Deserialize<Ferry>(msg);
            
            return msg;
        }
    }
}
