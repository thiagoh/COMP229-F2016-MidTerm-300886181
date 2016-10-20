using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

// required for OWIN Startup
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

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
