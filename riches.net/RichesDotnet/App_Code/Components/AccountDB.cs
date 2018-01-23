using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlServerCe;
using Restful;

namespace DataAccess
{
    /// <summary>
    /// Summary description for AccountDB
    /// </summary>
    public static class AccountDB
    {
        // Using OleDbConnection to retrieve the data
        // To get this to work, add a line to web.config. My best shot (which does not work):
        // <add name="Data" connectionString="data source=.\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=|DataDirectory|\Riches.mdf;provider=sqloledb" providerName="System.Data.OleDb"/>
        public static object NotWorking_GetAccountDataForUser(string p)
        {
            using (OleDbConnection myConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                string cmd = "SELECT * FROM account where username = '"+p+"'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, myConnection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
            
        }

        //Using SqlConnection to retrieve the data
        public static object GetAccountDataForUser(string username)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT * FROM account where username = '" + username + "'", connection);
                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        // this is Admin function
        public static object GetAllAccountData()
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT * FROM account", connection);
                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        public static String getFirstAccount(String username)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT acctno FROM account where username = '" + username + "'", connection);
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
            }
            return null;
        }

        public static Double getBalance(String accountNo)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT balance FROM account where acctno = '" + accountNo + "'", connection);
                using (SqlCeDataReader reader = query.ExecuteReader())
                {
                    // Call Read before accessing data.
                    if (reader.FieldCount == 1)
                    {
                        while (reader.Read())
                        {
                            return (Double)reader[0];
                        }
                    }
                }
            }
            return 0;
        }

        public static void updateBalance(String accountNo, Double new_balance)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("UPDATE account SET balance=@Balance where acctno = '" + accountNo + "'", connection);
                query.Parameters.AddWithValue("@Balance", new_balance);
                query.ExecuteNonQuery();
            }
        }

        public static String getCcn(String accountNo)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT ccn FROM account where acctno = '" + accountNo + "'", connection);
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
            }
            return null;
        }
        //Using SqlConnection to retrieve the data
        public static object GetAccountDataForBackup()
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT * FROM account", connection);
                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        public static bool CreateAccount(ref Account account)
        {
            if (!IsUserExisting(account.Username)) return false;

            do
            {
                account.Acctno = GetNewAcctno();
            } while (IsAcctnoExisting(account.Acctno));

            do
            {
                account.Ccn = GetNewCcn();
            } while (IsCcnExisting(account.Ccn));


            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("INSERT INTO account (username,acctno,balance,ccn) Values(@Username,@Acctno,@Balance,@Ccn)", connection);
                query.Parameters.AddWithValue("@Username", account.Username);
                query.Parameters.AddWithValue("@Acctno", account.Acctno);
                query.Parameters.AddWithValue("@Balance", account.Balance);
                query.Parameters.AddWithValue("@Ccn", account.Ccn);
                query.ExecuteNonQuery();
                return true;
            }
        }

        public static bool DeleteAccount(string acctno)
        {
            bool existing = IsAcctnoExisting(acctno);
            if (existing)
            {
                using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
                {
                    connection.Open();
                    SqlCeCommand query = new SqlCeCommand("DELETE FROM account WHERE acctno = @Acctno", connection);
                    query.Parameters.AddWithValue("@Acctno", acctno);
                    query.ExecuteNonQuery();
                }
            }

            return existing;
        }

        private static String GetNewAcctno()
        {

            String account = "";
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                account += random.Next(0, 9);
            }

            return account;
        }

        private static String GetNewCcn()
        {

            String ccnumber = "";
            Random random = new Random();
            do
            {
                ccnumber = "";

                for (int i = 0; i < 16; i++)
                {
                    ccnumber += random.Next(0,9);
                }
            } while (!IsValid(ccnumber));

            return ccnumber;
        }

        private static bool IsValid(string cardNumber)
        {
            int sum = 0;
            int digit = 0;
            int addend = 0;
            bool timesTwo = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                digit = int.Parse(cardNumber.Substring(i, 1));
                if (timesTwo)
                {
                    addend = digit * 2;
                    if (addend > 9)
                    {
                        addend -= 9;
                    }
                }
                else
                {
                    addend = digit;
                }
                sum += addend;
                timesTwo = !timesTwo;
            }

            int modulus = sum % 10;
            return modulus == 0;
        }

        private static bool IsAcctnoExisting(string acctno)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();

                SqlCeCommand query = new SqlCeCommand("SELECT 'x' from account where acctno = @Acctno", connection);
                query.Parameters.AddWithValue("@Acctno", acctno);
                using (SqlCeDataReader reader = query.ExecuteReader())
                {
                    bool existing = reader.Read();
                    return existing;
                }
            }
        }

        private static bool IsCcnExisting(string ccn)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();

                SqlCeCommand query = new SqlCeCommand("SELECT 'x' from account where ccn = @Ccn", connection);
                query.Parameters.AddWithValue("@Ccn", ccn);
                using (SqlCeDataReader reader = query.ExecuteReader())
                {
                    bool existing = reader.Read();
                    return existing;
                }
            }
        }

        private static bool IsUserExisting(string username)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("SELECT 'x' from profile where username = @Username", connection);
                query.Parameters.AddWithValue("@Username", username);
                using (SqlCeDataReader reader = query.ExecuteReader())
                {
                    bool existing = reader.Read();
                    return existing;
                }
            }
        }
    }

}