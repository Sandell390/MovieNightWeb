using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNightWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void OnClick(object sender, EventArgs e) 
        {
            if (searchText.Text.Length > 0) 
            {
                Response.Redirect($"Default.aspx?search={searchText.Text}");
            }
            else
            {
                Response.Redirect($"Default.aspx");
            }
        }


    }
}