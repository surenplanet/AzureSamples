using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace CosmosDB
{
    class Program
    {
        private static readonly string _endpointUri = "https://coursedatabase502.documents.azure.com:443/";
        private static readonly string _primaryKey = "2HUq2xnTlFj1tNPMeZyoJuBnNqAQPwB9lWfEMkte32pevOYrO3fSZhWfJjPGDyxgMaEj1xx7C7Cd2NMYEwgdVg==";
        public static async Task Main(string[] args)
        {
            using (CosmosClient client = new CosmosClient(_endpointUri, _primaryKey))
            {
                DatabaseResponse databaseResponse = await client.CreateDatabaseIfNotExistsAsync("Products");
                Database targetDatabase = databaseResponse.Database;
                await Console.Out.WriteLineAsync($"Database Id:\t{targetDatabase.Id}");
            }
        }
    }
}
