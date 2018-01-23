<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.master" AutoEventWireup="true" CodeFile="Check.aspx.cs" Inherits="Users_Check" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

<table bgcolor="LightGoldenrodYellow">
<tr  bgcolor="Tan" ><td>
            <asp:Label ID="Label1" runat="server" Text="Write a check" Font-Bold="True"></asp:Label>
            </td></tr>
            <tr>
                <td align="left">
                    To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:TextBox ID="ToTextBox" runat="server" Width="230px"></asp:TextBox> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    Amount:&nbsp;&nbsp;
                    <asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Address:&nbsp;&nbsp;&nbsp;<asp:TextBox 
                        ID="AddressTextBox" runat="server" Height="76px" 
                        Rows="3" TextMode="MultiLine" Width="195px" 
                        BackColor="LightGoldenrodYellow" ></asp:TextBox><br />
                    Memo: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="MemoTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="Tan" >
                <td>
            <asp:Button ID="SendButton" runat="server" Text="Submit" OnClick="Button1_Click" />
            </td></tr></table>
        <br />
    <asp:Label ID="OutputLabel" runat="server"  Font-Bold="True" 
        Font-Size="X-Large" ForeColor="Red" ></asp:Label>

    <br />

</asp:Content>

