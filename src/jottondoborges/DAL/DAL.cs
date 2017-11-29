using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace jottondoborges.App_Code.DAL
{
    public class DAL
    {
        protected static string connectionString = ConfigurationManager.ConnectionStrings["Casa"].ConnectionString;
        protected static SqlConnection conn;
        public DAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Casa"].ConnectionString;
        }
    }
}