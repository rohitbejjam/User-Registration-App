<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="UserRegistration.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" style="margin-left: 295px" Text="Member Portal" Width="114px"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblid" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="txtid" runat="server" Width="143px" ></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtid"
  ErrorMessage="Member ID is a required field."
  ForeColor="Red" AccessKey="">
</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblfirstname" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtfirstname" runat="server" Width="143px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbllastname" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Submit" CausesValidation="true" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CausesValidation="true"/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CausesValidation="true" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="grdData" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
