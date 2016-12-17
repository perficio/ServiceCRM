﻿using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ServiceCRM.Tests.Controllers
{
    class Helpers
    {
        internal static Mock<ControllerContext> GetMvcControllerContextMock(HttpContextBase httpContextBase = null)
        {
            // Set default HttpContextBase
            if (httpContextBase == null)
                httpContextBase = GetHttpContextMock().Object;

            var _controllerContextMock = new Mock<ControllerContext>();

            // Add default HttpContextBase
            _controllerContextMock.Setup(x => x.HttpContext).Returns(httpContextBase);

            return _controllerContextMock;
        }

        internal static Mock<HttpContextBase> GetHttpContextMock(ClaimsPrincipal claimsPrincipal = null, ClaimsIdentity claimsIdentity = null, HttpResponseBase httpResponseBase = null, HttpRequestBase httpRequestBase = null)
        {
            var _httpContextMock = new Mock<HttpContextBase>();

            // Set default ClaimsIdentity
            if (claimsIdentity == null)
                claimsIdentity = GetClaimsIdentityMock().Object;

            // Set default ClaimsPrincipal
            if (claimsPrincipal == null)
                claimsPrincipal = GetClaimsPrincipalMock(claimsIdentity).Object;

            // Set default HttpContextBase
            if (httpResponseBase == null)
                httpResponseBase = GetHttpResponseBaseMock().Object;
            if (httpRequestBase == null)
                httpRequestBase = GetHttpRequestBaseMock().Object;

            // Add Session object to HttpContext
            var _session = new MockHttpSession();

            // Add ClaimsPrincipal to HttpContext.User
            _httpContextMock.Setup(x => x.User).Returns(claimsPrincipal);

            // Add UserClaims to HttpContext.Session
            _httpContextMock.Setup(x => x.Session).Returns(_session);

            // Add HttpContextBase object to HttpContext
            _httpContextMock.Setup(x => x.Response).Returns(httpResponseBase);

            _httpContextMock.Setup(x => x.Request).Returns(httpRequestBase);
            return _httpContextMock;
        }

        internal static Mock<HttpResponseBase> GetHttpResponseBaseMock(int? statusCode = 0)
        {
            var _httpResponseMock = new Mock<HttpResponseBase>();

            // Set default StatusCode
            if (statusCode == null)
                statusCode = (int)HttpStatusCode.OK;

            // Add StatusCode to HttpResponse.StatusCode
            _httpResponseMock.Setup(x => x.StatusCode).Returns(statusCode.Value);

            return _httpResponseMock;
        }

        internal static Mock<HttpRequestBase> GetHttpRequestBaseMock()
        {
            var _httpRequestMock = new Mock<HttpRequestBase>();

            // Add StatusCode to HttpResponse.StatusCode
            _httpRequestMock.Setup(x => x.QueryString).Returns(new NameValueCollection());
            _httpRequestMock.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(string.Empty);
            _httpRequestMock.Setup(x => x.PathInfo).Returns(string.Empty);
            _httpRequestMock.Setup(x => x.Url).Returns(new Uri("http://site/"));
            return _httpRequestMock;
        }

        internal static Mock<ClaimsPrincipal> GetClaimsPrincipalMock(ClaimsIdentity identity = null)
        {
            // Set default ClaimsIdentity
            if (identity == null)
                identity = GetClaimsIdentityMock().Object;

            var _principalMock = new Mock<ClaimsPrincipal>();
            _principalMock.Setup(x => x.Identity).Returns(identity);

            return _principalMock;
        }

        internal static Mock<ClaimsIdentity> GetClaimsIdentityMock(List<Claim> claimCollection = null, bool isAuthenticated = true)
        {
            // Set default ClaimCollection
            if (claimCollection == null)
            {
                claimCollection = new List<Claim>();
                //claimCollection.AddRange(Models.ValidClaims);
            }

            var _identityMock = new Mock<ClaimsIdentity>();
            _identityMock.Setup(x => x.IsAuthenticated).Returns(isAuthenticated);
            _identityMock.Setup(x => x.Claims).Returns(claimCollection);

            return _identityMock;
        }
    }
}
