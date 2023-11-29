using SortDataUsingHeapSort.Models;

namespace SortDataUsingHeapSort.DataAccess.Repository.IRepository
{
    public interface ISensorDataSampleRepository : IRepository<TbSensorDataSample>
    {
        void Update(TbSensorDataSample obj);
    }
}
