using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP229_F2016_MidTerm_300886181 {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void RegisterButton_Click(object sender, EventArgs e) {

            Response.Redirect("~/Default.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e) {

        }
    }
}