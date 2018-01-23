using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Configuration;

/// <summary>
/// Summary description for MembershipDB
/// </summary>
namespace DataAccess
{
    public class MembershipDB
    {
        public MembershipDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static List<String> getAllEmail()
        {
            List<String> eMailaddresses = new List<string>();
            using (SqlCeConnection connectionApp = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connectionApp.Open();
                SqlCeCommand queryApp = new SqlCeCommand("SELECT Email FROM [Memberships]", connectionApp);
                using (SqlCeDataReader reader = queryApp.ExecuteReader())
                {
                    if (reader.FieldCount == 1)
                    {
                        while (reader.Read())
                        {
                            eMailaddresses.Add((String)reader[0]);
                        }
                    }
                }
                return eMailaddresses;
            }
        }

        public static String getUsernameForEmail(String eMail)
        {
            using (SqlCeConnection connectionApp = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connectionApp.Open();
                SqlCeCommand queryApp = new SqlCeCommand("SELECT UserId FROM [Memberships] WHERE ([Email] = @email)", connectionApp);
                queryApp.Parameters.AddWithValue("@email", eMail);
                Guid uid = new Guid();
                using (SqlCeDataReader reader = queryApp.ExecuteReader())
                {
                    if (reader.FieldCount == 1)
                    {
                        while (reader.Read())
                        {
                            uid = (Guid)reader[0];
                            break;
                        }
                    }
                    else return null;
                }

                SqlCeCommand queryUsername = new SqlCeCommand("SELECT UserName FROM [Users] WHERE ([UserId] = @Userid)", connectionApp);
                queryUsername.Parameters.AddWithValue("@Userid", uid);
                using (SqlCeDataReader readerUsername = queryUsername.ExecuteReader())
                {
                    String userName = null;
                    if (readerUsername.FieldCount == 1)
                    {
                        while (readerUsername.Read())
                        {
                            userName = (String)readerUsername[0];
                            break;
                        }
                    }
                    else return null;
                    return userName;
                }
            }
        }

    }
}