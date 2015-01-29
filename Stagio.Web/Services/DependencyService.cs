using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.Services
{
    public class DependencyService
    {
        public static void VerifyDependencies(params object[] dependencies)
        {
            foreach (object o in dependencies)
            {
                if (o == null)
                {
                    throw new NullReferenceException();
                }
            }
        }
    }
}