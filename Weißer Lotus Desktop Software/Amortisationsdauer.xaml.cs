using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Weißer_Lotus_Desktop_Software
{
    /// <summary>
    /// Interaktionslogik für Amortisationsdauer.xaml
    /// </summary>
    public partial class Amortisationsdauer : Window
    {

        public Amortisationsdauer()
        {
            InitializeComponent();
        }



        private readonly IConfiguration _configuration;
        public Amortisationsdauer(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double stockPrice = double.Parse(StockPriceTextBox.Text);
            double annualDividend = double.Parse(AnnualDividendTextBox.Text);
            double dividendGrowth = double.Parse(DividendGrowthTextBox.Text);

            double totalDividends = 0;
            int year = 0;

            while (totalDividends < stockPrice)
            {
                totalDividends += annualDividend;
                annualDividend += dividendGrowth;
                year++;
            }

            ResultLabel.Content = $"Es dauert {year} Jahre, bis die Summe der Dividenden den Aktienpreis deckt.";
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ihr Code hier
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
            amortisationsdauer.Show();
            this.Close();
        }



    }
}
