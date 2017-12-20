using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jottondoborges.App_Code.DAO
{
    public class Produto
    {
        public int id { get; private set; }
        public string desc { get; private set; }
        public Produto()
        {
            id = 0;
            desc = "";
        }
        public Produto(string d)
        {
            desc = d;
        }
        public Produto(int i, string d)
        {
            id = i;
            desc = d;
        }
    }
}