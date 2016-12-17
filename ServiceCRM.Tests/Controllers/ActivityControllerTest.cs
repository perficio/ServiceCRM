using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCRM.Models;
using ServiceCRM.Controllers;
using System;
using t = ServiceCRM.Testing.Models;
using System.Web.Mvc;
using System.Security.Principal;
using System.Security.Claims;
using System.Web.Routing;
using Moq;
using System.Web;


namespace ServiceCRM.Tests.Controllers
{
    [TestClass]
  public class ActivityControllerTest
    {
        [TestMethod]
        public void TestActivityListValidation()
        {

            Activity activity = new Activity {  ActivityType = "Call", DueDate = Convert.ToDateTime("12/15/2015"),  Notes="Unit Testing", Status = "Scheduled" };
            bool passed = false;

            // Act
            var errors = t.GetValidationErrors(activity, out passed);

            if (passed)
            {
                Assert.IsTrue(passed, "Validation Passed");
            }
            else
            {
                var Message = string.Empty;
                foreach (var e in errors)
                {

                    Message += e.ErrorMessage + " ";

                }
                Assert.Fail(Message);
            }
        }
        [TestMethod]
        public void TestCustomerControllerContext()
        {
            var fakeHttpContext = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("eric.erhardt@gmail.com");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "82b5c2e7-f797-46ff-b60d-2b237c9cfe1f"));
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);
            fakeHttpContext.Setup(s => s.User).Returns(principal);

            ActivityController controller = new ActivityController();
            controller.ControllerContext = new ControllerContext(fakeHttpContext.Object, new RouteData(), controller);


            // Act
            var _result = controller.List() as ViewResult;

            // Assert
            Assert.IsNotNull(_result);
        }
    }
}
