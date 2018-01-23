using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Restful
{
    [DataContract(Namespace = "", Name="transaction")]
    public class Transaction
    {
        public Transaction(DataRow row)
        {
            Id = (long) row["identity"];
            Acctno = (string) row["acctno"];
            if (row["description"] != DBNull.Value) Description = (string) row["description"];
            Date = (DateTime) row["date"];
            Amount = (double) row["amount"];
            if (row["payee"] != DBNull.Value) Payee = (string) row["payee"];
        }

        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "acctno")]
        public string Acctno { get; set; }

        [DataMember(Name="memo")]
        public string Description { get; set; }

        [DataMember(Name = "amount")]
        public double Amount{ get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "payee")]
        public string Payee { get; set; }

        public static List<Transaction> GetList(DataTable table)
        {
            var transactions = new List<Transaction>();
            foreach (DataRow row in table.AsEnumerable())
            {
                transactions.Add(new Transaction(row));
            }
            return transactions;
        }
    }
}