using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static WESL.ConsoleRedirector; //redirects console to unity

namespace WESL
{
    public class WESLCore
    {
        public WESLCore ()
        {
            Redirect(); //redirects console to unity writing console
        }
    }
}
