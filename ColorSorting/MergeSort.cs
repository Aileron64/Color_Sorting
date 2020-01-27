using System.ComponentModel;

namespace ColorSorting
{
    class MergeSort
    {
        public BindingList<Model> ColorList;

        public MergeSort(BindingList<Model> colorList)
        {
            ColorList = colorList;
            Sort();
        }

        public void Update()
        {

        }

        void Sort()
        {
            while (circleSortRec(0, ColorList.Count - 1))
            {
                ;
            }
        }

        bool circleSortRec(int low, int high)
        {
            bool swapped = false;

            // base case 
            if (low == high)
                return false;

            int lo = low, hi = high;

            while (lo < hi)
            {
                // swaps the pair of elements 
                // if true 
                if (ColorList[lo].Value > ColorList[hi].Value)
                {
                    Model tmp = ColorList[lo];
                    ColorList[lo] = ColorList[hi];
                    ColorList[hi] = tmp;
                    swapped = true;
                }
                lo++;
                hi--;
            }

            // special case arises only for list 
            // of odd size 
            if (lo == hi)
                if (ColorList[lo].Value > ColorList[hi + 1].Value)
                {
                    Model tmp = ColorList[lo];
                    ColorList[lo] = ColorList[hi + 1];
                    ColorList[hi + 1] = tmp;
                    swapped = true;
                }

            // recursive case to check the 
            // traverse lists as sub lists 
            int mid = (high - low) / 2;
            bool firstHalf = circleSortRec(low, low + mid);
            bool secondHalf = circleSortRec(low + mid + 1, high);

            return swapped || firstHalf || secondHalf;
        }
    }
}