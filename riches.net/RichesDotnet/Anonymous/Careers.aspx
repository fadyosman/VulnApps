<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous/AnonymousMasterPage.master" AutoEventWireup="true" CodeFile="Careers.aspx.cs" Inherits="Careers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table>
<td valign="top" align="center">


<!-- html bullet list -->

    <br/><br/>
    <b>Positions in San Francisco, CA</b><br/>
    <br>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?j_clerk1">Junior Clerk 1</asp:HyperLink> <br>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?j_clerk2">Junior Clerk 2</asp:HyperLink> <br>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?manager">Manager</asp:HyperLink> <br>
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?s_account">Senior Accountant</asp:HyperLink> <br>

    <br/>
    <b>Positions in San Diego, CA</b><br/>
    <br>
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?sd_ca">No open positions</asp:HyperLink> <br>

    <br/>
    <b>Positions in San Jose, CA</b><br/>
    <br>
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?sj_ca">No open positions</asp:HyperLink> <br>
    <br/>
    <b>Positions in Palo Alto, CA</b><br/>
    <br>
    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?pa_ca">No open positions</asp:HyperLink> <br>
    <br/>
    <b>Positions in New York, NY</b><br/>
    <br>
    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?ny_ca">No open positions</asp:HyperLink> <br>

    <br/>
    <b>Positions in Washington DC</b><br/>
    <br>
    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Anonymous/CareerDetails.aspx?dc_ca">No open positions</asp:HyperLink> <br>


    <br/>
    <br/>
</td>
</table>

</asp:Content>

