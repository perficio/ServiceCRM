using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ServiceCRM.Tests.Controllers
{
    class MockHttpSession : HttpSessionStateBase
    {
        readonly Dictionary<string, object> _SessionDictionary = new Dictionary<string, object>();
        public override object this[string name]
        {
            get
            {
                object obj = null;
                _SessionDictionary.TryGetValue(name, out obj);
                return obj;
            }
            set { _SessionDictionary[name] = value; }
        }
    }
}
