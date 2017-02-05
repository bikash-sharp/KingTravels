using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KingTravels_Wrapper;
using KingTravels_Common;

namespace KingTravels.Admin
{
    public partial class Home : KingTravelPage
    {
        public string CityId
        {
            get
            {
                String Id = (String)ViewState["CityId"];
                return ((String.IsNullOrEmpty(Id) || Id == "0") ? "0" : Id);
            }
            set
            {
                ViewState["CityId"] = value;
            }
        }

        public string CountryCode
        {
            get
            {
                String Code = (String)ViewState["CountryCode"];
                return ((String.IsNullOrEmpty(Code) || Code == "0") ? "0" : Code);
            }
            set
            {
                ViewState["CountryCode"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindTopCity();
            }

        }

        public void BindData()
        {
            var CountryList = DataProviderWrapper.Instance.GetCountryList();
            drpCountry.Items.Clear(); drpGuestNationality.Items.Clear();
            drpCountry.DataSource = null; drpGuestNationality.DataSource = null;
            if (CountryList != null)
            {
                drpCountry.DataSource = CountryList;
                drpCountry.DataTextField = "Name";
                drpCountry.DataValueField = "Code";

                drpGuestNationality.DataSource = CountryList;
                drpGuestNationality.DataTextField = "Name";
                drpGuestNationality.DataValueField = "Code";
            }
            drpCountry.DataBind();
            drpCountry.Items.Insert(0, new ListItem("Select Country", "0"));

            drpGuestNationality.DataBind();
            drpGuestNationality.Items.Insert(0, new ListItem("Select Country", "0"));


            drpCity.Items.Insert(0, new ListItem("Select City", "0"));
            drpTopCity.Items.Insert(0, new ListItem("Select City", "0"));
        }

        public void BindCity(string SelectedCountry)
        {
            drpCity.Items.Clear();
            drpCity.DataSource = null;
            if (SelectedCountry != "0")
            {
                var citylist = DataProviderWrapper.Instance.GetCityList(SelectedCountry);
                if (citylist != null)
                {
                    drpCity.DataSource = citylist;
                    drpCity.DataTextField = "CityName";
                    drpCity.DataValueField = "CityId";
                }
            }
            drpCity.DataBind();
            drpCity.Items.Insert(0, new ListItem("Select City", "0"));
        }

        public void BindTopCity()
        {
            drpTopCity.Items.Clear();
            drpTopCity.DataSource = null;
            var citylist = DataProviderWrapper.Instance.GetTopCityList();
            if (citylist != null)
            {
                drpTopCity.DataSource = citylist;
                drpTopCity.DataTextField = "DataText";
                drpTopCity.DataValueField = "DataValue";
            }

            drpTopCity.DataBind();
            drpTopCity.Items.Insert(0, new ListItem("Select City", "0"));
        }

        protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTopCity.SelectedIndex = 0;
            BindCity(drpCountry.SelectedValue);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (drpCountry.SelectedValue != "0" && drpCity.SelectedValue != "0")
                    {
                        CountryCode = drpCountry.SelectedValue;
                        CityId = drpCity.SelectedValue;
                    }
                    else if (drpTopCity.SelectedValue != "0")
                    {
                        CityId = drpTopCity.SelectedValue.Split(',')[0];
                        CountryCode = drpTopCity.SelectedValue.Split(',')[1];
                    }
                    else
                    {
                        BLFunction.ShowAlert(this, "Please select Destination place", ResponseType.WARNING);
                        return;
                    }

                    if (String.IsNullOrEmpty(txtCheckIn.Text.Trim()))
                    {
                        BLFunction.ShowAlert(this, "Please select date", ResponseType.WARNING);
                        txtCheckIn.Focus();
                        return;
                    }
                    else if (drpGuestNationality.SelectedIndex == 0)
                    {
                        BLFunction.ShowAlert(this, "Please select guest Nationality", ResponseType.WARNING);
                        return;
                    }



                    String NoOfNights = drpNight.SelectedValue;
                    String CheckInDate = txtCheckIn.Text.Trim();
                    String PreferredCurrency = "";
                    String GuestNationality = drpGuestNationality.SelectedValue;
                    Session["GuestNationality"] = GuestNationality;
                    String NoOfRooms = drpRooms.SelectedValue;
                    int NoOfAdults = Convert.ToInt32(drpAdults.SelectedValue);
                    int NoOfChild = Convert.ToInt32(drpChilds.SelectedValue);

                    String PreferredHotel = "";
                    string ratings = txtRatings.Text;
                    int MaxRating = Convert.ToInt32(ratings.Split(',')[1]);
                    int MinRating = Convert.ToInt32(ratings.Split(',')[0]);
                    bool IsNearBySearchAllowed = chkNearBy.Checked;

                    HotelSearchRequest _Hotel = new HotelSearchRequest();
                    _Hotel.CheckInDate = CheckInDate;
                    _Hotel.CityId = CityId;
                    _Hotel.CountryCode = CountryCode;
                    _Hotel.GuestNationality = GuestNationality;
                    _Hotel.IsNearBySearchAllowed = IsNearBySearchAllowed;
                    _Hotel.MaxRating = MaxRating;
                    _Hotel.MinRating = MinRating;
                    _Hotel.NoOfNights = NoOfNights;
                    _Hotel.NoOfRooms = NoOfRooms;
                    Session["NoOfRooms"] = NoOfRooms;
                    _Hotel.PreferredCurrency = PreferredCurrency;
                    _Hotel.PreferredHotel = PreferredHotel;
                    RoomGuest _guest = new RoomGuest();
                    _guest.NoOfAdults = NoOfAdults;
                    _guest.NoOfChild = NoOfChild;
                    if(NoOfChild > 0)
                    {
                        while(NoOfChild > 0)
                        {
                            _guest.ChildAge.Add(15);
                            NoOfChild--;
                        }
                    }
                    _Hotel.RoomGuests.Add(_guest);
                    Session["RoomGuests"] = _Hotel.RoomGuests;
                    HotelSearchList _SearchResult = DataProviderWrapper.Instance.SearchHotel(_Hotel);
                    rptHotels.DataSource = null;
                    
                    if(_SearchResult.HotelSearchResult.Error.ErrorCode > 0)
                    {
                        BLFunction.ShowAlert(this, _SearchResult.HotelSearchResult.Error.ErrorMessage, ResponseType.WARNING);
                        return;
                    }

                    if (_SearchResult?.HotelSearchResult?.HotelResults != null)
                    {
                        Session["TraceId"] = _SearchResult.HotelSearchResult.TraceId;
                        rptHotels.DataSource = _SearchResult.HotelSearchResult.HotelResults;
                    }
                    rptHotels.DataBind();
                    pnlHotelList.Visible = true;
                    rptHotels.Focus();
                }
                else
                {
                    BLFunction.ShowAlert(this, "Invalid page request.Please Reload the page again", ResponseType.WARNING);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                BLFunction.ShowAlert(this, message, ResponseType.WARNING);
                return;
            }


        }

        protected void drpTopCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpCountry.SelectedIndex = 0;
            drpCity.SelectedIndex = 0;
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            
        }
    }
}