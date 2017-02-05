using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace KingTravels_Common
{
    public sealed class BLFunction
    {
        private static readonly BLFunction instance = new BLFunction();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static BLFunction() { }

        private BLFunction() { }

        //Get the Current Page Relative Path
        public static string BaseUrl()
        {
            string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath;
            return path.EndsWith("/") ? path : path + "/";
        }

        public static void ShowAlert(Control pageControl, string message, ResponseType type = ResponseType.PRIMARY)
        {
            ScriptManager.RegisterClientScriptBlock(pageControl, typeof(Page), Guid.NewGuid().ToString(), "ShowAlert('" + type.ToString() + "','" + message.Replace("'", "").Replace("\r\n", "<Br/>") + "')",true);
            return;
        }

        public static void ShowAlertRedirect(Control pageControl, string message, string pageurl, ResponseType type = ResponseType.PRIMARY)
        {
            ScriptManager.RegisterClientScriptBlock(pageControl, typeof(Page), Guid.NewGuid().ToString(), "ShowMessageWithPageRedirect('" + type.ToString() + "','" + message.Replace("'", "").Replace("\r\n", "<Br/>") + "','" + pageurl + "')", true);
            return;
        }

        public static string ClientIP()
        {
            string clientIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (clientIp == "::1")
                {
                    clientIp = "192.178.1.156";
                }
            }

            return clientIp;
        }

        public static string GetTokenID()
        {
            HttpContext context = HttpContext.Current;

            if (context.User.Identity.IsAuthenticated)
            {
                string[] temp = context.User.Identity.Name.Split('$');

                return temp[0].ToString();
            }
            else
            {
                return "";
            }
        }
        public static string GetTraceID()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["TraceId"] != null)
                return context.Session["TraceId"].ToString();
            else
                return "";
        }

        public static string GetFullName()
        {
            HttpContext context = HttpContext.Current;

            if (context.User.Identity.IsAuthenticated)
            {
                string[] temp = context.User.Identity.Name.Split('$');

                return temp[3].ToString();
            }
            else
            {
                return "";
            }
        }

        public static int GetAgencyID()
        {
            HttpContext context = HttpContext.Current;

            if (context.User.Identity.IsAuthenticated)
            {
                string[] temp = context.User.Identity.Name.Split('$');

                int agencyid = 0;

                int.TryParse(temp[1].ToString(), out agencyid);

                return agencyid;
            }
            else
            {
                return 0;
            }
        }

        public static int GetMemberID()
        {
            HttpContext context = HttpContext.Current;

            if (context.User.Identity.IsAuthenticated)
            {
                string[] temp = context.User.Identity.Name.Split('$');

                int agencyid = 0;

                int.TryParse(temp[2].ToString(), out agencyid);

                return agencyid;
            }
            else
            {
                return 0;
            }
        }

    }
}
