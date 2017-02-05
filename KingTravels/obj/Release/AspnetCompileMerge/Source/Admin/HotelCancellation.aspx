<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="HotelCancellation.aspx.cs" Inherits="KingTravels.Admin.HotelCancellation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Scripts" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#liHotel').addClass('active');
            $('#liCancellations').addClass('active');
        });
    </script>
</asp:Content>
