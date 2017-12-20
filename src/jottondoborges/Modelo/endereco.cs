using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jottondoborges.App_Code.DAO
{
    public class Endereco
    {
        public int id { get; private set; }
        public string estado { get; private set; }
        public string cidade { get; private set; }
        public string bairro { get; private set; }
        public string rua { get; private set; }
        public int numero { get; private set; }
        public string complemento { get; private set; }
        public int idFuncionario { get; private set; }
        public int idCliente { get; private set; }
        public int idFornecedor { get; private set; }

        public Endereco()
        {
            id = 0;
            estado = "";
            cidade = "";
            bairro = "";
            rua = "";
            numero = 0;
            complemento = "";
            idFuncionario = 0;
            idCliente = 0;
        }

        public Endereco(int id, string est, string cid, string bairro, string rua, int num, string compl)
        {
            this.id = id;
            estado = est;
            cidade = cid;
            this.bairro = bairro;
            this.rua = rua;
            numero = num;
            complemento = compl;
        }

        public void setFuncionario (int id)
        {
            idFuncionario = id;
        }

        public void setFornecedor(int id)
        {
            idFornecedor = id;
        }

        public void setCliente(int id)
        {
            idCliente = id;
        }
    }
}