using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace KingTravels
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }
        public void RegisterRoutes()
        {
            RouteCollection routes = RouteTable.Routes;
            routes.MapPageRoute("Login", "Login", "~/Login.aspx", true);
            routes.MapPageRoute("Home", "Home", "~/Admin/Home.aspx", true);
            routes.MapPageRoute("Dashboard", "Dashboard", "~/Admin/Dashboard.aspx", true);
            routes.MapPageRoute("HotelInfo", "HotelInfo/{HotelCode}/{ResultIndex}", "~/Admin/HotelInfo.aspx", true,new RouteValueDictionary { { "HotelCode", "0" }, { "ResultIndex", "0" } });

            routes.MapPageRoute("BlockRoom", "BlockRoom/{HotelCode}/{ResultIndex}/{RoomIndex}", "~/Admin/BookingInfo.aspx", true, new RouteValueDictionary { { "HotelCode", "0" }, { "ResultIndex", "0" }, { "RoomIndex", "0" } });
            routes.MapPageRoute("Booking", "Booking", "~/Admin/BookingInfo.aspx", true);
            routes.MapPageRoute("Cancellation", "Cancellation", "~/Admin/HotelCancellation.aspx", true);
            
            routes.MapPageRoute("AirlineInfo", "Airline/{AirlineCode}/{ResultIndex}", "~/Admin/AirlineInfo.aspx", true, new RouteValueDictionary { { "AirlineCode", "0" }, { "ResultIndex", "0" } });
            routes.MapPageRoute("Airline", "Airline", "~/Admin/Airline.aspx", true);
            routes.MapPageRoute("CustomError", "CustomError", "~/CustomError.aspx", true);


        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        string[] roles = new string[] { "Admin" };
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Get the exception object.
            Exception ex = Server.GetLastError();
            
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}