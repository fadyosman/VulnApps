using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Data.SqlServerCe;
using Restful;
using System.Globalization;

/// <summary>
/// Summary description for TransactionDB
/// </summary>

namespace DataAccess
{
    public static class TransactionDB
    {
        // Using OleDbConnection to retrieve the data
        // To get this to work, add a line to web.config. My best shot (which does not work):
        // <add name="Data" connectionString="data source=.\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=|DataDirectory|\Riches.mdf;provider=sqloledb" providerName="System.Data.OleDb"/>
        public static object NotWorking_GetTransactionDataForAccountNumber(string accountNumber)
        {
            using (OleDbConnection myConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                string cmd = "SELECT * FROM transaction where acctno = '" + accountNumber + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, myConnection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }

        }
        //Using SqlConnection to retrieve the data
        public static object GetTransactionDataForAccountNumber(string accountNumber)
        {
            return GetTransactionData(accountNumber, null, null, null, null, null);
        }

        public static object GetTransactionData(string accountNumber, string description, string amount, string date, string id, string payee)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();

                DateTime parsedDate = default(DateTime);

                String sqlString = "SELECT * FROM [transaction] where acctno = '" + accountNumber + "'";
                if (description != null && description.Any())
                {
                    sqlString += " AND description LIKE '%" + description + "%'";
                }
                if (amount != null && amount.Any())
                {
                    sqlString += " AND ABS(amount) <= " + Double.Parse(amount);
                }
                if (id != null && id.Any())
                {
                    sqlString += " AND [identity] = " + long.Parse(id);
                }
                if (date != null && date.Any())
                {
                    if (DateTime.TryParseExact(date, "MM-dd-yyyy", null, DateTimeStyles.None, out parsedDate))
                    {
                        sqlString += " AND date >= @StartDate";

                    }
                }
                if (payee != null && payee.Any())
                {
                    sqlString += " AND payee LIKE '%" + payee + "%'";
                }

                SqlCeCommand query = new SqlCeCommand(sqlString, connection);
                if (parsedDate != default(DateTime))
                {
                    query.Parameters.AddWithValue("@StartDate", parsedDate);
                }

                SqlCeDataAdapter da = new SqlCeDataAdapter(query);
                DataTable table = new DataTable();
                da.Fill(table);                
                return table;
            }
        }

        public static void addTransaction(String accountNo, String description, Double amount, string payee)
        {
            using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
            {
                connection.Open();
                SqlCeCommand query = new SqlCeCommand("INSERT INTO [transaction] (acctno,description,amount,date,payee) Values(@Account,@Description,@Amount,@Date,@Payee)", connection);
                query.Parameters.AddWithValue("@Account", accountNo);
                query.Parameters.AddWithValue("@Description", description == null ? DBNull.Value : (object)description);
                query.Parameters.AddWithValue("@Amount", amount);
                query.Parameters.AddWithValue("@Date", DateTime.Today);
                query.Parameters.AddWithValue("@Payee", payee == null ? DBNull.Value : (object)payee);

                query.ExecuteNonQuery();
            }
        }

        public static bool Withdraw(Transaction transaction)
        {
            double balance = AccountDB.getBalance(transaction.Acctno);

            if (balance < transaction.Amount)
            {
                return false;
            }
            
            addTransaction(transaction.Acctno, transaction.Description, -transaction.Amount, transaction.Payee);
            AccountDB.updateBalance(transaction.Acctno, balance - transaction.Amount);
            return true;

        }

        public static bool Deposit(Transaction transaction)
        {
            double balance = AccountDB.getBalance(transaction.Acctno);
            addTransaction(transaction.Acctno, transaction.Description, transaction.Amount, null);
            AccountDB.updateBalance(transaction.Acctno, balance + transaction.Amount);
            return true;
        }


    }
}