using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace Stagio.TestUtilities.AutoFixture
{
    // Do not fill navigational properties (virtual method)
    public class VirtualMembersOmitter : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;
            if (propertyInfo != null
                && propertyInfo.GetGetMethod().IsVirtual)
            {
                return new OmitSpecimen();
            }
            
            return new NoSpecimen(request);
        }
    }
}
