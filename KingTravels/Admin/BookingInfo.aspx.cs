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
    public partial class BookingInfo : KingTravelPage
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

        public string RoomIndex
        {
            get
            {
                int resultIndex = 0;
                int.TryParse(this.Page.RouteData.Values["RoomIndex"].ToString(), out resultIndex);
                return resultIndex.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Request.FilePath.ToLower().Contains("blockroom"))
            {
                RunBlockRoomOperation();
                pnlBlockRoom.Visible = true;
                pnlBooking.Visible = false;
            }
            else
            {
                //RunBookingModule();
                pnlBlockRoom.Visible = false;
                pnlBooking.Visible = true;
            }
        }


        public void RunBlockRoomOperation()
        {
            if (this.Page.RouteData.Values.Count > 0)
            {
                if (HotelCode == "0" || ResultIndex == "0" || RoomIndex == "0")
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
                    {
                        if (hotelResult.HotelInfoResult.Error.ErrorCode > 1)
                        {
                            BLFunction.ShowAlert(this, hotelResult.HotelInfoResult.Error.ErrorMessage,ResponseType.WARNING);
                            return;
                        }
                        else
                        {
                            var hotelDetails = hotelResult.HotelInfoResult.HotelDetails;
                            //Get Room Details
                            var objRoomDetails = new GetHotelRoomRequest
                            {
                                HotelCode = HotelCode,
                                ResultIndex = ResultIndex
                            };

                            var RoomDetailsList = DataProviderWrapper.Instance.RoomDetails(objRoomDetails);
                            var _HotelRoomResult = RoomDetailsList.GetHotelRoomResult;
                            
                                //Block Room Testing
                                var HotelRoomsCL = _HotelRoomResult.HotelRoomsDetails;
                            var objBlockRoom = new BlockRoomRequest
                            {
                                HotelCode = HotelCode,
                                HotelName = hotelDetails.HotelName,
                                ResultIndex = ResultIndex,
                                HotelRoomsDetails = new List<HotelRoomsDetail1>(HotelRoomsCL.Where(p => p.RoomIndex.ToString() == RoomIndex).Select(s => new HotelRoomsDetail1()
                                {
                                    RoomIndex = s.RoomIndex.ToString(),
                                    BedTypes = s.BedTypes,
                                    Price = s.Price,
                                    RatePlanCode = s.RatePlanCode,
                                    SmokingPreference = 0,
                                    Supplements = s.HotelSupplements,
                                    RoomTypeCode = s.RoomTypeCode,
                                    RoomTypeName = s.RoomTypeName,
                                    BedTypeCode = null,
                                    HotelPassenger = null
                                }))
                            };
                            objBlockRoom.IsVoucherBooking = "0";
                            if (_HotelRoomResult.IsUnderCancellationAllowed)
                            {
                                objBlockRoom.IsVoucherBooking = "1";
                            }

                            objBlockRoom.GuestNationality = Session["GuestNationality"].ToString();
                            objBlockRoom.NoOfRooms = Session["NoOfRooms"].ToString();
                            var BlockRoomDetails = DataProviderWrapper.Instance.BlockRoom(objBlockRoom);

                            var _HotelRoomDetailsCL = BlockRoomDetails?.BlockRoomResult?.HotelRoomsDetails;

                            txtHotelPolicy.Text = BlockRoomDetails?.BlockRoomResult?.HotelNorms;
                            txtAvailability.Text = BlockRoomDetails?.BlockRoomResult?.AvailabilityType;
                            String StartTag = "<li><a>";
                            String EndTag = "</a></li>";

                            if (_HotelRoomDetailsCL.Count > 0)
                            {
                                
                                foreach(var item in _HotelRoomDetailsCL)
                                {
                                    txtDiscount.Text = item.Price?.Discount.ToString();
                                    txtExtraGuestCharge.Text = item.Price?.ExtraGuestCharge.ToString();
                                    txtRoomPrice.Text = item.Price?.RoomPrice.ToString();
                                    txtRoomTypeName.Text = item.RoomTypeName.ToString();
                                    txtServiceTax.Text = item.Price?.ServiceTax.ToString();
                                    txtSmokingPrefs.Text = item.SmokingPreference.ToString();
                                    txtTAX.Text = item.Price?.Tax.ToString();
                                    txtTDS.Text = item.Price?.TDS.ToString();
                                    txtLastCancellationDate.Text = item.LastCancellationDate.Replace('T', ' ');
                                    string amenities = null;
                                    foreach (var element in item.Amenities)
                                    {
                                        amenities += StartTag + element + EndTag;
                                    }
                                    ltrAmenties.Text = amenities?.ToString();

                                    string bedtypes = null;
                                    foreach(var btypes in item.BedTypes)
                                    {
                                        bedtypes += StartTag + btypes?.ToString() + EndTag;
                                    }
                                    ltrBedTypes.Text = bedtypes?.ToString();

                                    string CancellationPolicies = null;
                                    foreach(var policy in item.CancellationPolicies)
                                    {
                                        string Charge = null;
                                        if((int)policy.ChargeType == 2)
                                        {
                                            Charge = policy.Charge.ToString() + "%";
                                        }
                                        else //policy.ChargeType == 1
                                        {
                                            Charge = policy.Currency + " " + policy.Charge.ToString();
                                        }
                                        CancellationPolicies += StartTag +"Charge "+ Charge + " ,If Cancelled between " + policy.FromDate.Replace('T',' ') + " and " + policy.ToDate.Replace('T', ' ')+EndTag;
                                    }
                                    ltrCancellationPolicy.Text = CancellationPolicies?.ToString();
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

        public void RunBookingModule()
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        //protected void btnAddRow_Click(object sender, EventArgs e)
        //{
            
        //}
    }

    public class TravellerCL
    {
        public int SNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
        public Boolean IsHotelPassenger { get; set; }
        public Boolean IsLeadPassenger { get; set; }
        public string PasspostNo { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public TravellerCL() {}
    }
}