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
    public partial class Dashboard : KingTravelPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAgencyBalanceReponse agency = DataProviderWrapper.Instance.GetAgencyBalance();
                if (agency != null)
                {
                    ltrCashAmount.Text = String.Format("{0:0,0.00}", agency.CashBalance);
                    ltrCreditAmount.Text = String.Format("{0:0,0.00}", agency.CreditBalance);
                }
                    
            }
        }
    }
}