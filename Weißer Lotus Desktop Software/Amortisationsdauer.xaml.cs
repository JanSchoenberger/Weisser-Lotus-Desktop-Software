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
    public partial class Amortisationsdauer : Page
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ihr Code hier
        }

      


    }
}
