using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Diagnostics;

/*
    Register.aspx.cs
    Mid Term test
    Thiago de Andrade Souza 300886181
    Created on 2016-10-19
    Summary: This is page which registers the user
*/

namespace COMP229_F2016_MidTerm_300886181 {
    public partial class Register : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                errorBox.Visible = false;
                errorBox.InnerText = "";
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e) {
                
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            userManager.UserValidator = new UserValidator<IdentityUser>(userManager) {
                AllowOnlyAlphanumericUserNames = false
            };

            // create a new user object
            var user = new IdentityUser() {
                UserName = Username.Text,
                Email = Email.Text,
            };

            // create a new user in the db and store the results
            IdentityResult result = userManager.Create(user, Password.Text);

            // check if successfully registered?
            if (result.Succeeded) {
                // authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // sign in the user
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                // Redirect to the todo lists page
                Response.Redirect("~/TodoList.aspx");
            } else {
                // display error in the AlertFlash div
                errorBox.Visible = true;
                errorBox.InnerText = result.Errors.FirstOrDefault();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e) {

            Response.Redirect("~/TodoList.aspx");
        }
    }
}