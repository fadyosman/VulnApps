<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous/AnonymousMasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<% String fileName = "version.txt";
   if (fileName != null)
   {
       Response.WriteFile(fileName);
   }
    %>
</asp:Content>

