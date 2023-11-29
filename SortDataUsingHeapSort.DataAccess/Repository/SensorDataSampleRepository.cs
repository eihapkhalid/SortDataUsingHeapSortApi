using SortDataUsingHeapSort.DataAccess.Data;
using SortDataUsingHeapSort.DataAccess.Repository.IRepository;
using SortDataUsingHeapSort.Models;

namespace SortDataUsingHeapSort.DataAccess.Repository
{
    public class SensorDataSampleRepository : Repository<TbSensorDataSample>, ISensorDataSampleRepository
    {
        #region dependency injection
        private HeapSortDbContext _db;
        public SensorDataSampleRepository(HeapSortDbContext db) : base(db)
        {
            _db = db;
        }
        #endregion

        #region Update
        public void Update(TbSensorDataSample obj)
        {
            _db.TbSensorDataSamples.Update(obj);
        }
        #endregion
    }
}
