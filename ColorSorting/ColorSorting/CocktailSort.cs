using System.ComponentModel;

namespace ColorSorting
{
    class CocktailSort
    {
        public BindingList<Model> ColorList;

        int i;
        int top;
        int bot;
        bool dirFlag;

        public CocktailSort(BindingList<Model> colorList)
        {
            ColorList = colorList;
            top = 0;
            bot = 0;
            i = 0;
            dirFlag = true;
        }

        public void Update()
        {
            if (top + bot >= ColorList.Count)
                return;

            if (dirFlag)
            {
                if (ColorList[i].Value < ColorList[i + 1].Value)
                {
                    Model tmp = ColorList[i + 1];
                    ColorList.RemoveAt(i + 1);
                    ColorList.Insert(i, tmp);
                    return;
                }

                i++;

                if (i + 1 >= ColorList.Count - top)
                {
                    bot++;
                    dirFlag = false;
                }
            }
            else
            {
                if (ColorList[i].Value > ColorList[i - 1].Value)
                {
                    Model tmp = ColorList[i - 1];
                    ColorList.RemoveAt(i - 1);
                    ColorList.Insert(i, tmp);
                    return;
                }

                i--;

                if (i < bot)
                {
                    top++;
                    dirFlag = true;
                }
            }
        }
    }
}
