using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weißer_Lotus_Desktop_Software.Models;
using Weißer_Lotus_Desktop_Software.Pages;


namespace Weißer_Lotus_Desktop_Software
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly string _connectionString = @"Server = tcp:weisser - lotus.database.windows.net,1433; Initial Catalog = Weisser Lotus; Persist Security Info = False; User ID =""janschoenberger@outlook.de""; Password =""8D.A/q/V:Nf76Q=""; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False;";
        private readonly string _connectionString = @"Server=tcp:weisser-lotus.database.windows.net,1433;Initial Catalog=Weisser Lotus;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";

        private readonly string _clientId = "446f34e2-db7d-4f86-ba24-9d18d9d13f85";
        private readonly string _tenantId = "ea085534-0401-40a8-9f06-bec169fd72d2";
        public static AzureSqlConnection AzureSqlConnection { get; private set; }

        private readonly IConfiguration _configuration;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }


        public MainWindow(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {


                
        AzureSqlConnection = new AzureSqlConnection(_connectionString, _clientId, _tenantId);
        SqlConnection connection = await AzureSqlConnection.GetConnectionAsync();

                //AzureSqlConnection = new AzureSqlConnection(_connectionString, _clientId, _tenantId);
                //SqlConnection connection = await AzureSqlConnection.GetConnectionAsync();
                //SqlConnection connection = new SqlConnection(_connectionString);
                //connection.AccessToken = await AzureSqlConnection.GetAccessTokenAsync(); 
                // Jetzt haben Sie eine offene Verbindung, die Sie verwenden können.
                // Fügen Sie hier Ihren Datenbankzugriffscode hinzu.

                // Zum Beispiel:
                // using (SqlCommand command = new SqlCommand("SELECT * FROM YourTable", connection))
                // {
                //     using (SqlDataReader reader = await command.ExecuteReaderAsync())
                //     {
                //         // Verarbeiten Sie das Ergebnis
                //     }
                // }
            }
            catch (Exception ex)
            {
                // Behandeln Sie Ausnahmen entsprechend
                Console.WriteLine($"Error: {ex.Message}");
            }
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
            //StockForm stockForm = new StockForm(((App)Application.Current).Configuration);
            //stockForm.Show();
            //this.Close();
            MainFrame.Navigate(new Aktienpreise()); ;


        }

        private void OpenAmortisationWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Amortisationsdauer amortisationsdauer = new Amortisationsdauer(((App)Application.Current).Configuration);
            amortisationsdauer.Show();
            this.Close();
        }


    }



}