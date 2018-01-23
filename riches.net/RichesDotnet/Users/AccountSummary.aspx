<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.master" AutoEventWireup="true" CodeFile="AccountSummary.aspx.cs" Inherits="Users_AccountSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" ForeColor="Black" GridLines="None" Width="520px">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:HyperLinkField datanavigateurlfields="acctno" 
                datanavigateurlformatstring="~\Users\AccountDetails.aspx?acctno={0}"  
                DataTextField="acctno" 
                HeaderText="Account Number" />
            <asp:BoundField DataField="balance" HeaderText="Current Balance" ReadOnly="True" DataFormatString="{0:C}"/>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
</asp:Content>

