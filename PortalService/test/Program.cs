using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Configuration;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GridPortlet());
        }
        static public SqlConnection connectDb()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["testConnStr"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        static public string GridPortlet()
        {
            string jsonString = string.Empty;
            JsonSerializer json = new JsonSerializer();
            try
            {
                connectDb().Open();
                DataTable dt = new DataTable();
                string queryString = "select * from CompanyTable";
                SqlCommand sqlcm = new SqlCommand(queryString, connectDb());
                SqlDataAdapter adater = new SqlDataAdapter(sqlcm);
                adater.Fill(dt);

                jsonString = JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            finally
            {
                connectDb().Close();
            }

            return jsonString;
        }
    }
}
