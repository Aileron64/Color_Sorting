using System.ComponentModel;
using System.Windows;

namespace ColorSorting
{
    class HeapSort
    {
        public BindingList<Model> ColorList;

        int i;
        int root;
        bool buildingHeap;

        int heapifyCount;
        bool heapTheCount = false;

        public HeapSort(BindingList<Model> colorList)
        {
            ColorList = colorList;
            i = colorList.Count / 2 - 1;
            root = i;
            buildingHeap = true;
        }

        public void Update()
        {
            if (i < 0 && !buildingHeap) return;

            if (heapTheCount)
            {
                heapTheCount = false;
                Heapify(heapifyCount);
            }
            else if (buildingHeap)
            {
                Heapify(ColorList.Count);
            }
            else
            {
                Model temp = ColorList[0];
                ColorList[0] = ColorList[i];
                ColorList[i] = temp;

                Heapify(i);
            }

            if((heapTheCount || buildingHeap) && i < 0)
            {
                buildingHeap = false;
                i = ColorList.Count - 1;
                root = 0;
            }
        }

        void Heapify(int count)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < count && ColorList[left].Value > ColorList[largest].Value)
                largest = left;

            if (right < count && ColorList[right].Value > ColorList[largest].Value)
                largest = right;

            if (largest != root)
            {
                Model tmp = ColorList[root];
                ColorList[root] = ColorList[largest];
                ColorList[largest] = tmp;

                root = largest;

                heapifyCount = count;
                heapTheCount = true;
            }
            else
            {
                i--;

                if (buildingHeap)
                    root = i;
                else
                    root = 0;
            }
        }
    }
}