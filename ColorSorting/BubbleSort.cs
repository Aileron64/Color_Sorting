using System.ComponentModel;

namespace ColorSorting
{
    class BubbleSort
    {
        public BindingList<Model> ColorList;

        int i = 0;
        int unsortedCount;

        public BubbleSort(BindingList<Model> colorList)
        {
            ColorList = colorList;
            unsortedCount = colorList.Count;
        }

        public void Update()
        {
            if (unsortedCount == 0)
                return;

            if(ColorList[i].Value < ColorList[i + 1].Value)
            {
                Model tmp = ColorList[i + 1];
                ColorList.RemoveAt(i + 1);
                ColorList.Insert(i, tmp);
                return;
            }

            i++;

            if(i + 1 >= unsortedCount)
            {
                i = 0;
                unsortedCount--;
            }
        }
    }
}
