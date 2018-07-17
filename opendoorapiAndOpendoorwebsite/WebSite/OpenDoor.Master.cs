using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class OpenDoor : MasterPage
    {

        public string FullNamelabel
        {
            set
            {
                lblUserName.InnerText = "OpenDoor (%UserName%)";
                if (value != null)
                    lblUserName.InnerText = lblUserName.InnerText.Replace("%UserName%", value) ;
            }
            get
            {
                return lblUserName.InnerText.Replace("OpenDoor (", "").Replace(")", "");
            }
        }

		
		protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}