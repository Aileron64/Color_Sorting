using System.Collections.Generic;
using System.ComponentModel;

namespace ColorSorting
{
    class SelectionSort
    {
        public BindingList<Model> ColorList;

        int i;
        int sorted;
        Model lowestValue;

        public SelectionSort(BindingList<Model> colorList)
        {
            ColorList = colorList;
            i = 0;
            sorted = 0;
        }

        public void Update()
        {
            if (sorted >= ColorList.Count) return;

            if (i == sorted)
                lowestValue = ColorList[i];
            else
            {
                if (ColorList[i].Value < lowestValue.Value)
                    lowestValue = ColorList[i];
            }

            i++;

            if(i >= ColorList.Count)
            {
                ColorList.Remove(lowestValue);
                ColorList.Insert(sorted, lowestValue);

                sorted++;
                i = sorted;
            }
        }
    }
}
