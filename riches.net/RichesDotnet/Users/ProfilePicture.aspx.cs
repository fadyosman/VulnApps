using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_ProfilePicture : System.Web.UI.Page
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
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            String fileName = "~/Users/" + FileUpload1.FileName;
            fileName = Server.MapPath(fileName);
            FileUpload1.SaveAs(fileName);
            HyperLink1.NavigateUrl = HttpContext.Current.Request.ApplicationPath + "/Users/" + FileUpload1.FileName;
            HyperLink1.Text = "View your profile picture here";
        }
        else
        {
            HyperLink1.NavigateUrl = HttpContext.Current.Request.ApplicationPath;
            HyperLink1.Text = "";
        }
    }
}