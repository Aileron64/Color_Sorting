using System.ComponentModel;

namespace ColorSorting
{
    class CircleSort
    {
        public BindingList<Model> ColorList;

        int low;
        int high;
        int mid;

        enum State
        {
            MAIN,
            TOP,
            BOT
        }

        State state = State.MAIN;       

        int lo;
        int hi;

        public CircleSort(BindingList<Model> colorList)
        {
            ColorList = colorList;

            low = 0;
            high = ColorList.Count - 1;

            lo = low;
            hi = high;
        }

        public void Update()
        {
            switch (state)
            {
            case State.MAIN:

                if (low == high)
                    return;

                if (CircleSorter())
                {
                    mid = (high - low) / 2;
                    high = low + mid;
                    state = State.TOP;
                    low = 0;

                    lo = low;
                    hi = high;
                }
            break;

            case State.TOP:
                if (low == high)
                {
                    state = State.BOT;

                    lo = low;
                    hi = high;
                    return;
                }
                        
                if (CircleSorter())
                {
                    mid = (high - low) / 2;
                    low += mid + 1;
                    high = ColorList.Count - 1;
                    state = State.BOT;

                    lo = low;
                    hi = high;
                }
            break;

            case State.BOT:
                if (low == high)
                {
                    state = State.MAIN;

                    lo = low;
                    hi = high;
                    return;
                }

                if (CircleSorter())
                {
                    state = State.MAIN;

                    lo = low;
                    hi = high;
                }
                break;
            }
        }

        bool CircleSorter()
        {
            if (lo < hi)
            {
                if (ColorList[lo].Value > ColorList[hi].Value)
                {
                    Model tmp = ColorList[lo];
                    ColorList[lo] = ColorList[hi];
                    ColorList[hi] = tmp;
                }
                lo++;
                hi--;
            }

            return !(lo < hi);
        }
    }
}