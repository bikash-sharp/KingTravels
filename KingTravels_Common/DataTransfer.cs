using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingTravels_Common
{
    #region Enums
    public enum ResponseStatus  { NotSet = 0,  Successfull = 1, Failed = 2, InValidRequest = 3, InValidSession = 4, InValidCredentials = 5 }
    public enum StarRating  {   All = 0, OneStar = 1,  TwoStar = 2, ThreeStar = 3, FourStar = 4,  FiveStar = 5 }
    public enum SmokingPreference  { NoPreference = 0, Smoking = 1, NonSmoking = 2, Either = 3 }
    public enum ChargeType { Amount = 1, Percentage = 2, Nights = 3 }
    public enum PaxType { Adult = 1, Child = 2 }
    public enum HotelBookingStatus { BookFailed, Confirmed, VerifyPrice, Cancelled }
    public enum Status { BookFailed=0, Confirmed=1, VerifyPrice=3, Cancelled=6 }
    #endregion
    #region HotelAPI

    public class DropDownCL
    {
        public string DataText { get; set; }
        public string DataValue { get; set; }
    }
    public class AuthenticateCL
    {
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EndUserIp { get; set; }
        public AuthenticateCL() { }
    }

    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Error() { }
    }

    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int MemberId { get; set; }
        public int AgencyId { get; set; }
        public string LoginName { get; set; }
        public string LoginDetails { get; set; }
        public Boolean isPrimaryAgent { get; set; }
    }

    public class AuthenticateResponse
    {
        public int Status { get; set; }
        public string TokenId { get; set; }
        public Error Error { get; set; }
        public Member Member { get; set; }

        public AuthenticateResponse()
        {
            Error = new Error();
            Member = new Member();
        }
    }

    public class LogoutRequest
    {
        public string ClientId { get; set; }
        public string EndUserIp { get; set; }
        public int TokenAgencyId { get; set; }
        public int TokenMemberId { get; set; }
        public string TokenId { get; set; }
    }

    public class LogoutResponse
    {
        public Error Error { get; set; }
        public int Status { get; set; }

        public LogoutResponse()
        {
            Error = new Error();
        }
    }

    public class GetAgencyBalanceRequest
    {
        public string ClientId { get; set; }
        public string EndUserIp { get; set; }
        public int TokenAgencyId { get; set; }
        public int TokenMemberId { get; set; }
        public string TokenId { get; set; }
    }

    public class GetAgencyBalanceReponse
    {
        public int AgencyType { get; set; }
        public double CashBalance { get; set; }
        public object CashBalanceInPrefCurrency { get; set; }
        public double CreditBalance { get; set; }
        public object CreditBalanceInPrefCurrency { get; set; }
        public Error Error { get; set; }
        public object PreferredCurrency { get; set; }
        public int Status { get; set; }

        public GetAgencyBalanceReponse()
        {
            CashBalance = 0.00;
            CreditBalance = 0.00;
            Error = new Error();
        }
    }

    #region Country
    public class CountryListRequest
    {
        public string TokenId { get; set; }
        public string ClientId { get; set; }
        public string EndUserIp { get; set; }
    }

    public class CountryListResponse
    {
        public string CountryList { get; set; }
        public Error Error { get; set; }
        public int Status { get; set; }
        public string TokenId { get; set; }

        public CountryListResponse()
        {
            Error = new Error();
        }
    }

    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region City
    public class DestinationCityListRequest
    {
        public string TokenId { get; set; }
        public string ClientId { get; set; }
        public string EndUserIp { get; set; }
        public string CountryCode { get; set; }
    }

    public class DestinationCityListResponse
    {
        public string TopDestination { get; set; }
        public string DestinationCityList { get; set; }
        public Error Error { get; set; }
        public int Status { get; set; }
        public string TokenId { get; set; }

        public DestinationCityListResponse()
        {
            Error = new Error();
        }
    }

    public class City
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public string CountryCode { get; set; }

        public string cityId { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }

    }

    public class TopCity
    {
        public string cityId { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
    }


    #endregion

    #region HotelSearch
    public class RoomGuest
    {
        public int NoOfAdults { get; set; }
        public int NoOfChild { get; set; }
        public List<int> ChildAge { get; set; }
        public RoomGuest()
        {
            NoOfChild = 0;
            ChildAge = new List<int>();
        }
    }
    public class HotelSearchRequest
    {
        public string CheckInDate { get; set; }
        public string NoOfNights { get; set; }
        public string CountryCode { get; set; }
        public string CityId { get; set; }
        public object ResultCount { get; set; }
        public string PreferredCurrency { get; set; }
        public string GuestNationality { get; set; }
        public string NoOfRooms { get; set; }
        public List<RoomGuest> RoomGuests { get; set; }
        public string PreferredHotel { get; set; }
        public int MaxRating { get; set; }
        public int MinRating { get; set; }
        public object ReviewScore { get; set; }
        public bool IsNearBySearchAllowed { get; set; }
        public string EndUserIp { get; set; }
        public string TokenId { get; set; }
        public HotelSearchRequest()
        {
            RoomGuests = new List<RoomGuest>();
            ReviewScore = null;
            ResultCount = null;
        }
    }

    public class Price
    {
        public string CurrencyCode { get; set; }
        public double RoomPrice { get; set; }
        public double Tax { get; set; }
        public double ExtraGuestCharge { get; set; }
        public double ChildCharge { get; set; }
        public double OtherCharges { get; set; }
        public double Discount { get; set; }
        public double PublishedPrice { get; set; }
        public int PublishedPriceRoundedOff { get; set; }
        public double OfferedPrice { get; set; }
        public int OfferedPriceRoundedOff { get; set; }
        public double AgentCommission { get; set; }
        public double AgentMarkUp { get; set; }
        public double ServiceTax { get; set; }
        public double TDS { get; set; }
        public Price() { }
    }

    public class TripAdvisor
    {
        public double Rating { get; set; }
        public string ReviewURL { get; set; }
        public TripAdvisor() { }
    }

    public class HotelResult
    {
        public int ResultIndex { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string HotelCategory { get; set; }
        public int StarRating { get; set; }
        public string HotelDescription { get; set; }
        public string HotelPromotion { get; set; }
        public string HotelPolicy { get; set; }
        public Price Price { get; set; }
        public string HotelPicture { get; set; }
        public string HotelAddress { get; set; }
        public string HotelContactNo { get; set; }
        public object HotelMap { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public object HotelLocation { get; set; }
        public object SupplierPrice { get; set; }
        public List<object> RoomDetails { get; set; }
        public TripAdvisor TripAdvisor { get; set; }

        public HotelResult()
        {
            TripAdvisor = new TripAdvisor();
            RoomDetails = new List<object>();
            Price = new Price();
        }
    }

    public class HotelSearchResult
    {
        public ResponseStatus ResponseStatus { get; set; }
        public Error Error { get; set; }
        public string TraceId { get; set; }
        public string CityId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string PreferredCurrency { get; set; }
        public int NoOfRooms { get; set; }
        public List<RoomGuest> RoomGuests { get; set; }
        public List<HotelResult> HotelResults { get; set; }

        public HotelSearchResult()
        {
            RoomGuests = new List<RoomGuest>();
            HotelResults = new List<HotelResult>();
            Error = new Error();
        }
    }

    public class HotelSearchList
    {
        public HotelSearchResult HotelSearchResult { get; set; }
        public HotelSearchList()
        {
            HotelSearchResult = new HotelSearchResult();
        }
    }

    public class HotelInfoRequest
    {
        public string ResultIndex { get; set; }
        public string HotelCode { get; set; }
        public string EndUserIp { get; set; }
        public string TokenId { get; set; }
        public string TraceId { get; set; }
        public HotelInfoRequest() { }
    }

    public class Attraction
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Attraction() { }
    }

    public class HotelDetails
    {
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public StarRating StarRating { get; set; }
        public string HotelURL { get; set; }
        public string Description { get; set; }
        public List<Attraction> Attractions { get; set; }
        public List<string> HotelFacilities { get; set; }
        public string HotelPolicy { get; set; }
        public string SpecialInstructions { get; set; }
        public string HotelPicture { get; set; }
        public List<string> Images { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string PinCode { get; set; }
        public string HotelContactNo { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string RoomData { get; set; }
        public List<string> RoomFacilities { get; set; }
        public string Services { get; set; }

        public HotelDetails()
        {
            Attractions = new List<Attraction>();
            Images = new List<string>();
            HotelFacilities = new List<string>();
            RoomFacilities = new List<string>();
        }
    }

    public class HotelInfoResult
    {
        public ResponseStatus ResponseStatus { get; set; }
        public Error Error { get; set; }
        public string TraceId { get; set; }
        public HotelDetails HotelDetails { get; set; }

        public HotelInfoResult()
        {
            HotelDetails = new HotelDetails();
            Error = new Error();
        }
    }

    public class HotelInfoResponse
    {
        public HotelInfoResult HotelInfoResult { get; set; }
        public HotelInfoResponse()
        {
            HotelInfoResult = new HotelInfoResult();
        }
    }

    public class GetHotelRoomRequest
    {
        public GetHotelRoomRequest() { }
        public string ResultIndex { get; set; }
        public string HotelCode { get; set; }
        public string EndUserIp { get; set; }
        public string TokenId { get; set; }
        public string TraceId { get; set; }

    }
    public class DayRate
    {
        public double Amount { get; set; }
        public string Date { get; set; }
        public DayRate() { }
    }

    public class CancellationPolicy
    {
        public int Charge { get; set; }
        public ChargeType ChargeType { get; set; }
        public string Currency { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public CancellationPolicy() { }
    }

    public class BedType
    {
        public int BedTypeCode { get; set; }
        public int BedTypeDescription { get; set; }
        public BedType() { }
    }
    public class HotelRoomsDetail
    {
        public int ChildCount { get; set; }
        public bool RequireAllPaxDetails { get; set; }
        public int RoomIndex { get; set; }
        public string RoomTypeCode { get; set; }
        public string RoomTypeName { get; set; }
        public string RatePlanCode { get; set; }
        public int RatePlan { get; set; }
        public string RatePlanName { get; set; }
        public string InfoSource { get; set; }
        public string SequenceNo { get; set; }
        public List<DayRate> DayRates { get; set; }
        public object SupplierPrice { get; set; }
        public Price Price { get; set; }
        public string RoomPromotion { get; set; }
        public List<string> Amenities { get; set; }
        public SmokingPreference SmokingPreference { get; set; }
        public List<BedType> BedTypes { get; set; }
        public List<string> HotelSupplements { get; set; }
        public string LastCancellationDate { get; set; }
        public List<CancellationPolicy> CancellationPolicies { get; set; }
        public string CancellationPolicy { get; set; }
        public List<string> Inclusions { get; set; }

        public HotelRoomsDetail()
        {
            DayRates = new List<DayRate>();
            Amenities = new List<string>();
            BedTypes = new List<BedType>();
            HotelSupplements = new List<string>();
            CancellationPolicies = new List<CancellationPolicy>();
        }
    }

    public class RoomCombination
    {
        public List<int> RoomIndex { get; set; }
        public RoomCombination()
        {
            RoomIndex = new List<int>();
        }
    }

    public class RoomCombinations
    {
        public string InfoSource { get; set; }
        public bool IsPolicyPerStay { get; set; }
        public List<RoomCombination> RoomCombination { get; set; }
        public RoomCombinations()
        {
            RoomCombination = new List<RoomCombination>();
        }
    }

    public class GetHotelRoomResult
    {
        public ResponseStatus ResponseStatus { get; set; }
        public Error Error { get; set; }
        public string TraceId { get; set; }
        public bool IsUnderCancellationAllowed { get; set; }
        public bool IsPolicyPerStay { get; set; }
        public List<HotelRoomsDetail> HotelRoomsDetails { get; set; }
        public RoomCombinations RoomCombinations { get; set; }
        public GetHotelRoomResult()
        {
            HotelRoomsDetails = new List<HotelRoomsDetail>();
            RoomCombinations = new RoomCombinations();
        }
    }
    public class HotelRoomResult
    {
        public GetHotelRoomResult GetHotelRoomResult { get; set; }
        public HotelRoomResult() {
            GetHotelRoomResult = new GetHotelRoomResult();
        }
    }

    public class HotelPassenger
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public object Middlename { get; set; }
        public string LastName { get; set; }
        public string Phoneno { get; set; }
        public string Email { get; set; }
        public PaxType PaxType { get; set; }
        public bool LeadPassenger { get; set; }
        public int Age { get; set; }
        public string PassportNo { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportExpDate { get; set; }

        public HotelPassenger()
        {
            PassportExpDate = "0001-01-01T00:00:00:00";
            PassportIssueDate = "0001-01-01T00:00:00:00";
        }
    }
    public class HotelRoomsDetail1
    {
        public string RoomIndex { get; set; }
        public string RoomTypeCode { get; set; }
        public string RoomTypeName { get; set; }
        public string RatePlanCode { get; set; }
        public List<BedType> BedTypes { get; set; }
        public SmokingPreference SmokingPreference { get; set; }
        public List<string> Supplements { get; set; }
        public Price Price { get; set; }
        public List<HotelPassenger> HotelPassenger { get; set; }

        public HotelRoomsDetail1()
        {
            Price = new Price();
            BedTypes = new List<BedType>();
            Supplements = new List<string>();
            HotelPassenger = new List<HotelPassenger>();
        }
    }

    public class BlockRoomRequest
    {
        public string ResultIndex { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string GuestNationality { get; set; }
        public string NoOfRooms { get; set; }
        public string ClientReferenceNo { get; set; }
        public string IsVoucherBooking { get; set; }
        public List<HotelRoomsDetail1> HotelRoomsDetails { get; set; }
        public string EndUserIp { get; set; }
        public string TokenId { get; set; }
        public string TraceId { get; set; }
        public BlockRoomRequest()
        {
            HotelRoomsDetails = new List<HotelRoomsDetail1>();
            GuestNationality = "IN";
            ClientReferenceNo = "0";
        }
    }


    public class BlockRoomResult
    {
        public string AvailabilityType { get; set; }
        public string TraceId { get; set; }
        public int ResponseStatus { get; set; }
        public Error Error { get; set; }
        public bool IsPriceChanged { get; set; }
        public bool IsCancellationPolicyChanged { get; set; }
        public bool IsHotelPolicyChanged { get; set; }
        public string HotelNorms { get; set; }
        public List<HotelRoomsDetail> HotelRoomsDetails { get; set; }
        public BlockRoomResult()
        {
            HotelRoomsDetails = new List<HotelRoomsDetail>();
            Error = new Error();
        }
    }

    public class BlockRoomResponse
    {
        public BlockRoomResult BlockRoomResult { get; set; }

        public BlockRoomResponse()
        {
            BlockRoomResult = new BlockRoomResult();
        }
    }

    public class BookRequest
    {
        public string EndUserIp { get; set; }
        public string TokenId { get; set; }
        public string TraceId { get; set; }
        public int ResultIndex { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string GuestNationality { get; set; }
        public int NoOfRooms { get; set; }
        public string ClientReferenceNo { get; set; }
        public bool IsVoucherBooking { get; set; }
        public List<HotelRoomsDetail1> HotelRoomDetails { get; set; }

        public BookRequest()
        {
            HotelRoomDetails = new List<HotelRoomsDetail1>();
        }
    }

    public class BookResult
    {
        public bool VoucherStatus { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public Error Error { get; set; }
        public string TraceId { get; set; }
        public Status Status { get; set; }
        public HotelBookingStatus HotelBookingStatus { get; set; }
        public string ConfirmationNo { get; set; }
        public string BookingRefNo { get; set; }
        public int BookingId { get; set; }
        public bool IsPriceChanged { get; set; }
        public bool IsCancellationPolicyChanged { get; set; }

        public BookResult()
        {
            Error = new Error();
        }
    }

    public class BookResponse
    {
        public BookResult BookResult { get; set; }
        public BookResponse()
        {
            BookResult = new BookResult();
        }
    }

    #endregion


    #endregion


    #region AirlineAPI

    public class Segment
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string FlightCabinClass { get; set; }
        public string PreferredArrivalTime { get; set; }
        public string PreferredDepartureTime { get; set; }
        public Segment() { }
    }

    public class SearchRequest
    {
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int InfantCount { get; set; }
        public bool IsDomestic { get; set; }
        public bool DirectFlight { get; set; }
        public bool OneStopFlight { get; set; }
        public string JourneyType { get; set; }
        public string EndUserIp { get; set; }
        public string TokenId { get; set; }
        public object PreferredAirlines { get; set; }
        public List<Segment> Segments { get; set; }
        public object Sources { get; set; }

        public SearchRequest()
        {
            Segments = new List<Segment>();
        }
    }

    #endregion

}
