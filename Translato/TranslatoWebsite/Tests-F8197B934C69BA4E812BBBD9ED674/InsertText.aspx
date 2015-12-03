<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertText.aspx.cs" Inherits="TranslatoWebsite.InsertText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="insertText" runat="server">
    <div>
        <p>Text:</p>
        <asp:TextBox ID="TBX_Text_data" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="BTN_Submit" runat="server" Text="Submit" onclick="submitText"/>
        <br />
        <asp:Label ID="LBL_Output_text" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
