using Microsoft.AspNetCore.Http;

namespace DummyAPI.Monitoring
{
    public interface IMonitoringService
    {
        bool Monitor(string httpMethod, PathString path);
    }
}