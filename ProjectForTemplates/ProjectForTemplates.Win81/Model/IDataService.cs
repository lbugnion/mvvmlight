using System.Threading.Tasks;

namespace ProjectForTemplates.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}