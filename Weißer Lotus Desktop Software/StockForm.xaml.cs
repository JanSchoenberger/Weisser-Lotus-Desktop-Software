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

namespace Weißer_Lotus_Desktop_Software
{
    /// <summary>
    /// Interaktionslogik für StockForm.xaml
    /// </summary>
    public partial class StockForm : Window
    {
        public StockForm()
        {
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
            using (SqlConnection connection = await MainWindow.AzureSqlConnection.GetConnectionAsync())
            {
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




    }
}
