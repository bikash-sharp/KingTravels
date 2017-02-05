using KingTravels_Common;
using KingTravels_Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingTravels
{
    public class KingTravelPage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                Response.RedirectToRoute("Login");
                return;
            }
            base.OnLoad(e);
        }
    }
}