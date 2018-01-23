using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class AdminControlPage : System.Web.UI.Page
{
    String error;
    String output;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        error = "Error: <br/>";
        output = "Output: <br/>";
        if (ShellCommandTextBox != null && !ShellCommandTextBox.Text.Equals(""))
        {
            String [] commands =ShellCommandTextBox.Text.Split(';');
            foreach (String command in commands)
            {
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "/C " + ShellCommandTextBox.Text;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.OutputDataReceived += new DataReceivedEventHandler(OutputDataReceived);
                    p.ErrorDataReceived += new DataReceivedEventHandler(ErrorDataReceived);
                    p.Start();
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    if (!p.WaitForExit(100))
                    {
                        p.Kill();
                    }
                    int code = p.ExitCode;
                }
            }
            OutputLabel.Text = output;
            ErrorLabel.Text = error;
        }

    }

    void ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            error += e.Data;
        }
    }

    void OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            output += e.Data;
        }
    }

    protected void BroadcastAlertButton_Click(object sender, EventArgs e)
    {
        if (!MessageTextBox.Text.Equals(""))
        {
            String processedMessage = MessageTextBox.Text.Replace("<code1>","The system is currently experiencing technical difficulties.");

            if (UsersTextBox.Text.Equals(""))
            {
                List<String> eMailAddresses = DataAccess.MembershipDB.getAllEmail();
                foreach (String  eMail in eMailAddresses)
                {
                    DataAccess.MessageDB.InsertMessage("admin", eMail, "Highest", "Technical Difficulties", processedMessage);
                }
                    
            }
            else
            {
                String [] eMailAddresses = UsersTextBox.Text.Split(';');
                foreach (String eMail in eMailAddresses)
                {
                    DataAccess.MessageDB.InsertMessage("admin", eMail, "Highest", "Technical Difficulties", processedMessage);
                }
            }
        }
    }
    protected void RetrieveButton_Click(object sender, EventArgs e)
    {
        GridViewAccountSummary.DataSource = DataAccess.TransactionDB.GetTransactionDataForAccountNumber(AccountNoTextBox.Text);
        GridViewAccountSummary.DataBind();
    }
}