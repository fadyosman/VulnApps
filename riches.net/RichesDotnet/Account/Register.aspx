<%@ Page Title="Register" Language="C#" MasterPageFile="~/Anonymous/AnonymousMasterPage.master"  AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <b>Sign Up with Riches Wealth International today!</b>
<% String fileName = Request.Params["template"];
   if (fileName != null)
   {
       Response.WriteFile(fileName);
   }
    %>

    <asp:CreateUserWizard ID="CreateUserWizard1" Runat="server" >
  <WizardSteps>
    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
    </asp:CreateUserWizardStep>
      <asp:WizardStep runat="server" Title="Profile" StepType="Step">
            &nbsp;First Name :<br />
            <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox><br />
            &nbsp;Last Name :<br />
            <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox><br />
            &nbsp;SSN :<br />
            <asp:TextBox ID="SSNTextBox" runat="server"></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="SSNTextBox" runat="server"
        ErrorMessage="You must enter a valid SSN. Format: XXX-XX-XXXX" ValidationExpression="\d\d\d-\d\d-\d\d\d\d"> </asp:RegularExpressionValidator>
      </asp:WizardStep>
    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
    </asp:CompleteWizardStep>
  </WizardSteps>
        <StepNavigationTemplate>
            <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" 
                CommandName="MovePrevious" Text="Previous" />
            <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" 
                onclick="StepNextButton_Click" Text="Next" />
        </StepNavigationTemplate>
</asp:CreateUserWizard>

</asp:Content>