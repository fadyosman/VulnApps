using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Configuration;

/// <summary>
/// Summary description for MessageDB
/// </summary>
namespace DataAccess
{
    public class MessageDB
    {
        public MessageDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static String InsertMessage(String Sender, String eMail, String severity, String subject, String body)
        {
            String userName = DataAccess.MembershipDB.getUsernameForEmail(eMail);
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("INSERT INTO message (username,date,sender,severity,subject,body) Values(@Username,@Date,@Sender,@Severity,@Subject,@Body)", connection);
                query.Parameters.AddWithValue("@Username", userName);
                query.Parameters.AddWithValue("@Date", DateTime.Today);
                query.Parameters.AddWithValue("@Sender", Sender);
                query.Parameters.AddWithValue("@Severity", severity);
                query.Parameters.AddWithValue("@Subject", subject);
                query.Parameters.AddWithValue("@Body", body);

                query.ExecuteNonQuery();

                return userName;
            }
        }


    }

}