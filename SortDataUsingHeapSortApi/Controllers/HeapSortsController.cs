using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SortDataUsingHeapSort.DataAccess.UnitOfWork;
using SortDataUsingHeapSortApi.Utilities;

namespace SortDataUsingHeapSortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeapSortsController : ControllerBase
    {
        #region Inject
        private readonly IUnitOfWork _unitOfWork;
        private SortDataService _SortDataService;

        public HeapSortsController(IUnitOfWork unitOfWork, SortDataService SortDataService)
        {
            _unitOfWork = unitOfWork;
            _SortDataService = SortDataService;
        }
        #endregion

        #region Sort Data By Heap Sorting
        [HttpGet("SortDataByHeap")]
        public IActionResult SortData()
        {
            var data = _unitOfWork.TbSensorDataSampleRepository.GetAll().ToList();
            _SortDataService.HeapSort(data);

            if(data == null)
            {
                return BadRequest(string.Empty);
            }
            // إرجاع استجابة مناسبة
            return Ok(data);
        }
        #endregion
    }
}
