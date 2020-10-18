using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository.Monitoring
{
    public interface IMonitoringRepository
    {
        void AddNewVital(VitalsModel vital);
        string Alarm(string vitalName);
        VitalsModel FetchVital(string vitalName);
    }
}