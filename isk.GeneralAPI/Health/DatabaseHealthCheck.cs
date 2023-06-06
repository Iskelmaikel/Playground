using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace isk.GeneralAPI.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public DatabaseHealthCheck() { 
            
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
