using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jottondoborges.App_Code.DAO
{
    public class Telefone
    {
        public int id { get; private set; }
        public string telefone { get; private set; }
        public int Cliente_id { get; private set; }
        public int Funcionario_id { get; private set; }
        public int Fornecedor_id { get; private set; }


        public Telefone()
        {
            this.id = 0;
            this.telefone = "";
        }

        public Telefone(int id, string tel)
        {
            this.id = id;
            this.telefone = tel;
        }

        public void setCliente(int i)
        {
            Cliente_id = i;
        }

        public void setFuncionario(int i)
        {
            Funcionario_id = i;
        }

        public void setFornecedor(int i)
        {
            Fornecedor_id = i;
        }
    }
}