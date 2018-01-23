<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Newsletter.aspx.cs" Inherits="Admin_Newsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<table bgcolor="LightGoldenrodYellow">
<tr  bgcolor="Tan" ><td>
            <asp:Label ID="Label1" runat="server" Text="Send Message To:" Font-Bold="True"></asp:Label>
            </td></tr>
            <tr>
                <td align="left">
                    To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label 
                        ID="Label2" runat="server" Font-Size="Small" Text="all customers"></asp:Label>
                    </td>
            </tr>
           
            <tr>
                <td align="left">
                    Subject: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="SubjectTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="BodyTextBox" runat="server" Height="214px" Width="700px" 
                        Rows="40" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="Tan" >
                <td>
            <asp:Button ID="SendButton" runat="server" Text="Send" OnClick="Button1_Click" />
            </td></tr></table>
        <br />
    <asp:Label ID="OutputLabel" runat="server"  Font-Bold="True" Font-Size="X-Large" ></asp:Label><br />
    <asp:Label ID="ErrorLabel" runat="server" Font-Bold="True" Font-Size="X-Large" ></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
        SelectCommand="SELECT [Email] FROM [Memberships]" 
        ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>"></asp:SqlDataSource>

</asp:Content>

