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
using System.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Weißer_Lotus_Desktop_Software
{
    /// <summary>
    /// Interaktionslogik für StockForm.xaml
    /// </summary>
    public partial class StockForm : Window
    {
        private readonly IConfiguration _configuration;

        public StockForm(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public async Task InsertStockAsync(string stockName, string tickerSymbol, decimal targetPrice)
        {
            /*string clientId = _configuration["AzureAd:ClientId"]; // Geändert
            string clientSecret = _configuration["AzureAd:ClientSecret"]; // Geändert
            string tenantId = _configuration["AzureAd:TenantId"]; // Geändert
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Neu hinzugefügt
            */

            string clientId = "446f34e2-db7d-4f86-ba24-9d18d9d13f85";
            string clientSecret = "vBZ8Q~yy71Us0CGmUztq.bOOnAqUXAH.kft~PbOe"; // Geändert
            string tenantId = "ea085534-0401-40a8-9f06-bec169fd72d2"; // Geändert
            string connectionString = @"Server=tcp:weisser-lotus.database.windows.net,1433;Initial Catalog=Weisser Lotus;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
            var confidentialClient = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}/"))
                .Build();






            var authenticationResult = await confidentialClient.AcquireTokenForClient(new[] { "https://database.windows.net//.default" })
                .ExecuteAsync();

            var SqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                // Erhöhen Sie das Verbindungs-Timeout auf 60 Sekunden
                ConnectTimeout = 60
            };
            SqlConnectionStringBuilder.Remove("authentication");

            using (SqlConnection connection = new SqlConnection(SqlConnectionStringBuilder.ConnectionString))
            {
                connection.AccessToken = authenticationResult.AccessToken;
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("INSERT INTO stocks (name, ticker_symbol, target_price) VALUES (@stockName, @tickerSymbol, @targetPrice)", connection))
                {
                    command.Parameters.AddWithValue("@stockName", stockName);
                    command.Parameters.AddWithValue("@tickerSymbol", tickerSymbol);
                    command.Parameters.AddWithValue("@targetPrice", targetPrice);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string stockName = stockNameTextBox.Text;
            string tickerSymbol = tickerSymbolTextBox.Text;
            decimal targetPrice = decimal.Parse(targetPriceTextBox.Text);

            await InsertStockAsync(stockName, tickerSymbol, targetPrice);
        }


        private void OpenHomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow startseite = new MainWindow(((App)Application.Current).Configuration);
            startseite.Show();
            this.Close();
        }


        private void OpenStockFormButton_Click(object sender, RoutedEventArgs e)
        {
            StockForm stockForm = new StockForm(((App)Application.Current).Configuration);
            stockForm.Show();
            this.Close();

        }

        private void OpenAmortisationWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Amortisationsdauer amortisationsdauer = new Amortisationsdauer(((App)Application.Current).Configuration);
            AmortisationsFenster.Navigate(amortisationsdauer);
        }


    }
}
