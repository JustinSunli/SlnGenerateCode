using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomSpring.Core
{
    public class SpringManager
    {
        private static IApplicationContext _springContext = null;
        public static void Init()
        {
            if (_springContext == null)
                _springContext = ContextRegistry.GetContext();
        }

        public static object GetObject(string id)
        {
            return _springContext.GetObject(id);
        }
    }
}
