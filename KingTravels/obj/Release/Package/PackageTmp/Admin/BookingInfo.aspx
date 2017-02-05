<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="BookingInfo.aspx.cs" Inherits="KingTravels.Admin.BookingInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .required {
            color: red;
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
            <div class="col-md-12">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title"><% if (HttpContext.Current.Request.FilePath.ToLower().Contains("blockroom"))
                                                  { %>
                            Block Room : Confirm Room Details
                            <% }
                                else
                                { %>
                            Booking <% } %>
                        </h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <asp:Panel ID="pnlBlockRoom" runat="server" Visible="false">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                <div class="form-horizontal">
                                    <div class="box-body">
                                        <div class="form-group">
                                            <label for="txtRoomTypeName" class="col-sm-4 control-label">Room Type Name</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtRoomTypeName" runat="server" CssClass="form-control" Text="---" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="ltrAmenties" class="col-sm-4 control-label">Amenties</label>
                                            <div class="col-sm-8">
                                                <ul class="nav nav-stacked">
                                                    <asp:Literal ID="ltrAmenties" runat="server" Text="<li><a>-----</a></li>"></asp:Literal>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="ltrBedTypes" class="col-sm-4 control-label">Bed Type</label>
                                            <div class="col-sm-8">
                                                <ul class="nav nav-stacked">
                                                    <asp:Literal ID="ltrBedTypes" runat="server" Text="<li><a>-----</a></li>"></asp:Literal>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="ltrCancellationPolicy" class="col-sm-4 control-label">Cancellation Policy</label>
                                            <div class="col-sm-8">
                                                <ul class="nav nav-stacked">
                                                    <asp:Literal ID="ltrCancellationPolicy" runat="server" Text="<li><a>-----</a></li>"></asp:Literal>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtLastCancellationDate" class="col-sm-4 control-label">Last Cancellation Date</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtLastCancellationDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtSmokingPrefs" class="col-sm-4 control-label">Smoking Preference</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtSmokingPrefs" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                <div class="form-horizontal">
                                    <div class="box-body">
                                        <div class="form-group">
                                            <label for="txtAvailability" class="col-sm-4 control-label">Availability</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtAvailability" runat="server" CssClass="form-control" Text="--" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtRoomPrice" class="col-sm-4 control-label">Room Price</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtRoomPrice" runat="server" CssClass="form-control" Text="--" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtDiscount" class="col-sm-4 control-label">Discount</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Text="0" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtServiceTax" class="col-sm-4 control-label">Service Tax</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtServiceTax" runat="server" CssClass="form-control" Text="0" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtTDS" class="col-sm-4 control-label">TDS</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtTDS" runat="server" CssClass="form-control" Text="0" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtTAX" class="col-sm-4 control-label">TAX</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtTAX" runat="server" CssClass="form-control" Text="0" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtExtraGuestCharge" class="col-sm-4 control-label">Extra Guest Charge</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtExtraGuestCharge" runat="server" CssClass="form-control" Text="0" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <!-- /.box-body -->
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                <div class="form-horizontal">
                                    <div class="box-body">
                                        <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="txtHotelPolicy">Hotel Policy</label>
                                                <asp:TextBox ID="txtHotelPolicy" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Style="resize: none;" Text="---" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- /.box-footer -->
                         <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                    <div class="form-group" style="margin-bottom: 0px;">
                                                        <div class="box-header with-border bg-aqua-active">
                                                            <h3 class="box-title active ">Passenger Booking Details</h3>
                                                        </div>
                                                        <table class="table display responsive table-condensed table-bordered" style="margin-bottom: 0px; width: 100% !important;">
                                                            <thead>
                                                                <%--<tr>
                                                                    <th colspan="7" class="text-center">Passenger Details</th>
                                                                    <th colspan="3" class="text-center">Passport Details</th>
                                                                    <th>Action</th>
                                                                </tr>--%>
                                                                <tr>
                                                                    <th class="text-center">SNo</th>
                                                                    <th class="text-center">Title <span class="required">*</span></th>
                                                                    <th class="text-center">First Name <span class="required">*</span></th>
                                                                    <th class="text-center">Middle Name</th>
                                                                    <th class="text-center">Last Name <span class="required">*</span></th>
                                                                    <th class="text-center">Age <span class="required">*</span></th>
                                                                    <th class="text-center">Hotel Passenger <span class="required">*</span></th>
                                                                    <th class="text-center">Lead Passenger <span class="required">*</span></th>
                                                                    <%--<th class="text-center">Passport Number</th>
                                                                    <th class="text-center">Issue Date</th>
                                                                    <th class="text-center">Expiry Date</th>--%>
                                                                    <%--<th></th>--%>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                               <%-- <asp:Repeater ID="rptPassenger" runat="server" ClientIDMode="Static"></asp:Repeater>--%>
                                                                <tr>
                                                                    <th class="text-center" style="vertical-align:middle;">1</th>
                                                                    <th class="text-center" style="width:10%;">
                                                                        <asp:DropDownList ID="drpTitle1" runat="server" CssClass="form-control dropdown-select2">
                                                                            <asp:ListItem Selected="true">Mr</asp:ListItem>
                                                                            <asp:ListItem>Mrs</asp:ListItem>
                                                                            <asp:ListItem>Miss</asp:ListItem>
                                                                            <asp:ListItem>Ms</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </th>
                                                                    <th class="text-center" style="width:20%;"><asp:TextBox ID="txtFirstName1" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox></th>
                                                                    <th class="text-center" style="width:15%;"><asp:TextBox ID="txtMiddleName1" runat="server" CssClass="form-control" Placeholder="Middle Name"></asp:TextBox></th>
                                                                    <th class="text-center" style="width:15%;"><asp:TextBox ID="txtLastName1" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox></th>
                                                                    <th class="text-center" style="width:5%;"><asp:TextBox ID="txtAge1" runat="server" CssClass="form-control" Placeholder="Age"></asp:TextBox></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsHotelPassenger1" runat="server" /></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsLeadPassenger1" runat="server" /></th>
                                                                    <%--<th class="text-center" style="width:15%;"><asp:TextBox ID="txtPPNo1" runat="server" CssClass="form-control" Placeholder="Passport Number"></asp:TextBox></th>
                                                                    <th class="text-center" style="width:10%;"><asp:TextBox ID="txtPPIssueDate1" runat="server" CssClass="form-control date-picker2" Placeholder="Issue Date "></asp:TextBox></th>
                                                                    <th class="text-center" style="width:10%;"><asp:TextBox ID="txtPPExpiryDate1" runat="server" CssClass="form-control date-picker2" Placeholder="Expiry Date"></asp:TextBox></th>--%>
                                                                </tr>
                                                                <tr>
                                                                    <th class="text-center" style="vertical-align:middle;">2</th>
                                                                      <th class="text-center">
                                                                        <asp:DropDownList ID="drpTitle2" runat="server" CssClass="form-control dropdown-select2">
                                                                            <asp:ListItem Selected="true">Mr</asp:ListItem>
                                                                            <asp:ListItem>Mrs</asp:ListItem>
                                                                            <asp:ListItem>Miss</asp:ListItem>
                                                                            <asp:ListItem>Ms</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </th>
                                                                    <th class="text-center"><asp:TextBox ID="txtFirstName2" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtMiddleName2" runat="server" CssClass="form-control" Placeholder="Middle Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtLastName2" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtAge2" runat="server" CssClass="form-control" Placeholder="Age"></asp:TextBox></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsHotelPassenger2" runat="server" /></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsLeadPassenger2" runat="server" /></th>
                                                                    <%--<th class="text-center"><asp:TextBox ID="txtPPNo2" runat="server" CssClass="form-control" Placeholder="Passport Number"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPIssueDate2" runat="server" CssClass="form-control date-picker2" Placeholder="Issue Date"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPExpiryDate2" runat="server" CssClass="form-control date-picker2" Placeholder="Expiry Date"></asp:TextBox></th>--%>
                                                                </tr>
                                                                <tr>
                                                                    <th class="text-center" style="vertical-align:middle;">3</th>
                                                                      <th class="text-center">
                                                                        <asp:DropDownList ID="drpTitle3" runat="server" CssClass="form-control dropdown-select2">
                                                                            <asp:ListItem Selected="true">Mr</asp:ListItem>
                                                                            <asp:ListItem>Mrs</asp:ListItem>
                                                                            <asp:ListItem>Miss</asp:ListItem>
                                                                            <asp:ListItem>Ms</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </th>
                                                                    <th class="text-center"><asp:TextBox ID="txtFirstName3" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtMiddleName3" runat="server" CssClass="form-control" Placeholder="Middle Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtLastName3" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtAge3" runat="server" CssClass="form-control" Placeholder="Age"></asp:TextBox></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsHotelPassenger3" runat="server" /></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsLeadPassenger3" runat="server" /></th>
                                                                    <%--<th class="text-center"><asp:TextBox ID="txtPPNo3" runat="server" CssClass="form-control" Placeholder="Passport Number"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPIssueDate3" runat="server" CssClass="form-control date-picker2" Placeholder="Issue Date"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPExpiryDate3" runat="server" CssClass="form-control date-picker2" Placeholder="Expiry Date"></asp:TextBox></th>--%>
                                                                </tr>
                                                                <tr>
                                                                    <th class="text-center" style="vertical-align:middle;">4</th>
                                                                      <th class="text-center">
                                                                        <asp:DropDownList ID="drpTitle4" runat="server" CssClass="form-control dropdown-select2">
                                                                            <asp:ListItem Selected="true">Mr</asp:ListItem>
                                                                            <asp:ListItem>Mrs</asp:ListItem>
                                                                            <asp:ListItem>Miss</asp:ListItem>
                                                                            <asp:ListItem>Ms</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </th>
                                                                    <th class="text-center"><asp:TextBox ID="txtFirstName4" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtMiddleName4" runat="server" CssClass="form-control" Placeholder="Middle Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtLastName4" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtAge4" runat="server" CssClass="form-control" Placeholder="Age"></asp:TextBox></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsHotelPassenger4" runat="server" /></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsLeadPassenger4" runat="server" /></th>
                                                                    <%--<th class="text-center"><asp:TextBox ID="txtPPNo4" runat="server" CssClass="form-control" Placeholder="Passport Number"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPIssueDate4" runat="server" CssClass="form-control date-picker2" Placeholder="Issue Date"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPExpiryDate4" runat="server" CssClass="form-control date-picker2" Placeholder="ExpiryDate"></asp:TextBox></th>--%>
                                                                </tr>
                                                                <tr>
                                                                    <th class="text-center" style="vertical-align:middle;">5</th>
                                                                      <th class="text-center">
                                                                        <asp:DropDownList ID="drpTitle5" runat="server" CssClass="form-control dropdown-select2">
                                                                            <asp:ListItem Selected="true">Mr</asp:ListItem>
                                                                            <asp:ListItem>Mrs</asp:ListItem>
                                                                            <asp:ListItem>Miss</asp:ListItem>
                                                                            <asp:ListItem>Ms</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </th>
                                                                    <th class="text-center"><asp:TextBox ID="txtFirstName5" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtMiddleName5" runat="server" CssClass="form-control" Placeholder="Middle Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtLastName5" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtAge5" runat="server" CssClass="form-control" Placeholder="Age"></asp:TextBox></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsHotelPassenger5" runat="server" /></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsLeadPassenger5" runat="server" /></th>
                                                                    <%--<th class="text-center"><asp:TextBox ID="txtPPNo5" runat="server" CssClass="form-control" Placeholder="Passport Number"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPIssueDate5" runat="server" CssClass="form-control date-picker2" Placeholder="Issue Date"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPExpiryDate5" runat="server" CssClass="form-control date-picker2" Placeholder="ExpiryDate"></asp:TextBox></th>--%>
                                                                </tr>
                                                                <tr>
                                                                    <th class="text-center" style="vertical-align:middle;">6</th>
                                                                      <th class="text-center">
                                                                        <asp:DropDownList ID="drpTitle6" runat="server" CssClass="form-control dropdown-select2">
                                                                            <asp:ListItem Selected="true">Mr</asp:ListItem>
                                                                            <asp:ListItem>Mrs</asp:ListItem>
                                                                            <asp:ListItem>Miss</asp:ListItem>
                                                                            <asp:ListItem>Ms</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </th>
                                                                    <th class="text-center"><asp:TextBox ID="txtFirstName6" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtMiddleName6" runat="server" CssClass="form-control" Placeholder="Middle Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtLastName6" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtAge6" runat="server" CssClass="form-control" Placeholder="Age"></asp:TextBox></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsHotelPassenger6" runat="server" /></th>
                                                                    <th class="text-center" style="vertical-align:middle;"><asp:CheckBox ID="chkIsLeadPassenger6" runat="server" /></th>
                                                                   <%-- <th class="text-center"><asp:TextBox ID="txtPPNo6" runat="server" CssClass="form-control" Placeholder="Passport Number"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPIssueDate6" runat="server" CssClass="form-control date-picker2" Placeholder="Issue Date"></asp:TextBox></th>
                                                                    <th class="text-center"><asp:TextBox ID="txtPPExpiryDate6" runat="server" CssClass="form-control date-picker2" Placeholder="ExpiryDate"></asp:TextBox></th>--%>
                                                                </tr>
                                                            </tbody>
                                                            <tfoot>
                                                                <%--<tr>
                                                                    <td colspan="10"></td>
                                                                    <td>
                                                                        <asp:Button ID="btnAddRow" runat="server" Text="Add New" CssClass="btn btn-block center-block" UseSubmitBehavior="false" OnClick="btnAddRow_Click" />
                                                                    </td>
                                                                </tr>--%>
                                                                <tr class="gradeX">
                                                                    <td colspan="8" style="vertical-align:top;">
                                                                        <div class="form-horizontal">
                                                                            <div class="box-body">
                                                                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                                                    <div class="form-group" style="margin-bottom: 0px;">
                                                                                        <label for="txtEmail" class="col-sm-2 control-label">Email</label>
                                                                                        <div class="col-sm-10">
                                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text="" placeholder="Email (Optional)" AutoCompleteType="None"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                                                    <div class="form-group" style="margin-bottom: 0px;">
                                                                                        <label for="txtPhNo" class="col-sm-2 control-label">Ph. No</label>
                                                                                        <div class="col-sm-10">
                                                                                            <asp:TextBox ID="txtPhNo" runat="server" CssClass="form-control" Text="" placeholder="Ph. No. (Optional)" AutoCompleteType="None"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tfoot>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 text-center">
                                        <div class="box-footer">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Book Now" CssClass="btn btn-success center-block btn-lg submit" UseSubmitBehavior="true" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                </div>

                    </asp:Panel>
                    <asp:Panel ID="pnlBooking" runat="server" Visible="false" CssClass="row"></asp:Panel>
                </div>

                <!-- /.box -->
            </div>
        </div>
        <div class="overlay">
            <i class="fa fa-refresh fa-spin"></i>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Scripts" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#liHotel').addClass('active');
            $('#liBooking').addClass('active');
            $('.control-label').css("text-align", "left");
            $('.dropdown-select2').select2({
                allowClear: false
            });
        });
    </script>
</asp:Content>
