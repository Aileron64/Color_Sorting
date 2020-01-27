using System.ComponentModel;

namespace ColorSorting
{
    class InsertionSort
    {
        public BindingList<Model> ColorList;

        int i;
        int k;
        Model key;

        public InsertionSort(BindingList<Model> colorList)
        {
            ColorList = colorList;
            key = colorList[1];
            k = 1;
            i = 0;
        }

        public void Update()
        {
            if (k >= ColorList.Count)
                return;

            if(key.Value > ColorList[i].Value)
            {
                ColorList.Remove(key);
                ColorList.Insert(i, key);

                if (i > 0)
                    i--;
                else if(k < ColorList.Count - 1)
                {
                    i = k;
                    k++;
                    key = ColorList[k];
                }
            }
            else if (k < ColorList.Count - 1)
            {
                i = k;
                k++;
                key = ColorList[k];
            }
        }
    }
}

