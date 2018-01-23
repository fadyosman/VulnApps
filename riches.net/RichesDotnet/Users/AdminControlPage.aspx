<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.master" AutoEventWireup="true" CodeFile="AdminControlPage.aspx.cs" Inherits="AdminControlPage"  validateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
Shell Command<br />
<asp:TextBox ID="ShellCommandTextBox" runat="server" size="80"></asp:TextBox><br />
<asp:Button ID="Button1" runat="server" Text="Execute" 
    onclick="Button1_Click" />



<br /><br />
Automated shutdown message (sent to everyone by default)<br />
<asp:TextBox ID="MessageTextBox" runat="server" size="80"></asp:TextBox>
<br />
<p><i>Send to Specific Users (semicolon seperated list)</i><br />
<asp:TextBox ID="UsersTextBox" runat="server" size="80"></asp:TextBox>
    <br/>
    <asp:Button ID="BroadcastAlertButton" runat="server" Text="Broadcast Alert" 
        onclick="BroadcastAlertButton_Click" />


<br /><br /><b>Debug Code</b><br />
<i>Note: This code should be removed once debugging is complete for bug 192203 
    <br />
    (inspection of database contents)</i><br />
Account Number <asp:TextBox ID="AccountNoTextBox" runat="server"></asp:TextBox>
    <br />
&nbsp;<asp:Button ID="RetrieveButton" runat="server" Text="Retrieve" 
        onclick="RetrieveButton_Click" />
<br />
<asp:Label ID="OutputLabel" runat="server"  Font-Bold="True" Font-Size="X-Large" ></asp:Label><br />
    <asp:Label ID="ErrorLabel" runat="server" Font-Bold="True" Font-Size="X-Large" ></asp:Label>
    
    <br />
    <asp:GridView ID="GridViewAccountSummary" runat="server">
    </asp:GridView>
    
</asp:Content>

