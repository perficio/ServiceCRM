using System.Web.Mvc;
using ServiceCRM.Controllers;
using ServiceCRM.Models;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void TestCustomerList()
        {
             
            CustomerController _customer = new CustomerController();
            ActionResult Results = _customer.List() as ActionResult;
        }
    }
}
