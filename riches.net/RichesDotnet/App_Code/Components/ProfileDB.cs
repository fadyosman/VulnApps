using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for ProfileDB
/// </summary>
namespace DataAccess
{
    public class ProfileDB
    {
        public ProfileDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public void InsertProfile(String userName, String firstName, String lastName, String SSN)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("INSERT INTO Profile (username,firstname,lastname,ssno) Values(@Username,@FirstName,@LastName,@SSNO)", connection);
                query.Parameters.AddWithValue("@Username", userName);
                query.Parameters.AddWithValue("@FirstName", firstName);
                query.Parameters.AddWithValue("@LastName", firstName);
                query.Parameters.AddWithValue("@SSNO", SSN);

                query.ExecuteNonQuery();
            }
        }

        public String getSSN(String userName)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT ssno FROM [profile] WHERE username = @Username", connection);
                query.Parameters.AddWithValue("@Username", userName);
                using (SqlCeDataReader reader = query.ExecuteReader())
                {
                    // Call Read before accessing data.
                    if (reader.FieldCount == 1)
                    {
                        while (reader.Read())
                        {
                            return (String)reader[0];
                        }
                    }
                }
                return "";
            }
        }

    }
}