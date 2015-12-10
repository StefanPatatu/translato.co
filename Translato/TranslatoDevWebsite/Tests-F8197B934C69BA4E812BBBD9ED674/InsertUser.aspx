<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertUser.aspx.cs" Inherits="TranslatoDevWebsite.Tests_F8197B934C69BA4E812BBBD9ED674.InsertUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Username:</p>
        <asp:TextBox ID="TBX_User_name" runat="server"></asp:TextBox>
        <p>Password:</p>
        <asp:TextBox ID="TBX_Password" runat="server"></asp:TextBox>
        <p>First name:</p>
        <asp:TextBox ID="TBX_First_name" runat="server"></asp:TextBox>
        <p>Last name:</p>
        <asp:TextBox ID="TBX_Last_name" runat="server"></asp:TextBox>
        <p>Email address:</p>
        <asp:TextBox ID="TBX_Email_address" runat="server"></asp:TextBox>
        <p>Unsubscribe from our newsletter?</p>
        <asp:CheckBox ID="CBX_Unsubscribe" runat="server" />
        <br />
        <asp:Button ID="BTN_Register" runat="server" Text="Register" onclick="registerUser"/>
        <br />
        <asp:Label ID="LBL_Output_text" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
