using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Transfer : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Based on the users roll, use the appropriate master (which includes more or less menu items)
        if (User.IsInRole("admin"))
        {
            this.Page.MasterPageFile = "~/Admin/AdminMaster.master";
        }
        else
        {
            this.Page.MasterPageFile = "~/Users/UsersMaster.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = "SELECT [acctno] FROM [account] WHERE username = '" + User.Identity.Name + "'";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String from=FromDropDownList.SelectedValue;
        String to = ToDropDownList.SelectedValue;
        String amount = AmountTextBox.Text;
        Double AmountDouble = Convert.ToDouble(amount);
        Double FromBalance = DataAccess.AccountDB.getBalance(from);
        Double ToBalance = DataAccess.AccountDB.getBalance(to);
        if (FromBalance < AmountDouble)
        {
            OutputLabel.Text = "Not enough funds available";
            return;
        }
        else
        {
            Double newFromBalance = FromBalance - AmountDouble;
            Double newToBalance = ToBalance - AmountDouble;
            DataAccess.AccountDB.updateBalance(from, newFromBalance);
            DataAccess.AccountDB.updateBalance(to, newToBalance);
            DataAccess.TransactionDB.addTransaction(from, "Withdrawl", -AmountDouble, null);
            DataAccess.TransactionDB.addTransaction(to, "Deposit", AmountDouble, null);
            OutputLabel.Text = "Transfer complete";

        }

    }
}