using System.ComponentModel;

namespace ColorSorting
{
    class QuickSort
    {
        public BindingList<Model> ColorList;

        int low;
        int high;

        int i;
        int j;

        Model pivot;

        public QuickSort(BindingList<Model> colorList)
        {
            ColorList = colorList;
            //Sort(0, colorList.Count - 1);

            low = 0;
            high = colorList.Count - 1;

            i = low - 1;
            pivot = colorList[high];

            Partition(low, high);
        }

        public void Update()
        {

            //if (j < high)
            //{
            //    if (ColorList[j].Value < pivot.Value)
            //    {
            //        i++;

            //        Model temp = ColorList[i];
            //        ColorList[i] = ColorList[j];
            //        ColorList[j] = temp;
            //    }

            //    j++;
            //}
            //else
            //{
            //    Model temp1 = ColorList[i + 1];
            //    ColorList[i + 1] = ColorList[high];
            //    ColorList[high] = temp1;
            //}
        }

        void Sort(int _low, int _high)
        {
            if (_low < _high)
            {
                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = Partition(_low, _high);

                // Recursively sort elements before 
                // partition and after partition 
                Sort(_low, pi - 1);
                Sort(pi + 1, _high);
            }
        }

        int Partition(int _low, int _high)
        {
            Model pivot = ColorList[_high];

            // index of smaller element 
            int _i = (_low - 1);
            for (int _j = _low; _j < _high; _j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (ColorList[_j].Value < pivot.Value)
                {
                    _i++;

                    // swap arr[i] and arr[j] 
                    Model temp = ColorList[_i];
                    ColorList[_i] = ColorList[_j];
                    ColorList[_j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            Model temp1 = ColorList[_i + 1];
            ColorList[_i + 1] = ColorList[_high];
            ColorList[_high] = temp1;

            return _i + 1;
        }
    }
}