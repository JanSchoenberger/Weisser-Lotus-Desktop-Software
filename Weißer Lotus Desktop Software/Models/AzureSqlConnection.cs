using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;


namespace Weißer_Lotus_Desktop_Software.Models
{
    public class AzureSqlConnection
    {

        private readonly string _connectionString;
        private readonly string _clientId;
        private readonly string _tenantId;

        public AzureSqlConnection(string connectionString, string clientId, string tenantId)
        {
            _connectionString = connectionString;
            _clientId = clientId;
            _tenantId = tenantId;
        }

        public async Task<SqlConnection> GetConnectionAsync()
        {
            try
            {
                var client = PublicClientApplicationBuilder.Create(_clientId)
                .WithTenantId(_tenantId)
                .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
                .Build();

                var authenticationResult = await client.AcquireTokenInteractive(new[] { "https://database.windows.net//.default" })
                .ExecuteAsync();

                var SqlConnectionStringBuilder = new SqlConnectionStringBuilder(_connectionString)
                {
                    // Erhöhen Sie das Verbindungs-Timeout auf 60 Sekunden
                    ConnectTimeout = 60
                };
                SqlConnectionStringBuilder.Remove("authentication");

                var connection = new SqlConnection(SqlConnectionStringBuilder.ConnectionString);
                connection.AccessToken = authenticationResult.AccessToken;

                await connection.OpenAsync();
                return connection;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
