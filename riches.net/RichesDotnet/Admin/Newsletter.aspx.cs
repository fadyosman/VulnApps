using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Admin_Newsletter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<String> eMail = DataAccess.MembershipDB.getAllEmail();
        foreach (String address in eMail)
        {

            DataAccess.MessageDB.InsertMessage(User.Identity.Name, address, "High", SubjectTextBox.Text, BodyTextBox.Text);
        }
        SendMail(SubjectTextBox.Text, BodyTextBox.Text);
    }

    protected void SendMail(String subject, String body)
    {
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C \"echo \"" + subject + body + "\" > NUL \"";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.WaitForExit();
        }
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C \"echo Message sent to all customers\"";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            OutputLabel.Text= p.StandardError.ReadToEnd();
            ErrorLabel.Text = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
        }
    }
}
