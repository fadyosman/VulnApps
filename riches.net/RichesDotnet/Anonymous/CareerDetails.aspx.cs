using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anonymous_CareerDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (var key in Request.QueryString.GetValues(null))
        {
            if (key.Equals("j_clerk1"))
            {
                CareerDetails.Text = "Junior Clerk Position 1: You will work regular business hours. Good benefit program";
                return;
            }
            else if (key.Equals("j_clerk2"))
            {
                CareerDetails.Text = "Junior Clerk Position 2: You will work regular business hours. Good benefit program";
                return;
            }
            else if (key.Equals("manager"))
            {
                CareerDetails.Text = "Manager: Regular business hours. Good benefit program";
                return;
            }
            else if (key.Equals("s_account"))
            {
                CareerDetails.Text = "Senior Accountant: Great pay, good benefit program";
                return;
            }
        }
        String text = "No career found for you!<br>Please check back in " + new Random().Next() + "days.<br>Parameters of the URL:";
        foreach (var key in Request.QueryString.GetValues(null))
        {
            text += key + "<br/>";
        }
        CareerDetails.Text = text;

    }
}