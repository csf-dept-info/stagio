using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.Services
{
    public interface IEmployeeService
    {
        int FetchTotalNumberOfApplications(int employeeID);
        int FetchTotalNumberOfRefusedOffers(int employeeID);
        int FetchTotalNumberOfOnValidationOffers(int employeeID);
        int FetchTotalNumberOfPublishedOffers(int employeeID);
    }
}