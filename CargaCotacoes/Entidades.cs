﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace CargaCotacoes
{
    public class CotacaoEntity : TableEntity
    {
        //contrutor com parametros
        public CotacaoEntity(
            string siglaMoeda, string dataCotacao, double valorComercial)
        {
            PartitionKey = siglaMoeda;
            RowKey = dataCotacao;

            SiglaMoeda = siglaMoeda;
            DataCotacao = Convert.ToDateTime(dataCotacao);
            ValorComercial = valorComercial;
        }

        //contrutor padrão
        public CotacaoEntity() { }

        public string SiglaMoeda { get; set; }
        public DateTime DataCotacao { get; set; }
        public double ValorComercial { get; set; }
    }

    public class CotacaoDolarEntity : CotacaoEntity
    {
        public CotacaoDolarEntity(
            string siglaMoeda, string dataCotacao,
            double valorComercial, double valorTurismo) :
            base(siglaMoeda, dataCotacao, valorComercial)
        {
            ValorTurismo = valorTurismo;
        }

        public CotacaoDolarEntity() { }

        public double ValorTurismo { get; set; }
    }
}