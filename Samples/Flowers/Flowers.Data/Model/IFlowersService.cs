using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowers.Data.Model
{
    public interface IFlowersService
    {
        Task<IList<Flower>> Refresh();

        Task<bool> Save(Flower flower);
    }
}