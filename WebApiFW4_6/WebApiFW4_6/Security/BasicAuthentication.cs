﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace WebApiFW4_6.Security
{
    public class BasicAuthentication : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
           // base.OnAuthorization(actionContext);
           if(actionContext.Request.Headers.Authorization==null)
           {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
           }
           else
           {
                string authenticationtoken = actionContext.Request.Headers.Authorization.Parameter;
                //base64encode username:password
                string decodedAuthToken= Encoding.UTF8.GetString(Convert.FromBase64String(authenticationtoken));
                string[] username_password = decodedAuthToken.Split(':');
                string username = username_password[0];
                string password = username_password[1];
                if(Security.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
           }
        }
    }
}