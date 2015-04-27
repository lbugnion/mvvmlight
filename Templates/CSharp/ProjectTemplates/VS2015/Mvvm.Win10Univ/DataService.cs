using System.Threading.Tasks;

namespace $safeprojectname$.Model
{
    public class DataService : IDataService
    {
        public Task<DataItem> GetData()
        {
            // Use this to connect to the actual data service

            // Simulate by returning a DataItem
            var item = new DataItem("Welcome to MVVM Light");
            return Task.FromResult(item);
        }
    }
}