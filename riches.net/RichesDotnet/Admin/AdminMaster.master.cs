using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String userName = HttpContext.Current.User.Identity.Name;
        NameLabel.Text = userName;
        SSNLabel.Text = " "+ new DataAccess.ProfileDB().getSSN(userName);
    }
}
