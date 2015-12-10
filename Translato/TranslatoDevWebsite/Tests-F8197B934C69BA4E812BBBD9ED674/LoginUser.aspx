<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs" Inherits="TranslatoDevWebsite.Tests_F8197B934C69BA4E812BBBD9ED674.LoginUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Username or Email:</p>
        <asp:TextBox ID="TBX_User_name_or_Email" runat="server"></asp:TextBox>
        <p>Password:</p>
        <asp:TextBox ID="TBX_Password" runat="server"></asp:TextBox>
        <p>Stay logged in for the next 30 days</p>
        <asp:CheckBox ID="CBX_Stay_logged_in" runat="server" />
        <br />
        <asp:Button ID="BTN_Login" runat="server" Text="Login" onclick="loginUser"/>
        <br />
        <asp:Label ID="LBL_Output_text" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
