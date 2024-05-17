using DTO.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
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
    /// Interaction logic for APIWindow.xaml
    /// </summary>
    public partial class APIWindow : Window
    {
        public APIWindow()
        {
            InitializeComponent();

            //Besked
            //
            //Havde problemer med, at min localhost's SSL certifikat ikke kunne godkendes og blev dømt invalid
            //Så kunne ikke bruge API'en heri uden at køre koden nedenfor. Dette var det eneste fix, jeg kunne komme frem til...
            //Tror bare du kan udkommentere det, hvis du gerne vil gerne det normalt (såfremt der ikke er problemer med dit certifikat) :-)
            
            /*handler.ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            return true;
                        };
            */

        }

        private async void ApiFerriesListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ApiFerriesListbox.SelectedItem != null)
            {
                Ferry ferry = (Ferry)ApiFerriesListbox.SelectedItem;

 
                Ferry selectedFerry = await GetFerryByIdAsync(ferry.FerryID);

                if (selectedFerry != null)
                {
                    FerryIDTxt.Text = selectedFerry.FerryID.ToString();
                    FerryNameTxt.Text = selectedFerry.Name;
                    FerryNumberOfPassengersTxt.Text = selectedFerry.MaxNumberOfPassengers.ToString();
                    FerryNumberOfCarsTxt.Text = selectedFerry.MaxNumberOfCars.ToString();
                    FerryPriceCarsTxt.Text = selectedFerry.PriceCars.ToString();
                    FerryPricePassengersTxt.Text = selectedFerry.PricePassengers.ToString();
                }
            }
        }

        private async void GetFerriesBtn_Click(object sender, RoutedEventArgs e)
        {
            ApiFerriesListbox.ItemsSource = await ApiGetAllFerriesAsync();
        }

        private void EditFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            Ferry ferry = (Ferry)ApiFerriesListbox.SelectedItem;
            int id = ferry.FerryID;


            Ferry updatedFerry = new Ferry
            {
                FerryID = id,
                Name = FerryNameTxt.Text,
                MaxNumberOfPassengers = int.Parse(FerryNumberOfPassengersTxt.Text),
                MaxNumberOfCars = int.Parse(FerryNumberOfCarsTxt.Text),
                PricePassengers = int.Parse(FerryPricePassengersTxt.Text),
                PriceCars = int.Parse(FerryPriceCarsTxt.Text)
            };

             UpdateFerryAsync(id, updatedFerry);
        }

        private void DeleteFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ApiFerriesListbox.SelectedItem != null) {
                Ferry fToDelete = (Ferry) ApiFerriesListbox.SelectedItem;
                 DeleteFerryAsync(fToDelete.FerryID);
            } else
            {
                MessageBox.Show("Vælg en færge først");
            }
        }

        private void CreateNewFerryBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ferry newFerry = new Ferry
                {
                    Name = FerryNameTxt.Text,
                    MaxNumberOfPassengers = int.Parse(FerryNumberOfPassengersTxt.Text),
                    MaxNumberOfCars = int.Parse(FerryNumberOfCarsTxt.Text),
                    PricePassengers = int.Parse(FerryPricePassengersTxt.Text),
                    PriceCars = int.Parse(FerryPriceCarsTxt.Text)
                };
                AddFerryAsync(newFerry);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task<List<Ferry>> ApiGetAllFerriesAsync()
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            return true;
                        };
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage response = await client.GetAsync("https://localhost:44332/api/Ferry");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<Ferry> ferries = JsonConvert.DeserializeObject<List<Ferry>>(responseBody);

                    return ferries;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Fejl ved hentning af færger: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl: {ex.Message}");
            }

            return null;
        }

        private async Task UpdateFerryAsync(int id, Ferry updatedFerry)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            return true;
                        };
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    string jsonFerry = JsonConvert.SerializeObject(updatedFerry);

                    HttpContent content = new StringContent(jsonFerry, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44332/api/Ferry/UpdateFerry/{id}", content);

                    MessageBox.Show("Færgen blev opdateret med succes.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Fejl ved opdatering af færge: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl: {ex.Message}");
            }
        }

        private async Task DeleteFerryAsync(int id)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            return true;
                        };
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44332/api/Ferry/DeleteFerry/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Færgen blev slettet med succes.");
                    }
                    else
                    {
                        MessageBox.Show("Der opstod en fejl ved sletning af færgen.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Fejl ved sletning af færge: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl: {ex.Message}");
            }
        }

        private async Task AddFerryAsync(Ferry newFerry)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            return true;
                        };
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    string jsonFerry = JsonConvert.SerializeObject(newFerry);

                    HttpContent content = new StringContent(jsonFerry, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:44332/api/Ferry/AddFerry?", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Færgen blev oprettet med succes.");
                        FerryNameTxt.Text = "";
                        FerryNumberOfPassengersTxt.Text = "";
                        FerryNumberOfCarsTxt.Text = "";
                        FerryPricePassengersTxt.Text = "";
                        FerryPriceCarsTxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Der opstod en fejl ved oprettelse af færgen.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Fejl ved oprettelse af færge: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl: {ex.Message}");
            }
        }

        private async Task<Ferry> GetFerryByIdAsync(int id)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            return true;
                        };
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage response = await client.GetAsync($"https://localhost:44332/api/Ferry/getferry/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Ferry ferry = JsonConvert.DeserializeObject<Ferry>(responseBody);
                        return ferry;
                    }
                    else
                    {
                        MessageBox.Show($"Fejl ved hentning af færgen med id {id}: {response.ReasonPhrase}");
                        return null;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Fejl ved hentning af færgen med id {id}: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl: {ex.Message}");
                return null;
            }
        }

    }
}