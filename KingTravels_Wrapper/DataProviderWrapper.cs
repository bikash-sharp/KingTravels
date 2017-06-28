using API_Hotel;
using KingTravels_Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace KingTravels_Wrapper
{
    public class DataProviderWrapper
    {
        private static readonly DataProviderWrapper instance = new DataProviderWrapper();
        //private static POSEntities context;

        static DataProviderWrapper() { }
        private DataProviderWrapper() { }

        public static string DataBaseName = "";
        public static int InstanceNo = 0;

        #region Api
        public static string apiClientId = "ApiIntegrationnew";
        public string IPAddress
        {
            get
            {
                return BLFunction.ClientIP();
            }
        }
        public string Baseurl
        {
            get
            {
                return ConfigurationManager.AppSettings["apiUrl"].ToString();
            }
        }
        #endregion



        public static Stopwatch sw = new Stopwatch();

        public static DataProviderWrapper Instance
        {
            get
            {
                #region HideMe
                if (InstanceNo == 0)
                {
                    // context = new POSEntities(DataBaseName);
                    sw.Start();
                }

                Debug.WriteLine(sw.ElapsedMilliseconds);
                InstanceNo++;
                Debug.WriteLine("Instance " + InstanceNo);
                Debug.WriteLine(sw.ElapsedMilliseconds);
                #endregion
                return instance;
            }
        }

        public AuthenticateResponse AuthenticateUser(string Username, string Password)
        {
            AuthenticateResponse authResponse = new AuthenticateResponse();
            try
            {
                AuthenticateCL auth = new AuthenticateCL();
                auth.ClientId = apiClientId;
                auth.EndUserIp = IPAddress;
                auth.UserName = Username;
                auth.Password = Password;
                var jsonStringObject = JsonConvert.SerializeObject(auth);
                String Qualifiedurl = Baseurl + "SharedServices/SharedData.svc/rest/Authenticate";
                var result = APIHotel.Instance().GetResponse(Qualifiedurl, Verbs.POST, jsonStringObject);
                if (result != null)
                {
                    authResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(result);
                }
                return authResponse;
            }
            catch (Exception ex)
            {
                authResponse.Error.ErrorMessage = ex.Message;
                return authResponse;
            }
        }

        public LogoutResponse Logout()
        {
            LogoutResponse logout = new LogoutResponse();
            try
            {
                LogoutRequest requestLogout = new LogoutRequest();
                requestLogout.ClientId = apiClientId;
                requestLogout.EndUserIp = IPAddress;
                requestLogout.TokenAgencyId = BLFunction.GetAgencyID();
                requestLogout.TokenMemberId = BLFunction.GetMemberID();
                requestLogout.TokenId = BLFunction.GetTokenID();
                var jsonStringObject = JsonConvert.SerializeObject(requestLogout);
                String Qualifiedurl = Baseurl + "SharedServices/SharedData.svc/rest/Logout";
                var result = APIHotel.Instance().GetResponse(Qualifiedurl, Verbs.POST, jsonStringObject);
                if (result != null)
                {
                    logout = JsonConvert.DeserializeObject<LogoutResponse>(result);
                }
                return logout;
            }
            catch (Exception ex)
            {
                logout.Error.ErrorMessage = ex.Message;
                return logout;
            }
        }

        public GetAgencyBalanceReponse GetAgencyBalance()
        {
            GetAgencyBalanceReponse agencyBal = new GetAgencyBalanceReponse();
            try
            {
                GetAgencyBalanceRequest agency = new GetAgencyBalanceRequest();
                agency.ClientId = apiClientId;
                agency.EndUserIp = IPAddress;
                agency.TokenId = BLFunction.GetTokenID();
                agency.TokenAgencyId = BLFunction.GetAgencyID();
                agency.TokenMemberId = BLFunction.GetMemberID();
                var jsonStringObject = JsonConvert.SerializeObject(agency);
                String Qualifiedurl = Baseurl + "SharedServices/SharedData.svc/rest/GetAgencyBalance";
                var result = APIHotel.Instance().GetResponse(Qualifiedurl, Verbs.POST, jsonStringObject);
                if (result != null)
                {
                    agencyBal = JsonConvert.DeserializeObject<GetAgencyBalanceReponse>(result);
                }
                return agencyBal;
            }
            catch (Exception ex)
            {
                agencyBal.Error.ErrorMessage = ex.Message;
                return agencyBal;
            }
        }

        public dynamic GetCountryList()
        {

            //List<DropDownCL> drpList = new List<DropDownCL>();
            List<Country> countryList = new List<Country>();
            try
            {
                CountryListRequest Country = new CountryListRequest();
                Country.ClientId = apiClientId;
                Country.EndUserIp = IPAddress;
                Country.TokenId = BLFunction.GetTokenID();
                var jsonObject = JsonConvert.SerializeObject(Country);
                String QualifiedUrl = Baseurl + "SharedServices/SharedData.svc/rest/CountryList";
                var result = APIHotel.Instance().GetResponse(QualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    CountryListResponse response = new CountryListResponse();
                    response = JsonConvert.DeserializeObject<CountryListResponse>(result);
                    countryList = (List<Country>)GetObjectFromXMlString(typeof(List<Country>), "Countries", response.CountryList);

                    //foreach (var item in CountryList)
                    //{
                    //    DropDownCL ddcl = new DropDownCL();
                    //    ddcl.DataText = item.Name;
                    //    ddcl.DataValue = item.Code;
                    //    drpList.Add(ddcl);
                    //}

                }
                return countryList;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public dynamic GetCityList(string CountryCode)
        {
            List<City> cityList = new List<City>();
            try
            {
                DestinationCityListRequest cityReq = new DestinationCityListRequest();
                cityReq.ClientId = apiClientId;
                cityReq.EndUserIp = IPAddress;
                cityReq.TokenId = BLFunction.GetTokenID();
                cityReq.CountryCode = CountryCode;
                var jsonObject = JsonConvert.SerializeObject(cityReq);
                String QualifiedUrl = Baseurl + "SharedServices/SharedData.svc/rest/DestinationCityList";
                var result = APIHotel.Instance().GetResponse(QualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    DestinationCityListResponse response = new DestinationCityListResponse();
                    response = JsonConvert.DeserializeObject<DestinationCityListResponse>(result);
                    cityList = (List<City>)GetObjectFromXMlString(typeof(List<City>), "Cities", response.DestinationCityList);
                }
                return cityList;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public dynamic GetTopCityList()
        {
            List<DropDownCL> drpList = new List<DropDownCL>();
            List<City> topCityList = new List<City>();
            try
            {
                DestinationCityListRequest cityReq = new DestinationCityListRequest();
                cityReq.ClientId = apiClientId;
                cityReq.EndUserIp = IPAddress;
                cityReq.TokenId = BLFunction.GetTokenID();
                var jsonObject = JsonConvert.SerializeObject(cityReq);
                String QualifiedUrl = Baseurl + "SharedServices/SharedData.svc/rest/TopDestinationList";
                var result = APIHotel.Instance().GetResponse(QualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    DestinationCityListResponse response = new DestinationCityListResponse();
                    response = JsonConvert.DeserializeObject<DestinationCityListResponse>(result);
                    topCityList = (List<City>)GetObjectFromXMlString(typeof(List<City>), "Cities", response.TopDestination);

                    foreach (var item in topCityList)
                    {
                        DropDownCL ddcl = new DropDownCL();
                        ddcl.DataText = item.cityName + " - " + item.countryName; //+ " (" + item.countryCode + ")"
                        ddcl.DataValue = item.cityId + "," + item.countryCode;

                        drpList.Add(ddcl);
                    }

                }
                return drpList;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public dynamic SearchHotel(HotelSearchRequest _Hotel)
        {
            HotelSearchList _Searchlist = new HotelSearchList();
            try
            {
                _Hotel.EndUserIp = IPAddress;
                _Hotel.TokenId = BLFunction.GetTokenID();
                var jsonObject = JsonConvert.SerializeObject(_Hotel);
                String QualifiedUrl = Baseurl + "BookingEngineService_Hotel/hotelservice.svc/rest/GetHotelResult";
                var result = APIHotel.Instance().GetResponse(QualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    _Searchlist = JsonConvert.DeserializeObject<HotelSearchList>(result);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return _Searchlist;
        }

        public HotelInfoResponse HotelInfo(HotelInfoRequest hotelInfo)
        {
            HotelInfoResponse _HotelResult = new HotelInfoResponse();
            try
            {
                HotelInfoRequest _hotelInfo = new HotelInfoRequest();
                _hotelInfo.EndUserIp = IPAddress;
                _hotelInfo.TokenId = BLFunction.GetTokenID();
                _hotelInfo.TraceId = BLFunction.GetTraceID();
                _hotelInfo.HotelCode = hotelInfo.HotelCode;
                _hotelInfo.ResultIndex = hotelInfo.ResultIndex;
                var jsonObject = JsonConvert.SerializeObject(_hotelInfo);
                var qualifiedUrl = Baseurl + "/BookingEngineService_Hotel/hotelservice.svc/rest/GetHotelInfo";
                var result = APIHotel.Instance().GetResponse(qualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    _HotelResult = JsonConvert.DeserializeObject<HotelInfoResponse>(result);
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                _HotelResult.HotelInfoResult.Error.ErrorCode = 4;
                _HotelResult.HotelInfoResult.Error.ErrorMessage = msg;
            }
            return _HotelResult;
        }

        public HotelRoomResult RoomDetails(GetHotelRoomRequest requestInfo)
        {
            HotelRoomResult _RoomDetailResult = new HotelRoomResult();
            try
            {
                GetHotelRoomRequest _requestInfo = new GetHotelRoomRequest();
                _requestInfo.EndUserIp = IPAddress;
                _requestInfo.TokenId = BLFunction.GetTokenID();
                _requestInfo.TraceId = BLFunction.GetTraceID();
                _requestInfo.HotelCode = requestInfo.HotelCode;
                _requestInfo.ResultIndex = requestInfo.ResultIndex;
                var jsonObject = JsonConvert.SerializeObject(_requestInfo);
                var qualifiedUrl = Baseurl + "/BookingEngineService_Hotel/hotelservice.svc/rest/GetHotelRoom";
                var result = APIHotel.Instance().GetResponse(qualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    _RoomDetailResult = JsonConvert.DeserializeObject<HotelRoomResult>(result);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                _RoomDetailResult.GetHotelRoomResult.Error.ErrorCode = 4;
                _RoomDetailResult.GetHotelRoomResult.Error.ErrorMessage = msg;
            }
            return _RoomDetailResult;
        }

        public BlockRoomResponse BlockRoom(BlockRoomRequest requestInfo)
        {
            BlockRoomResponse _RoomDetailResult = new BlockRoomResponse();
            try
            {
                requestInfo.EndUserIp = IPAddress;
                requestInfo.TokenId = BLFunction.GetTokenID();
                requestInfo.TraceId = BLFunction.GetTraceID();
                var jsonObject = JsonConvert.SerializeObject(requestInfo);
                var qualifiedUrl = Baseurl + "/BookingEngineService_Hotel/hotelservice.svc/rest/BlockRoom";
                var result = APIHotel.Instance().GetResponse(qualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    _RoomDetailResult = JsonConvert.DeserializeObject<BlockRoomResponse>(result);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                _RoomDetailResult.BlockRoomResult.Error.ErrorCode = 4;
                _RoomDetailResult.BlockRoomResult.Error.ErrorMessage = msg;
            }
            return _RoomDetailResult;
        }

        public BlockRoomResponse BookRoom(BlockRoomRequest requestInfo)
        {
            BlockRoomResponse _RoomDetailResult = new BlockRoomResponse();
            try
            {
                requestInfo.EndUserIp = IPAddress;
                requestInfo.TokenId = BLFunction.GetTokenID();
                requestInfo.TraceId = BLFunction.GetTraceID();
                var jsonObject = JsonConvert.SerializeObject(requestInfo);
                var qualifiedUrl = Baseurl + "/BookingEngineService_Hotel/hotelservice.svc/rest/Book";
                var result = APIHotel.Instance().GetResponse(qualifiedUrl, Verbs.POST, jsonObject);
                if (result != null)
                {
                    _RoomDetailResult = JsonConvert.DeserializeObject<BlockRoomResponse>(result);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                _RoomDetailResult.BlockRoomResult.Error.ErrorCode = 4;
                _RoomDetailResult.BlockRoomResult.Error.ErrorMessage = msg;
            }
            return _RoomDetailResult;
        }

        #region GenericCode
        public dynamic GetObjectFromXMlString(Type t, string xmlRootAttributeName, string xmlString)
        {
            var serializer = new XmlSerializer(t, new XmlRootAttribute(xmlRootAttributeName));
            var stringReader = new StringReader(xmlString);
            return serializer.Deserialize(stringReader);
        }
        #endregion
    }

}
