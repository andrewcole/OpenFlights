using System.Management.Automation;

namespace Illallangi.OpenFlights
{
    public abstract class OpenFlightsCmdlet : PSCmdlet
    {
        private OpenFlightsClient currentClient;

        protected OpenFlightsClient Client => this.currentClient ??
                                     (this.currentClient = new OpenFlightsClient());
    }
}
