using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;


namespace CargaCotacoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Obter configurações de acesso...");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));


            Console.WriteLine("Gerar a referência da tabela e criar no storage (caso a mesma não ainda exista)...");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Cotacoes");
            table.CreateIfNotExists();

            /*
            //Incluindo cotação Euro
            Console.WriteLine("Incluindo cotações do Euro (EUR)...");
            Carga.IncluirCotacao(table, "EUR", "2017-03-22 16:59", 3.4071);
            Carga.IncluirCotacao(table, "EUR", "2017-03-23 16:59", 3.3480);

            //Trazendo a cotação do Euro
            Console.WriteLine("Listando cotações do Euro (EUR)...");
            Carga.ListarCotacoes<CotacaoEntity>(table, "EUR");

            //Incluindo a cotação da Libra
            Console.WriteLine("Incluindo cotações da Libra Esterlina (LIB)...");
            Carga.IncluirCotacao(table, "LIB", "2017-03-22 16:59", 3.7980);
            Carga.IncluirCotacao(table, "LIB", "2017-03-22 16:59", 3.8589);

            //Trazendo a cotação da Libra
            Console.WriteLine("Listando cotações da Libra Esterlina (LIB)...");
            Carga.ListarCotacoes<CotacaoEntity>(table, "LIB");

            //Incluindo cotação do dolar por BATCH
            Console.WriteLine("Incluindo cotações do Dólar (USD)...");
            TableBatchOperation batch = new TableBatchOperation();
            batch.Insert(new CotacaoDolarEntity("USD", "2017-03-22 16:59", 3.0800, 3.3300));
            batch.Insert(new CotacaoDolarEntity("USD", "2017-03-23 16:59", 3.1000, 3.3600));
            table.ExecuteBatch(batch);
            
            //Trazendo a cotação do dolar
            Console.WriteLine("Listando cotações do Dólar (USD)...");
            Carga.ListarCotacoes<CotacaoDolarEntity>(table, "USD");

            Console.WriteLine("Finalizado!");
            */

            //Trazendo a cotação do Euro
            Console.WriteLine("Listando cotações do Euro (EUR)...");
            Carga.ListarCotacoes<CotacaoEntity>(table, "EUR");

            //Trazendo a cotação da Libra
            Console.WriteLine("Listando cotações da Libra Esterlina (LIB)...");
            Carga.ListarCotacoes<CotacaoEntity>(table, "LIB");

            //Trazendo a cotação do dolar
            Console.WriteLine("Listando cotações do Dólar (USD)...");
            Carga.ListarCotacoes<CotacaoDolarEntity>(table, "USD");


            Console.ReadKey();
        }
    }
}
