﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace COMP229_F2016_MidTerm_300886181 {
    public partial class Login : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                errorBox.Visible = false;
                errorBox.InnerText = "";
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e) {

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // search for and create a new user object
            var user = userManager.Find(UserName.Text, Password.Text);

            // if a match is found for the user
            if (user != null) {
                // authenticate and login our user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // sign in the user
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                // redirect the user to the main menu
                Response.Redirect("~/TodoList.aspx");

            } else {

                // user is not found
                errorBox.Visible = true;
                errorBox.InnerText = "Invalid Username or Password";
            }
        }
    }
}