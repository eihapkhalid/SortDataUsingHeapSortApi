using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortDataUsingHeapSort.Models
{
    public class TbSensorDataSample
    {
        [Key]
        public int SensorDataId { get; set; }

        [Required(ErrorMessage = "يجب إدخال الاسم")]
        [StringLength(100, ErrorMessage = "يجب ألا يتجاوز الاسم 100 حرف")]
        public string SensorDataName { get; set; }

        [Required(ErrorMessage = "يجب إدخال الراتب")]
        public float SensorDataValue { get; set; }

    }
}
