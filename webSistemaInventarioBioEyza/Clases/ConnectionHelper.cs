using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webSistemaInventarioBioEyza.Clases
{
    public static class ConnectionHelper
    {

        public static string GetHostingConnectionString()
        {
            string server = "sistemabodega.cduwow2qm1nr.us-east-1.rds.amazonaws.com";
            string database = "sistemaBodega";
            string uid = "admin";
            string password = "admin54321";
            string port = "3306";

            return $"Server={server};Port={port};Database={database};Uid={uid};Pwd={password};";
        }

    }
}