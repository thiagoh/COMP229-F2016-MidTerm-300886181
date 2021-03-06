﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

// required for OWIN Startup
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

/*
    Startup.cs
    Mid Term test
    Thiago de Andrade Souza 300886181
    Created on 2016-10-19
    Summary: This is used by Owin to control the authentication flow
 */

[assembly: OwinStartup(typeof(COMP229_F2016_MidTerm_300886181.Startup))]

namespace COMP229_F2016_MidTerm_300886181 {
    public class Startup {

        public void Configuration(IAppBuilder app) {

            var authOpts = new CookieAuthenticationOptions();
            authOpts.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            authOpts.LoginPath = new PathString("/Login.aspx");

            app.UseCookieAuthentication(authOpts);
        }
    }
}
