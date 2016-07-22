using Illallangi.RestifyDb;

namespace Illallangi.OpenFlights
{
    public sealed class OpenFlightsClient : RestifyDbClient
    {
        public OpenFlightsClient() : base(OpenFlightsClient.GetProfile())
        {
        }

        private static IProfile GetProfile()
        {
            return Profiles.Profile.GetActiveProfile();
        }
    }
}