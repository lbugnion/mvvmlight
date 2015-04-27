using System.Threading.Tasks;

namespace $safeprojectname$.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}