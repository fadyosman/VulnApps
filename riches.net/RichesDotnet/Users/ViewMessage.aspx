<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.master"  %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="522px" 
        AutoGenerateRows="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
        BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" 
        ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <Fields>
            <asp:BoundField DataField="date" HeaderText="Date:" SortExpression="date" />
            <asp:BoundField DataField="sender" HeaderText="From:" SortExpression="sender" />
            <asp:BoundField DataField="subject" HeaderText="Subject:" 
                SortExpression="subject" />
            <asp:BoundField DataField="severity" HeaderText="Severity:" 
                SortExpression="severity" HtmlEncode="false"/>
            <asp:BoundField DataField="body" SortExpression="body" />
        </Fields>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
    </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlServerCe.4.0"
        ConnectionString="<%$ ConnectionStrings:AppConnection %>" 
        SelectCommand="SELECT * FROM [message] WHERE ([identity] = @identity)">
            <SelectParameters>
                <asp:QueryStringParameter Name="identity" QueryStringField="id" Type="Int64" />
            </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

