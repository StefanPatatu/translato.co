<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="WebClient.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Username:</p>
        <asp:TextBox ID="TBUserName" runat="server"></asp:TextBox>
        <p>Password:</p>
        <asp:TextBox ID="TBPassword" runat="server"></asp:TextBox>
        <p>First name:</p>
        <asp:TextBox ID="TBFirstName" runat="server"></asp:TextBox>
        <p>Last name:</p>
        <asp:TextBox ID="TBLastName" runat="server"></asp:TextBox>
        <p>Email address:</p>
        <asp:TextBox ID="TBEmail" runat="server"></asp:TextBox>
        <p>Unsubscribe from our newsletter?</p>
        <asp:CheckBox ID="CBNewsletterOptOut" runat="server" />
        <br />
        <asp:Button ID="Button" runat="server" Text="Register" onclick="RegisterUser"/>
        <br />
        <asp:Label ID="LBResult" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
