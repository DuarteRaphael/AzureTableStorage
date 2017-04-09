using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace CargaCotacoes
{
    public static class Carga
    {
        //método de incluir cotação
        public static void IncluirCotacao(CloudTable table,
            string siglaMoeda, string dataCotacao, double valorComercial)
        {
            CotacaoEntity cotacao = new CotacaoEntity(siglaMoeda, dataCotacao, valorComercial);

            //criando objeto para operação na tabela
            TableOperation insertOperation = TableOperation.Insert(cotacao);

            //executa a operação na tabela
            table.Execute(insertOperation);
        }

        //método de consulta das cotações
        public static void ListarCotacoes<T>(CloudTable table, string siglaMoeda) where T: CotacaoEntity, new()
        {
            //executando a query
            TableQuery<T> query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, siglaMoeda));

            //varendo a tabela
            foreach (T entity in table.ExecuteQuery(query))
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(JsonConvert.SerializeObject(entity));
            }
            Console.Write(Environment.NewLine);
        }
    }
}
