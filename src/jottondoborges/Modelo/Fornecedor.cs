using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jottondoborges.App_Code.DAO
{
    public class Fornecedor
    {
        public int id { get; private set; }
        public string nome { get; private set; }
        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public string email { get; private set; }
        public Endereco endereco { get; private set; }
        public Telefone telefone { get; private set; }

        public Fornecedor()
        {
            id = 0;
            nome = "";
            CPF = "";
            CNPJ = "";
            email = "";
            endereco = new Endereco();
            telefone = new Telefone();
        }

        public Fornecedor(int id, string n, string email, Endereco end, Telefone tel)
        {
            this.id = id;
            nome = n;
            this.email = email;
            endereco = end;
            telefone = tel;
        }

        public void setCPF(string cp)
        {
            CPF = cp;
        }
        public void setCNPJ (string cp)
        {
            CNPJ = cp;
        }
    }
}