using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Weißer_Lotus_Desktop_Software.Services;

namespace Weißer_Lotus_Desktop_Software
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public EmailNotification EmailNotification { get; private set; }

        public App()
        {
            EmailNotification = new EmailNotification("smtp.example.com", 587, "your-email@example.com", "your-password");
        }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            base.OnStartup(e);
        }
    }

}
