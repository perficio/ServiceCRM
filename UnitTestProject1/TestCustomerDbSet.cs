 
using System.Linq;
using ServiceCRM.Models;
namespace UnitTestProject1
{
    class TestCustomerDbSet : TestDbSet<Customer>
    {
        public override Customer Find(params object[] keyValues)
        {
            return this.SingleOrDefault(c => c.Id == (int)keyValues.Single());
        }
    }

}
