using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jottondoborges.Modelo
{
    public class Pagamento
    {
        public int id { get; private set; }
        public int idFuncionario { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataReferente { get; private set; }
        public double valor { get; private set; }

        public Pagamento()
        {
            id = 0;
            idFuncionario = 0;
            DataPagamento = DateTime.MinValue;
            DataReferente = DateTime.MinValue;
            valor = 0;
        }

        public Pagamento(int i, int fid, DateTime dp, DateTime df, double v)
        {
            id = i;
            idFuncionario = fid;
            DataReferente = df;
            DataPagamento = dp;
            valor = v;
        }
    }
}