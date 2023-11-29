using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SortDataUsingHeapSort.DataAccess.UnitOfWork;
using SortDataUsingHeapSort.Models;

namespace SortDataUsingHeapSortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataOfSensorsController : ControllerBase
    {
        #region Inject
        private readonly IUnitOfWork _unitOfWork;
        public DataOfSensorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Post Creat SensorData
        [HttpPost("PostSensorData")]
        public IActionResult PostSensorData([FromBody] TbSensorDataSample model)
        {
            try
            {
                var foundSensorData = _unitOfWork.TbSensorDataSampleRepository.Get(e => e.SensorDataId == model.SensorDataId);
                if (foundSensorData != null)
                {
                    #region Update
                    // تحديث  البيانات الحالية
                    foundSensorData.SensorDataId = model.SensorDataId;
                    foundSensorData.SensorDataName = model.SensorDataName;
                    foundSensorData.SensorDataValue = model.SensorDataValue;

                    _unitOfWork.Save(); // لحفظ التغييرات في قاعدة البيانات
                    #endregion
                }
                else
                {
                    #region Add new
                    // إضافة بيانات حساس جديد
                    _unitOfWork.TbSensorDataSampleRepository.Add(model);
                    _unitOfWork.Save(); // لحفظ التغييرات في قاعدة البيانات 
                    #endregion
                }

                #region Ok
                return Ok(model); // إرجاع النموذج بالبيانات المحدثة أو الجديدة 
                #endregion
            }
            catch (Exception ex)
            {
                #region error
                // التعامل مع الاستثناءات
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                #endregion
            }
        }
        #endregion

        #region GetAllSensorData

        [HttpGet("GetAllSensorData")]
        public IActionResult GetAllSensorData()
        {
            var ListSensorData = _unitOfWork.TbSensorDataSampleRepository.GetAll();
            return Ok(ListSensorData); // تحويل القائمة إلى OkObjectResult
        } 
        #endregion

    }
}
