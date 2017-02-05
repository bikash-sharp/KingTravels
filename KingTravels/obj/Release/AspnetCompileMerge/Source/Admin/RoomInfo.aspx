<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="RoomInfo.aspx.cs" Inherits="KingTravels.Admin.RoomInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Scripts" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#liHotel').addClass('active');
            $('#liHotelInfo').addClass('active');
        });

    </script>
</asp:Content>
