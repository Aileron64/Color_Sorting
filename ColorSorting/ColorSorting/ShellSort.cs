using System.ComponentModel;

namespace ColorSorting
{
    class ShellSort
    {
        public BindingList<Model> ColorList;
        readonly int total;
        int gap;

        int i;
        int j;

        Model tmp;

        public ShellSort(BindingList<Model> colorList)
        {
            ColorList = colorList;

            total = colorList.Count - 1;
            gap = total / 2;

            i = gap;
            j = i;
            tmp = ColorList[i];
        }

        public void Update()
        {
            if (gap <= 0)
                return;

            if (j >= gap && ColorList[j - gap].Value > tmp.Value)
            {
                ColorList[j] = ColorList[j - gap];
                j -= gap;
            }
            else
            {
                if (i < total)
                {
                    i++;
                    ColorList[j] = tmp;
                    tmp = ColorList[i];
                    j = i;
                }
                else
                {
                    gap /= 2;
                    i = gap;
                }           
            }
        }
    }
}

