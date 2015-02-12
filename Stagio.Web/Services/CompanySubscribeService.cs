using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.Domain.SecurityUtilities;

namespace Stagio.Web.Services
{
    public class CompanySubscribeService : ICompanySubscribeService
    {
        public string CreateSubscribeInvitation()
        {
            String key = Cryptography.GenerateUnique();              
            return key;
        }
    }
}