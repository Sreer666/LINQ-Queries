using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SetUp_OracleDb
{
    class Program
    {
        static void Main(string[] args)
        {

            //Demo: Basic ODP.NET Core application for ASP.NET
            // to connect, query, and return results to a web page.
            string ConnectionStrings = "Data Source=FAC5Q;Persist Security Info=True;" + "User ID=AG22649;Password=NaBondha5!";


            //How to connect to an Oracle DB with a DB alias.
            //Uncomment below and comment above.
            //"Data Source=<service name alias>;";

            using (OracleConnection con = new OracleConnection(ConnectionStrings))
            {
                //using (OracleCommand cmd = con.CreateCommand())
                //{
                //    try
                //    {
                //        con.Open();
                //        cmd.BindByName = true;

                //        //Use the command to display employee names from 
                //        // the EMPLOYEES table
                //        cmd.CommandText = "SELECT PLAN_YEAR AS EXPR1 FROM AGP.MEDICARE_ID_FULLFILL_MAP";

                //        // Assign id to the department number 50 
                //        OracleParameter id = new OracleParameter("PLAN_YEAR", 50);
                //        cmd.Parameters.Add(id);

                //        //Execute the command and use DataReader to display the data
                //        OracleDataReader reader = cmd.ExecuteReader();
                //        //while (reader.Read())
                //        //{
                //        //    await Context.Response.WriteAsync("Employee First Name: " + reader.GetString(0) + "\n");
                //        //}

                //        reader.Dispose();
                //    }
                //    catch (Exception ex)
                //    {
                //        //await context.Response.WriteAsync(ex.Message);
                //    }
                try
                {
                    var gridReader = con.Query("SELECT PLAN_YEAR AS EXPR1 FROM AGP.MEDICARE_ID_FULLFILL_MAP");
                    //return gridReader;
                }
                catch (OracleException ex)
                {
                    //ApplicationLogs.Log.Error("Error Occured in RetriveSqlQueryResults Method", ex);
                    throw ex;
                }
            }
        }
    }
}
//MedisysDbQuery == <add key = "MedisysDbQuery" value="User ID=STUSR17;Password=MedPW1;data source=VA10TWVSQL430\SQL01,10001;Initial Catalog=reports;persist security info=False;Connection Timeout=120;"></add>