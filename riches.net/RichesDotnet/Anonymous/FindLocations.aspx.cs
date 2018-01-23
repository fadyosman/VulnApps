using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Data;

public partial class Anonymous_FindLocations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.IsAuthenticated)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        if (Request.QueryString["zip"] != null)
        {
            DataTable Dataset = LocationDB.FindAtmByZip(Request.QueryString["zip"]);
            if (Dataset.Rows.Count != 0)
            {
                FillTableWithData(Dataset);
                return;
            }
            else
            {
                NoLocationFound();
            }
        }
    }
    private void NoLocationFound()
    {
        OutputLabel.Visible = true;
        LocationListView.Visible = false;
        OutputLabel.Text = "No locations found";
    }
    private void FillTableWithData(DataTable Data)
    {
        LocationListView.Visible = true;
        OutputLabel.Visible = false;
        LocationListView.DataSource = Data;
        LocationListView.DataBind();
    }
    protected void ATMButton_Click(object sender, EventArgs e)
    {
        if (!ATMZipTextBox.Text.Equals(""))
        {
            DataTable Dataset = LocationDB.FindAtmByZip(ATMZipTextBox.Text);
            if (Dataset.Rows.Count != 0)
            {
                FillTableWithData(Dataset);
                return;
            }
        }
        else
        {
            DataTable Dataset = LocationDB.FindAtmLocationByAddress(ATMAddressTextBox.Text,ATMCityTextBox.Text, ATMStateDropDownList.SelectedValue);
            if (Dataset.Rows.Count != 0)
            {
                FillTableWithData(Dataset);
                return;
            }

        }
        NoLocationFound();
    }
    protected void BranchFindButton_Click(object sender, EventArgs e)
    {
        if (!BranchZipTextBox.Text.Equals(""))
        {
            DataTable Dataset = LocationDB.FindBranchByZip(BranchZipTextBox.Text);
            if (Dataset.Rows.Count != 0)
            {
                FillTableWithData(Dataset);
                return;
            }
        }
        else
        {
            DataTable Dataset = LocationDB.FindBranchLocationByAddress(BranchAddressTextBox.Text, BranchCityTextBox.Text, BranchStateDropDownList.SelectedValue);
            if (Dataset.Rows.Count != 0)
            {
                FillTableWithData(Dataset);
                return;
            }

        }
        NoLocationFound();

    }
}