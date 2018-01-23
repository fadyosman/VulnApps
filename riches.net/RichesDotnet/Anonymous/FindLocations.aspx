<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous/AnonymousMasterPage.master"
    AutoEventWireup="true" CodeFile="FindLocations.aspx.cs" Inherits="Anonymous_FindLocations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="color: Black; background-color: LightGoldenrodYellow; border-color: Tan; border-width: 1px; border-style: solid; width: 520px; border-collapse: collapse;" cellpadding="2" cellspacing="0">
        <tr>
            <td align="center" valign="top">
                <table id="findLocs" valign="top" align="left" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr align="left">
                            <td style="background-color: Tan; font-weight: bold;">
                                <br />
                                <b>Find ATM Locations</b>
                            </td>
                            <td width="20" style="background-color: Tan; font-weight: bold;">
                                </td>
                            <td style="background-color: Tan; font-weight: bold;">
                                <br>
                                <b>Find Branch Locations</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table id="atm" valign="top" align="left" border="0" cellpadding="0" cellspacing="0">
                                    <tbody>
                                    <tr><td>&nbsp;</td></tr>
                                        <tr align="left" valign="middle">
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_" style="font-weight: normal;" for="address">
                                                    Address:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="ATMAddressTextBox" runat="server"></asp:TextBox><br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr valign="middle">
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_City" style="font-weight: normal;" for="city">
                                                    City:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="ATMCityTextBox" runat="server"></asp:TextBox>
                                                <br>
                                                <br>
                                            </td>
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_State" style="font-weight: normal;" for="state">
                                                    State:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="ATMStateDropDownList" runat="server">
                                                    <asp:ListItem Value="" Text="Choose a state" />
                                                    <asp:ListItem Value="AL" Text="Alabama"></asp:ListItem>
                                                    <asp:ListItem Value="AK" Text="Alaska"></asp:ListItem>
                                                    <asp:ListItem Value="AZ" Text="Arizona"></asp:ListItem>
                                                    <asp:ListItem Value="AR" Text="Arkansas"></asp:ListItem>
                                                    <asp:ListItem Value="CA" Text="California"></asp:ListItem>
                                                    <asp:ListItem Value="CO" Text="Colorado"></asp:ListItem>
                                                    <asp:ListItem Value="CT" Text="Connecticut"></asp:ListItem>
                                                    <asp:ListItem Value="DE" Text="Delaware"></asp:ListItem>
                                                    <asp:ListItem Value="DC" Text="District of Columbia"></asp:ListItem>
                                                    <asp:ListItem Value="FL" Text="Florida"></asp:ListItem>
                                                    <asp:ListItem Value="GA" Text="Georgia"></asp:ListItem>
                                                    <asp:ListItem Value="HI" Text="Hawaii"></asp:ListItem>
                                                    <asp:ListItem Value="ID" Text="Idaho"></asp:ListItem>
                                                    <asp:ListItem Value="IL" Text="Illinois"></asp:ListItem>
                                                    <asp:ListItem Value="IN" Text="Indiana"></asp:ListItem>
                                                    <asp:ListItem Value="IA" Text="Iowa"></asp:ListItem>
                                                    <asp:ListItem Value="KS" Text="Kansas"></asp:ListItem>
                                                    <asp:ListItem Value="KY" Text="Kentucky"></asp:ListItem>
                                                    <asp:ListItem Value="LA" Text="Louisiana"></asp:ListItem>
                                                    <asp:ListItem Value="ME" Text="Maine"></asp:ListItem>
                                                    <asp:ListItem Value="MD" Text="Maryland"></asp:ListItem>
                                                    <asp:ListItem Value="MA" Text="Massachusetts"></asp:ListItem>
                                                    <asp:ListItem Value="MI" Text="Michigan"></asp:ListItem>
                                                    <asp:ListItem Value="MN" Text="Minnesota"></asp:ListItem>
                                                    <asp:ListItem Value="MS" Text="Mississippi"></asp:ListItem>
                                                    <asp:ListItem Value="MO" Text="Missouri"></asp:ListItem>
                                                    <asp:ListItem Value="MT" Text="Montana"></asp:ListItem>
                                                    <asp:ListItem Value="NE" Text="Nebraska"></asp:ListItem>
                                                    <asp:ListItem Value="NV" Text="Nevada"></asp:ListItem>
                                                    <asp:ListItem Value="NH" Text="New Hampshire"></asp:ListItem>
                                                    <asp:ListItem Value="NJ" Text="New Jersey"></asp:ListItem>
                                                    <asp:ListItem Value="NM" Text="New Mexico"></asp:ListItem>
                                                    <asp:ListItem Value="NY" Text="New York"></asp:ListItem>
                                                    <asp:ListItem Value="NC" Text="North Carolina"></asp:ListItem>
                                                    <asp:ListItem Value="ND" Text="North Dakota"></asp:ListItem>
                                                    <asp:ListItem Value="OH" Text="Ohio"></asp:ListItem>
                                                    <asp:ListItem Value="OK" Text="Oklahoma"></asp:ListItem>
                                                    <asp:ListItem Value="OR" Text="Oregon"></asp:ListItem>
                                                    <asp:ListItem Value="PA" Text="Pennsylvania"></asp:ListItem>
                                                    <asp:ListItem Value="RI" Text="Rhode Island"></asp:ListItem>
                                                    <asp:ListItem Value="SC" Text="South Carolina"></asp:ListItem>
                                                    <asp:ListItem Value="SD" Text="South Dakota"></asp:ListItem>
                                                    <asp:ListItem Value="TN" Text="Tennessee"></asp:ListItem>
                                                    <asp:ListItem Value="TX" Text="Texas"></asp:ListItem>
                                                    <asp:ListItem Value="UT" Text="Utah"></asp:ListItem>
                                                    <asp:ListItem Value="VT" Text="Vermont"></asp:ListItem>
                                                    <asp:ListItem Value="VA" Text="Virginia"></asp:ListItem>
                                                    <asp:ListItem Value="WA" Text="Washington"></asp:ListItem>
                                                    <asp:ListItem Value="WV" Text="West Virginia"></asp:ListItem>
                                                    <asp:ListItem Value="WI" Text="Wisconsin"></asp:ListItem>
                                                    <asp:ListItem Value="WY" Text="Wyoming"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr align="center" valign="middle">
                                            <td valign="middle">
                                                <b>Or</b><br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr valign="middle">
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_Zip" style="font-weight: normal;" for="zip">
                                                    Zip Code:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="ATMZipTextBox" runat="server"></asp:TextBox><br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr align="right" valign="middle">
                                            <td>
                                            </td>
                                            <td align="left">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="ATMButton" runat="server" Text="Find" OnClick="ATMButton_Click" />
                                            </td>
                                        </tr>
                                        <input name="type" value="atm" id="ShowLocations_type" type="hidden">
                                    </tbody>
                                </table>
                            </td>
                            <td>
                            </td>
                            <!-- space -->
                            <td>
                                <table id="branch" valign="top" align="left" border="0" cellpadding="0" cellspacing="0">
                                    <tbody>
                                    <tr><td>&nbsp;</td></tr>
                                        <tr align="left" valign="middle">
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_BranchAddress" style="font-weight: normal;" for="address">
                                                    Address:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="BranchAddressTextBox" runat="server"></asp:TextBox><br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr valign="middle">
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_BranchCity" style="font-weight: normal;" for="city">
                                                    City:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="BranchCityTextBox" runat="server"></asp:TextBox><br>
                                                <br>
                                            </td>
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_BranchState" style="font-weight: normal;" for="state">
                                                    State:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="BranchStateDropDownList" runat="server">
                                                    <asp:ListItem Value="" Text="Choose a state" />
                                                    <asp:ListItem Value="AL" Text="Alabama"></asp:ListItem>
                                                    <asp:ListItem Value="AK" Text="Alaska"></asp:ListItem>
                                                    <asp:ListItem Value="AZ" Text="Arizona"></asp:ListItem>
                                                    <asp:ListItem Value="AR" Text="Arkansas"></asp:ListItem>
                                                    <asp:ListItem Value="CA" Text="California"></asp:ListItem>
                                                    <asp:ListItem Value="CO" Text="Colorado"></asp:ListItem>
                                                    <asp:ListItem Value="CT" Text="Connecticut"></asp:ListItem>
                                                    <asp:ListItem Value="DE" Text="Delaware"></asp:ListItem>
                                                    <asp:ListItem Value="DC" Text="District of Columbia"></asp:ListItem>
                                                    <asp:ListItem Value="FL" Text="Florida"></asp:ListItem>
                                                    <asp:ListItem Value="GA" Text="Georgia"></asp:ListItem>
                                                    <asp:ListItem Value="HI" Text="Hawaii"></asp:ListItem>
                                                    <asp:ListItem Value="ID" Text="Idaho"></asp:ListItem>
                                                    <asp:ListItem Value="IL" Text="Illinois"></asp:ListItem>
                                                    <asp:ListItem Value="IN" Text="Indiana"></asp:ListItem>
                                                    <asp:ListItem Value="IA" Text="Iowa"></asp:ListItem>
                                                    <asp:ListItem Value="KS" Text="Kansas"></asp:ListItem>
                                                    <asp:ListItem Value="KY" Text="Kentucky"></asp:ListItem>
                                                    <asp:ListItem Value="LA" Text="Louisiana"></asp:ListItem>
                                                    <asp:ListItem Value="ME" Text="Maine"></asp:ListItem>
                                                    <asp:ListItem Value="MD" Text="Maryland"></asp:ListItem>
                                                    <asp:ListItem Value="MA" Text="Massachusetts"></asp:ListItem>
                                                    <asp:ListItem Value="MI" Text="Michigan"></asp:ListItem>
                                                    <asp:ListItem Value="MN" Text="Minnesota"></asp:ListItem>
                                                    <asp:ListItem Value="MS" Text="Mississippi"></asp:ListItem>
                                                    <asp:ListItem Value="MO" Text="Missouri"></asp:ListItem>
                                                    <asp:ListItem Value="MT" Text="Montana"></asp:ListItem>
                                                    <asp:ListItem Value="NE" Text="Nebraska"></asp:ListItem>
                                                    <asp:ListItem Value="NV" Text="Nevada"></asp:ListItem>
                                                    <asp:ListItem Value="NH" Text="New Hampshire"></asp:ListItem>
                                                    <asp:ListItem Value="NJ" Text="New Jersey"></asp:ListItem>
                                                    <asp:ListItem Value="NM" Text="New Mexico"></asp:ListItem>
                                                    <asp:ListItem Value="NY" Text="New York"></asp:ListItem>
                                                    <asp:ListItem Value="NC" Text="North Carolina"></asp:ListItem>
                                                    <asp:ListItem Value="ND" Text="North Dakota"></asp:ListItem>
                                                    <asp:ListItem Value="OH" Text="Ohio"></asp:ListItem>
                                                    <asp:ListItem Value="OK" Text="Oklahoma"></asp:ListItem>
                                                    <asp:ListItem Value="OR" Text="Oregon"></asp:ListItem>
                                                    <asp:ListItem Value="PA" Text="Pennsylvania"></asp:ListItem>
                                                    <asp:ListItem Value="RI" Text="Rhode Island"></asp:ListItem>
                                                    <asp:ListItem Value="SC" Text="South Carolina"></asp:ListItem>
                                                    <asp:ListItem Value="SD" Text="South Dakota"></asp:ListItem>
                                                    <asp:ListItem Value="TN" Text="Tennessee"></asp:ListItem>
                                                    <asp:ListItem Value="TX" Text="Texas"></asp:ListItem>
                                                    <asp:ListItem Value="UT" Text="Utah"></asp:ListItem>
                                                    <asp:ListItem Value="VT" Text="Vermont"></asp:ListItem>
                                                    <asp:ListItem Value="VA" Text="Virginia"></asp:ListItem>
                                                    <asp:ListItem Value="WA" Text="Washington"></asp:ListItem>
                                                    <asp:ListItem Value="WV" Text="West Virginia"></asp:ListItem>
                                                    <asp:ListItem Value="WI" Text="Wisconsin"></asp:ListItem>
                                                    <asp:ListItem Value="WY" Text="Wyoming"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr align="center" valign="middle">
                                            <td valign="middle">
                                                <b>Or</b><br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr valign="middle">
                                            <td align="left" valign="top">
                                                <label id="ShowLocations_" style="font-weight: normal;" for="zip">
                                                    Zip Code:
                                                </label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="BranchZipTextBox" runat="server"></asp:TextBox>
                                                <br>
                                                <br>
                                            </td>
                                        </tr>
                                        <tr align="right" valign="middle">
                                            <td>
                                            </td>
                                            <td align="left">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="BranchFindButton" runat="server" Text="Find" OnClick="BranchFindButton_Click" /><br>
                                            </td>
                                        </tr>
                                        <input name="type" value="branch" id="ShowLocations_type" type="hidden">
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <br />
                                <br />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <table>
                    <tbody>
                        <tr>
                            <td colspan="4">
                                <asp:ListView ID="LocationListView" runat="server">
                                    <LayoutTemplate>
                                        <table border="1" align="center" style="color: Black; background-color: LightGoldenrodYellow; border-color: Tan; border-width: 1px; border-style: solid; width: 520px; border-collapse: collapse;" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <th style="background-color: Tan; font-weight: bold;">
                                                    Address
                                                </th>
                                                <th style="background-color: Tan; font-weight: bold;">
                                                    Services
                                                </th>
                                            </tr>
                                            <tr id="ItemPlaceHolder" runat="server">
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr id="Tr1" runat="server">
                                            <td valign="top" align="center" class="EmployeeName">
                                                <asp:Label ID="AddressLabel" runat="server" Text='<%#Eval("address") %>' /><br />
                                                <asp:Label ID="CityLabel" runat="server" Text='<%#Eval("city") %>' />,
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("state") %>' /><br />
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("zip") %>' /><br />
                                            </td>
                                            <td>
                                                Has Branch:<asp:Label runat="server" Text='<%#Eval ("branch") %>' /><br />
                                                Has ATM:<asp:Label ID="Label3" runat="server" Text='<%#Eval ("atm") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table><tr><td><asp:Label ID="OutputLabel" runat="server" Text="" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label></td></tr></table>
            </td>
        </tr>
    </table>
</asp:Content>
