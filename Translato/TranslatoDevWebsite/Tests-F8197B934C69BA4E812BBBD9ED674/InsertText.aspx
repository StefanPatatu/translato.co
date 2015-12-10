<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertText.aspx.cs" Inherits="TranslatoDevWebsite.Tests_F8197B934C69BA4E812BBBD9ED674.InsertText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Text:</p>
        <asp:TextBox ID="TBX_Text_data" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="BTN_Submit" runat="server" Text="Submit" onclick="submitText"/>
        <br />
        <asp:Label ID="LBL_Output_text" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LBL_Login_status" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
