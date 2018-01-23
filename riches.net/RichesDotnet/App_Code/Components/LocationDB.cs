using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for LocationDB
/// </summary>
namespace DataAccess
{
    public class LocationDB
    {
        public LocationDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //Using SqlConnection to retrieve the data
        public static DataTable FindAtmByZip(String zip)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT * FROM [location] where atm = 'Yes' and zip = '" + zip + "'", connection);
                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }
        public static DataTable FindAtmLocationByAddress(String address, String city, String state)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT * FROM [location] where atm = 'Yes' and address = '" + address + "' and city = '" + city + "' and state = '" + state + "'", connection);
                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        public static DataTable FindBranchByZip(String zip)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT * FROM [location] where atm = 'Yes' and zip = @zip", connection);
                query.Parameters.AddWithValue("@zip", zip);
                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        public static DataTable FindBranchLocationByAddress(String address, String city, String state)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT * FROM [location] where atm = 'Yes' and address = @address and city = @city and state = @state", connection);
                query.Parameters.AddWithValue("@address", address);
                query.Parameters.AddWithValue("@city", city);
                query.Parameters.AddWithValue("@state", state);
                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }
    }
}