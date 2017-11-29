using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jottondoborges.App_Code.DAO
{
    public class Funcionario
    {
        public int id { get; private set; }
        public string nome { get; private set; }
        public bool motorista { get; private set; }
        public bool tecnico { get; private set; }
        public string identidade { get; private set; }
        public string CLT { get; private set; }
        public double salario { get; private set; }
        public string observacao { get; private set; }
        public Endereco endereco { get; private set; }
        public Telefone telefone { get; private set; }

        public Funcionario()
        {
            id = 0;
            nome = "";
            motorista = false;
            tecnico = false;
            identidade = "";
            CLT = "";
            salario = 0.0;
            observacao = "";
            endereco = new Endereco();
            telefone = new Telefone();
        }

        public Funcionario(int id, string n, bool m, bool t, string i, string c, double s, string o, Endereco end, Telefone tel)
        {
            this.id = id;
            nome = n;
            motorista = m;
            tecnico = t;
            identidade = i;
            CLT = c;
            salario = s;
            observacao = o;
            endereco = end;
            telefone = tel;
        }
    }
}