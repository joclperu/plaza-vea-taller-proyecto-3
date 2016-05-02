using System;
using System.Data;
using System.Configuration;

namespace SPV.DA
{
    public static class DataBaseHelper
    {
        public static string GetDbProvider()
        {
            return ConfigurationManager.ConnectionStrings["SPVConecctionString"].ProviderName;
        }

        public static string GetDbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SPVConecctionString"].ConnectionString;
        }
    }
}