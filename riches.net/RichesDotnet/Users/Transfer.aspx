<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.master" AutoEventWireup="true" CodeFile="Transfer.aspx.cs" Inherits="Users_Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<table bgcolor="LightGoldenrodYellow">
<tr  bgcolor="Tan" ><td>
            <asp:Label ID="Label1" runat="server" Text="Transfer Funds" Font-Bold="True"></asp:Label>
            </td></tr>
            <tr>
                <td align="middle">
                    Transfer From Account:&nbsp;<asp:DropDownList 
                        ID="FromDropDownList" runat="server" DataSourceID="SqlDataSource1" 
                        DataValueField="acctno">
                    </asp:DropDownList>
&nbsp;</td>
            </tr>
                        <tr>
                <td align="middle">
                    Transfer to Account:&nbsp;&nbsp; &nbsp;
                    <asp:DropDownList ID="ToDropDownList" runat="server" 
                        DataSourceID="SqlDataSource1" DataValueField="acctno">
                    </asp:DropDownList>
                    </td>
            </tr>

            <tr>
                <td align="middle">
                    Transfer Amount: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="Tan" >
                <td>
            <asp:Button ID="SendButton" runat="server" Text="Initiate Transfer" OnClick="Button1_Click" />
            </td></tr></table>
        <br />
    <asp:Label ID="OutputLabel" runat="server"  Font-Bold="True" 
        Font-Size="X-Large" ForeColor="Red" ></asp:Label>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlServerCe.4.0"
        ConnectionString="<%$ ConnectionStrings:AppConnection %>" 
        SelectCommand=""></asp:SqlDataSource>

    <br />

</asp:Content>

