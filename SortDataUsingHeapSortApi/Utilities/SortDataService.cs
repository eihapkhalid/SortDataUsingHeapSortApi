using SortDataUsingHeapSort.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SortDataUsingHeapSortApi.Utilities
{
    public class SortDataService
    {
        #region HeapSort
        internal void HeapSort(List<TbSensorDataSample> list)
        {
            int n = list.Count;

            // بناء الكومة (إعادة ترتيب المصفوفة)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(list, n, i);

            // استخراج عنصر واحد تلو الآخر من الكومة
            for (int i = n - 1; i >= 0; i--)
            {
                // تحريك الجذر الحالي إلى نهاية المصفوفة
                var temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                // دعوة heapify على الكومة المخفضة
                Heapify(list, i, 0);
            }
        }
        #endregion

        #region Heapify
        void Heapify(List<TbSensorDataSample> list, int n, int i)
        {
            int largest = i; // جذر الكومة
            int l = 2 * i + 1; // اليسار = 2*i + 1
            int r = 2 * i + 2; // اليمين = 2*i + 2

            // إذا كان العنصر اليساري أكبر من الجذر
            if (l < n && list[l].SensorDataValue > list[largest].SensorDataValue)
                largest = l;

            // إذا كان العنصر اليميني أكبر من العنصر الأكبر حتى الآن
            if (r < n && list[r].SensorDataValue > list[largest].SensorDataValue)
                largest = r;

            // إذا لم يكن الجذر أكبر عنصر
            if (largest != i)
            {
                var swap = list[i];
                list[i] = list[largest];
                list[largest] = swap;

                // تكرار العملية بشكل متكرر
                Heapify(list, n, largest);
            }
        } 
        #endregion
    }
}
