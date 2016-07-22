using System.Collections.Generic;

namespace Illallangi.OpenFlights.Planes
{
    public static class PlaneClientExtensions
    {
        public static IEnumerable<Plane> RetrievePlane(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Plane>(@"Plane");
        }
    }
}