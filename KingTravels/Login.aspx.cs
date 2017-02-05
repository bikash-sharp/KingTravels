using KingTravels_Common;
using KingTravels_Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KingTravels
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    Response.RedirectToRoute("Dashboard");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AuthenticateResponse authResponse = DataProviderWrapper.Instance.AuthenticateUser(txtEmail.Text.Trim(), txtPassword.Text.Trim());
                if (authResponse != null)
                {
                    if (String.IsNullOrEmpty(authResponse.TokenId))
                    {
                        BLFunction.ShowAlert(this, authResponse.Error.ErrorMessage, ResponseType.DANGER);
                    }
                    else
                    {
                        string userData = authResponse.TokenId + "$" + authResponse.Member.AgencyId + "$" + authResponse.Member.MemberId + "$" + authResponse.Member.FirstName + " " + authResponse.Member.LastName;
                        string userName = authResponse.Member.FirstName + " " + authResponse.Member.LastName;
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(authResponse.Status,
                            userData,
                            DateTime.Now,
                            DateTime.Now.AddMinutes(2880),
                            chkRememberMe.Checked,
                            userData,
                            FormsAuthentication.FormsCookiePath
                            );
                        string hash = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                        if (authTicket.IsPersistent)
                        {
                            cookie.Expires = authTicket.Expiration;
                        }
                        Response.Cookies.Add(cookie);
                        Response.RedirectToRoute("Dashboard");
                    }
                }
                else
                {
                    BLFunction.ShowAlert(this, "Services currenlty unavailable", ResponseType.PRIMARY);
                }

            }
            else
            {
                BLFunction.ShowAlert(this, "Invalid page Access Mechanism", ResponseType.INFO);
            }

        }
    }
}