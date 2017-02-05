<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomError.aspx.cs" Inherits="KingTravels.CustomError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-weight: bold;" onclick="$(this).next().toggle();">
            <%= Server.GetLastError() != null ? Server.GetLastError().Message : "Unable to get last error" %>
        </div>
        <br />
        <div style="">
            <br />

            <%= Server.GetLastError() != null ? (Server.GetLastError().Message + ( Server.GetLastError().InnerException != null ? Server.GetLastError().InnerException.ToString() : "")) : null%>
        </div>
    </form>
</body>
</html>
