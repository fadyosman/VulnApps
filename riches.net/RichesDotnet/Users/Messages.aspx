<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Users_Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" 
        GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
            <asp:HyperLinkField DataNavigateUrlFields="identity" 
                DataNavigateUrlFormatString="ViewMessage.aspx?id={0}" DataTextField="subject" 
                HeaderText="Subject" />
            <asp:BoundField DataField="sender" HeaderText="From" SortExpression="sender" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlServerCe.4.0"
        ConnectionString="<%$ ConnectionStrings:AppConnection %>" 
        SelectCommand="">
    </asp:SqlDataSource>
</asp:Content>

