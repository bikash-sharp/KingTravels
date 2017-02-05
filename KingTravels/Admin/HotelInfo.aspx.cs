using KingTravels_Common;
using KingTravels_Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KingTravels.Admin
{
    //public partial class HotelInfo : KingTravelPage
    public partial class HotelInfo : KingTravelPage
    {
        public string HotelCode
        {
            get
            {
                String hotelCode = null;
                if (this.Page.RouteData.Values["HotelCode"].ToString() != "0" || String.IsNullOrEmpty(this.Page.RouteData.Values["HotelCode"].ToString()))
                    hotelCode = this.Page.RouteData.Values["HotelCode"].ToString();
                return hotelCode;
            }
        }

        public string ResultIndex
        {
            get
            {
                int resultIndex = 0;
                int.TryParse(this.Page.RouteData.Values["ResultIndex"].ToString(), out resultIndex);
                return resultIndex.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckValues();
            }
        }

        public void CheckValues()
        {
            if (this.Page.RouteData.Values.Count > 0)
            {
                if (HotelCode == "0" || ResultIndex == "0")
                {
                    Response.RedirectToRoute("Home");
                }
                else
                {
                    var objHotelInfoRequest = new HotelInfoRequest
                    {
                        HotelCode = HotelCode,
                        ResultIndex = ResultIndex
                    };

                    var hotelResult = DataProviderWrapper.Instance.HotelInfo(objHotelInfoRequest);
                    if (hotelResult != null)
                        if (hotelResult.HotelInfoResult.Error.ErrorCode > 1)
                        {
                            BLFunction.ShowAlert(this, hotelResult.HotelInfoResult.Error.ErrorMessage,
                                ResponseType.WARNING);
                            return;
                        }
                        else
                        {
                            var hotelDetails = hotelResult.HotelInfoResult.HotelDetails;
                            //Do your process
                            if (hotelDetails != null)
                            {
                                ltrHotelName.Text = hotelDetails.HotelName;
                                LtrAddress.Text = hotelDetails.Address;
                                LtrContact.Text = hotelDetails.HotelContactNo;
                                LtrDescription.Text = hotelDetails.Description.Split(';')[1];
                                string hotelUrl = hotelDetails.HotelURL?.ToString();
                                LtrHotelPolicy.Text = hotelDetails.HotelPolicy?.ToString();
                                LtrHotelUrl.Text = "<a href=" + (string.IsNullOrEmpty(hotelUrl) ? "javascript:;" : "http://" + hotelUrl) + " target='_blank'>Visit Hotel Site</a>";
                                foreach (var item in hotelDetails.Attractions)
                                {
                                    LtrAttractions.Text += "<span><b>" + item.Key + "</b>" + item.Value + "</span>&nbsp;";
                                }
                                var images = hotelDetails.Images.Take(5).ToList();
                                if (images.Count > 0)
                                {
                                    rptSlider.DataSource = images;
                                    rptSlider.DataBind();
                                }

                                //Get Room Details
                                var objRoomDetails = new GetHotelRoomRequest
                                {
                                    HotelCode = HotelCode,
                                    ResultIndex = ResultIndex
                                };

                                var RoomDetailsList = DataProviderWrapper.Instance.RoomDetails(objRoomDetails);
                                if (RoomDetailsList != null)
                                {
                                    var HotelRoomResult = RoomDetailsList.GetHotelRoomResult;
                                    if (HotelRoomResult != null)
                                    {
                                        String CancellationText = "Room Cancellation Allowed : ";
                                        if (HotelRoomResult.IsUnderCancellationAllowed)
                                        {
                                            ltrCancellationPolicy.Text = CancellationText + "<span class='glyphicon glyphicon-ok'></span>";
                                        }
                                        else
                                        {
                                            ltrCancellationPolicy.Text = CancellationText + "<span class='glyphicon glyphicon-remove'></span>";
                                        }

                                        var HotelRoomsCL = HotelRoomResult.HotelRoomsDetails;
                                        if (HotelRoomsCL.Count > 0)
                                        {
                                            rptRooms.DataSource = HotelRoomsCL;
                                            rptRooms.DataBind();
                                        }                                       
                                    }
                                }
                            }
                        }
                    else
                    {
                        BLFunction.ShowAlert(this, "Invalid Request", ResponseType.WARNING);
                        return;
                    }
                }
            }
            else
            {
                Response.RedirectToRoute("Home");
            }
        }

        public static string GetPolicies(object CancellationPolicy)
        {
            string Policies = string.Empty;
            if (CancellationPolicy != null)
            {
                var _policies = (List<CancellationPolicy>)CancellationPolicy;
                foreach (var policy in _policies)
                {
                    string Charge = null;
                    if ((int)policy.ChargeType == 2)
                    {
                        Charge = policy.Charge.ToString() + "%";
                    }
                    else //policy.ChargeType == 1
                    {
                        Charge = policy.Currency + " " + policy.Charge.ToString();
                    }
                    Policies += "Charge "+ Charge +", <li>If cancelled between " + policy.FromDate.Replace('T', ' ') + " and " + policy.ToDate.Replace('T', ' ') + "</li>";
                }
            }
            return Policies;
        }
    }
}