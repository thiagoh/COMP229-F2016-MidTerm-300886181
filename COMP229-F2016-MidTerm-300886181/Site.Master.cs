using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP229_F2016_MidTerm_300886181 {
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                PrivateMenu.Visible = false;
                PublicMenu.Visible = true;

                // check if a user is logged in

                if (HttpContext.Current.User.Identity.IsAuthenticated) {

                    // show the private menu
                    PrivateMenu.Visible = true;
                    PublicMenu.Visible = false;
                }
            }

            SetActivePage();
        }

        /**
        * This method adds a css class of "active" to list items
        * relating to the current page
        * 
        * @private
        * @method SetActivePage
        * @return {void}
        */
        private void SetActivePage() {
            switch (Page.Title) {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Todo List":
                    todo.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}