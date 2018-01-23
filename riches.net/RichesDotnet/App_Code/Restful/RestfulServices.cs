using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text.RegularExpressions;
using DataAccess;


namespace Restful
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class RestfulServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "accounts", ResponseFormat = WebMessageFormat.Xml)]
        public List<Account> GetAccounts()
        {
            var table = (DataTable) AccountDB.GetAccountDataForBackup();
            return Account.GetList(table);
        }


        [OperationContract]
        [WebGet(UriTemplate = "accounts/json", ResponseFormat = WebMessageFormat.Json)]
        public List<Account> GetAccountsJson()
        {
            var table = (DataTable) AccountDB.GetAccountDataForBackup();
            return Account.GetList(table);
        }

        [OperationContract]
        [WebGet(UriTemplate = "accounts/{username}", ResponseFormat = WebMessageFormat.Xml)]
        public List<Account> GetAccountsByName(string username)
        {
            var table = (DataTable) AccountDB.GetAccountDataForUser(username);
            return Account.GetList(table);
        }

        [OperationContract]
        [WebGet(UriTemplate = "accounts/{username}/json", ResponseFormat = WebMessageFormat.Json)]
        public List<Account> GetAccountsByNameJson(string username)
        {
            var table = (DataTable)AccountDB.GetAccountDataForUser(username);
            return Account.GetList(table);
        }


        [OperationContract]
        [WebGet(UriTemplate = "accounts/transactions/{acctno}", ResponseFormat = WebMessageFormat.Xml)]
        public List<Transaction> GetTransactions(string acctno)
        {
            var table = (DataTable)TransactionDB.GetTransactionDataForAccountNumber(acctno);
            return Transaction.GetList(table);
        }

        [OperationContract]
        [WebGet(UriTemplate = "accounts/transactions/{acctno}/json", ResponseFormat = WebMessageFormat.Json)]
        public List<Transaction> GetTransactionsJson(string acctno)
        {
            var table = (DataTable)TransactionDB.GetTransactionDataForAccountNumber(acctno);
            return Transaction.GetList(table);
        }


        [OperationContract]
        [WebGet(UriTemplate = "accounts/transactions/search/{acctno}?memo={memo}&amount={amount}&date={date}&id={id}&payee={payee}")]
        public List<Transaction> GetTransactionsSearch(string acctno, string memo, string amount, string date, string id, string payee)
        {
            var table = (DataTable) TransactionDB.GetTransactionData(acctno, memo, amount, date, id, payee);
            return Transaction.GetList(table);
        }

        /**
         * Expects a request with a body of the following form (element order-sensitive):
         * <account>
         *   <balance>123.45</balance>
         *   <username>name</username>
         * </account>
         */
        [OperationContract]
        [WebInvoke(UriTemplate = "accounts", Method = "PUT", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Json)]
        public String AddAccount(Account account)
        {
            var successful = AccountDB.CreateAccount(ref account);
            return successful ?
                "Account " + account.Acctno + " created for user " + account.Username :
                "User " + account.Username + " does not exist";
        }


        [OperationContract]
        [WebInvoke(UriTemplate = "accounts/{acctno}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        public String DeleteAccount(string acctno)
        {
            var successful = AccountDB.DeleteAccount(acctno);
            return "Account " + acctno + (successful ? " deleted" : " does not exist");
        }


        /**
         * Expects a request with a body of the following form (element order-sensitive):
         * <transaction>
         *   <acctno>1234567890</acctno>
         *   <amount>234.12</amount>
         *   <memo>Check description</memo>
         *   <payee>Payee</payee>
         * </transaction>
         */
        [OperationContract]
        [WebInvoke(UriTemplate = "accounts/writecheck", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public String WriteCheck(Transaction transaction)
        {
            bool sufficientFunds = TransactionDB.Withdraw(transaction);
            double balance = AccountDB.getBalance(transaction.Acctno);
            if (!sufficientFunds)
            {
                return "Insufficient funds ($" + balance + ") in account " + transaction.Acctno + " to write check for $" +
                       transaction.Amount;
            }
            return "Check for $" + transaction.Amount + " written with account " + transaction.Acctno + " ($" + balance + " remaining)";
        }

        /**
         * Expects a request with a body of the following form (element order-sensitive):
         * <transaction>
         *   <acctno>1234567890</acctno>
         *   <amount>234.12</amount>
         *   <memo>Bill description</memo>
         *   <payee>Payee</payee>
         * </transaction>
         */
        [OperationContract]
        [WebInvoke(UriTemplate = "accounts/transactions/paybill", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public String PayBill(Transaction transaction)
        {
            bool sufficientFunds = TransactionDB.Withdraw(transaction);
            double balance = AccountDB.getBalance(transaction.Acctno);
            if (!sufficientFunds)
            {
                return "Insufficient funds ($" + balance + ") in account " + transaction.Acctno + " to pay bill of $" +
                       transaction.Amount;
            }
            return "Bill of $" + transaction.Amount + " paid with account " + transaction.Acctno + " ($" + balance + " remaining)";
        }


        /**
         * Expects a request with a body of the following form (element order-sensitive):
         * <transaction>
         *   <acctno>1234567890</acctno>
         *   <amount>234.12</amount>
         *   <memo>Deposit description</memo>
         * </transaction>
         */
        [OperationContract]
        [WebInvoke(UriTemplate = "accounts/transactions/deposit", Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Json)]
        public String Deposit(Transaction transaction)
        {
            TransactionDB.Deposit(transaction);
            double balance = AccountDB.getBalance(transaction.Acctno);
            return "Deposit of $" + transaction.Amount + " made to account " + transaction.Acctno + " ($" + balance + " remaining)";
        }
    }
}