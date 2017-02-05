using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using KingTravels_Common;
using KingTravels_Wrapper;

namespace KingTravels
{
    public partial class Root : KingTravelMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAgencyBalanceReponse agency = DataProviderWrapper.Instance.GetAgencyBalance();
                if (agency != null)
                    ltrAmount.Text = String.Format("{0:0,0.00}", agency.CashBalance);
            }
            
        }

        protected void lnkbLogOut_Click(object sender, EventArgs e)
        {
            LogoutResponse lgresp = DataProviderWrapper.Instance.Logout();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.RedirectToRoute("Login");
        }
    }
}