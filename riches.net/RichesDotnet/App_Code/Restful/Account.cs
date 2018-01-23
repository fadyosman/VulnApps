using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Restful
{
    [DataContract(Namespace = "", Name="account")]
    public class Account
    {

        public Account(DataRow row)
        {
            Id = (long) row["identity"];
            Acctno = (string) row["acctno"];
            Balance = (double) row["balance"];
            Username = (string) row["username"];
            Ccn = (string) row["ccn"];
        }

        [DataMember(Name="id")]
        public long Id { get; set; }

        [DataMember(Name = "acctno")]
        public string Acctno { get; set; }

        [DataMember(Name = "balance")]
        public double Balance { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "ccn")]
        public string Ccn { get; set; }

        public static List<Account> GetList(DataTable table)
        {
            var accounts = new List<Account>();
            foreach (DataRow row in table.AsEnumerable())
            {
                accounts.Add(new Account(row));
            }
            return accounts;
        }
    }
}