<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.master" AutoEventWireup="true" CodeFile="ProfilePicture.aspx.cs" Inherits="Users_ProfilePicture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
</asp:Content>

