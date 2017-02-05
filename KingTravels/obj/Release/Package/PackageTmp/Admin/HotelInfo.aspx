<%@ Page Title="Hotel Info" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="HotelInfo.aspx.cs" Inherits="KingTravels.Admin.HotelInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .carousel-inner > .item > img,
        .carousel-inner > .item > a > img {
            width: 70%;
            margin: auto;
            Height: 250px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">

    <section class="content-header">
        <h1>Hotel</h1>
        <ol class="breadcrumb">
            <li><a href="/Home"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Dashboard</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-solid">
                    <div class="box-body">
                        <blockquote>
                            <p>
                                <b>
                                    <asp:Literal ID="ltrHotelName" runat="server"></asp:Literal></b>
                            </p>
                            <small class="pull-right">
                                <asp:Literal ID="LtrHotelUrl" runat="server"></asp:Literal></small>
                        </blockquote>
                        <dl>
                            <dt>Hotel Policy</dt>
                            <dd>
                                <asp:Literal ID="LtrHotelPolicy" runat="server"></asp:Literal></dd>
                            <dt>Address</dt>
                            <dd>
                                <asp:Literal ID="LtrAddress" runat="server"></asp:Literal></dd>
                            <dd>
                                <asp:Literal ID="LtrContact" runat="server"></asp:Literal></dd>
                            <dt>Descriptions</dt>
                            <dd style="height: 120px; overflow-x: auto; text-align: justify;">
                                <asp:Literal ID="LtrDescription" runat="server"></asp:Literal></dd>
                        </dl>

                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Hotel Images</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                            <ol class="carousel-indicators">
                                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="1" class=""></li>
                                <li data-target="#carousel-example-generic" data-slide-to="2" class=""></li>
                                <li data-target="#carousel-example-generic" data-slide-to="3" class=""></li>
                                <li data-target="#carousel-example-generic" data-slide-to="4" class=""></li>
                            </ol>
                            <div class="carousel-inner">
                                <asp:Repeater ID="rptSlider" runat="server">
                                    <ItemTemplate>
                                        <div <%# Container.ItemIndex == 0 ? "class=\"item active\"" : "class=\"item\"" %>>
                                            <img src='<%#Container.DataItem.ToString()%>' alt="">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                                <span class="fa fa-angle-left"></span>
                            </a>
                            <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                                <span class="fa fa-angle-right"></span>
                            </a>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Attractions</h3>
                    </div>
                    <div class="box-body">
                        <asp:Literal ID="LtrAttractions" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>

        <asp:Panel ID="pnlRoomDetailsList" runat="server">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="box box-solid">
                        <div class="box-header with-border">
                            <h3 class="box-title">Room Details</h3>
                            <div class="box-tools pull-right">
                                <h3 class="box-title">
                                    <asp:Literal ID="ltrCancellationPolicy" runat="server"></asp:Literal>
                                </h3>
                            </div>
                        </div>
                        <div class="form text-left">
                            <div class="box-body">
                                <div class="form-group table-responsive ">
                                    <table id="example2" class="table display responsive table-condensed" width="100%">
                                        <thead>
                                            <tr>
                                                <th># </th>
                                                <th>Room Type</th>
                                                <%--<th>Smoking Preference</th>--%>
                                                <th>Price</th>
                                                <th>Cancellation Policies</th>
                                                <th>Last Cancellation Date</th>
                                                <th>Block Room</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptRooms" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Container.ItemIndex+1 %></td>
                                                        <td>
                                                            <p><%# Eval("RoomTypeName")%></p>
                                                        </td>
                                                        <%--<td>
                                                            <p><%# Eval("SmokingPreference") %></p>
                                                        </td>--%>
                                                        <td>
                                                            <p><%#Eval("Price.CurrencyCode") %> <%# Eval("Price.PublishedPrice") %></p>
                                                        </td>
                                                        <td>
                                                            <ul>
                                                                <%# KingTravels.Admin.HotelInfo.GetPolicies(Eval("CancellationPolicies")) %>
                                                            </ul>
                                                        </td>
                                                        <td><%# Convert.ToString(Eval("LastCancellationDate")).Replace('T',' ') %></td>
                                                        <td><a href="/BlockRoom/<%# Page.RouteData.Values["HotelCode"].ToString() %>/<%# Page.RouteData.Values["ResultIndex"].ToString() %>/<%# Eval("RoomIndex") %>" title="Block Room" class="btn btn-info submit">
                                                            <span class="glyphicon-class">Block Room Now</span></a></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div class="overlay">
            <i class="fa fa-refresh fa-spin"></i>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Scripts" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#liHotel').addClass('active');
            $('#liHotelInfo').addClass('active');
        });

    </script>
</asp:Content>
