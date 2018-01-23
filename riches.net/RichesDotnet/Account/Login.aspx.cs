using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (User.IsInRole("admin"))
            {
                Response.Redirect("~/Admin");
            }
            else
            {
                Response.Redirect("~/Users/AccountSummary.aspx");
            }
        }
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        Login l = (Login)sender;
        l.FailureText="Invalid credentials for "+l.UserName;
    }
}
