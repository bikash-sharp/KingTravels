<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KingTravels.Admin.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../dist/plugins/bootstrap-slider/slider.css" rel="stylesheet" />
    <script src="../dist/plugins/bootstrap-slider/bootstrap-slider.js"></script>
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
            <div class="col-md-12">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Select Destination</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <div class="row">
                        <div class="col-md-7 col-sm-6">
                            <div role="form">
                                <div class="box-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label for="drpCountry">Country</label>
                                                <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control dropdown-select" AutoPostBack="true" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-6">
                                                <label for="drpCity">City</label>
                                                <asp:DropDownList ID="drpCity" runat="server" CssClass="form-control dropdown-select"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                            </div>
                        </div>
                        <div class="col-md-5 col-sm-6">
                            <div role="form">
                                <div class="box-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12">
                                                <label for="drpTopCity">Top City</label>
                                                <asp:DropDownList ID="drpTopCity" runat="server" CssClass="form-control dropdown-select" AutoPostBack="true" OnSelectedIndexChanged="drpTopCity_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                            </div>
                        </div>
                    </div>

                </div>

                <!-- /.box -->
            </div>

        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Search Hotel</h3>
                    </div>
                    <!-- form start -->
                    <div role="form">
                        <div class="box-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <label for="txtCheckIn">Check In</label>
                                        <asp:TextBox ID="txtCheckIn" runat="server" CssClass="form-control date-picker" Placeholder="Date"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <label for="drpAdults">Adults(18+)</label>
                                        <asp:DropDownList ID="drpAdults" runat="server" CssClass="form-control dropdown-select">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <label for="drpChilds">Children</label>
                                        <asp:DropDownList ID="drpChilds" runat="server" CssClass="form-control dropdown-select">
                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <label for="drpRooms">Room</label>
                                        <asp:DropDownList ID="drpRooms" runat="server" CssClass="form-control dropdown-select">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <label for="drpNight">Nights Stay</label>
                                        <asp:DropDownList ID="drpNight" runat="server" CssClass="form-control dropdown-select">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <label for="drpGuestNationality">Guest Nationality</label>
                                        <asp:DropDownList ID="drpGuestNationality" runat="server" CssClass="form-control dropdown-select"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <label for="drpGuestNationality">Ratings</label>
                                        <asp:TextBox ID="txtRatings" runat="server" CssClass="slider form-control" data-slider-min="1" data-slider-max="5" data-slider-step="1" data-slider-value="[1,5]" data-slider-ticks="[1,2,3,4,5]" data-slider-ticks-labels='["1","2","3","4","5"]' data-slider-ticks-snap-bounds="30" data-slider-orientation="horizontal" data-slider-selection="before" data-slider-id="aqua"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <label style="color: white;">.</label>
                                        <div class="checkbox icheck" style="margin-top: 0px;">
                                            <label>
                                                <asp:CheckBox ID="chkNearBy" runat="server" />
                                                Check Near By Hotel</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary submit" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlHotelList" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <h3 class="box-title">Hotel List</h3>
                        </div>
                        <div class="form text-left">
                            <div class="box-body">
                                <div class="form-group table-responsive ">
                                    <table id="example" class="table display responsive table-condensed" width="100%">
                                        <thead>
                                            <tr>
                                                <th># </th>
                                                <th>Name</th>
                                                <%--<th>Picture</th>--%>
                                                <%--<th>Address</th>--%>
                                                <%--<th>Description</th>--%>
                                                <%--<th>Contact</th>--%>
                                                <th>Rating</th>
                                                <th>Price</th>
                                                <th>Review Url</th>
                                                <th>Book Now</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptHotels" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Container.ItemIndex+1 %></td>
                                                        <td>
                                                            <p><%# Eval("HotelName")%></p>
                                                        </td>
                                                        <%--<td><img src='<%# Eval("HotelPicture") %>' class="img-responsive" title='<%# Eval("HotelName")%>' /></td>--%>
                                                        <%--<td><p><%# Eval("HotelAddress") %></p></td>--%>
                                                        <%--<td><p class="text-justify" style="height:150px;overflow-y:scroll;"><%# Eval("HotelDescription") %></p></td>--%>
                                                        <%--<td><p><%# Eval("HotelContactNo") %></p></td>--%>
                                                        <td>
                                                            <p><%# Eval("StarRating") %></p>
                                                        </td>
                                                        <td>
                                                            <p><%#Eval("Price.CurrencyCode") %> <%# Eval("Price.PublishedPrice") %></p>
                                                        </td>
                                                        <td><a href='<%# String.IsNullOrEmpty(Convert.ToString(Eval("TripAdvisor.ReviewURL")))? "javascript:;" : Eval("TripAdvisor.ReviewURL") %>' target="_blank"><i class="fa fa-eye"></i></a></td>
                                                        <td><a href="/HotelInfo/<%# Eval("HotelCode") %>/<%# Eval("ResultIndex") %>" title="View Details" class="btn btn-success submit">Get Details Now</a></td>
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
        $('.slider').slider();
        $(document).ready(function () {
            $('#liHotel').addClass('active');
            $('#liHotelInfo').addClass('active');

            $('#aqua').css("margin-top", "-5%");
            $('.slider-tick-label-container').css("padding-top", "5%");

           
        });

    </script>
</asp:Content>
