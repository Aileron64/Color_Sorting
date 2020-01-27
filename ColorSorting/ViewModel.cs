using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Linq;
using System.Windows.Controls;

namespace ColorSorting
{
    class ViewModel
    {
        public BindingList<Model> Selection { get; set; } = new BindingList<Model>();
        private SelectionSort selectionSort;

        public BindingList<Model> Insertion { get; set; } = new BindingList<Model>();
        private InsertionSort insertionSort;

        public BindingList<Model> Heap { get; set; } = new BindingList<Model>();
        private HeapSort heapSort;

        public BindingList<Model> Bubble { get; set; } = new BindingList<Model>();
        private BubbleSort bubbleSort;

        public BindingList<Model> Cocktail { get; set; } = new BindingList<Model>();
        private CocktailSort cocktailSort;

        public BindingList<Model> Circle { get; set; } = new BindingList<Model>();
        private CircleSort circleSort;

        public BindingList<Model> Merge { get; set; } = new BindingList<Model>();
        private MergeSort mergeSort;

        public BindingList<Model> Quick { get; set; } = new BindingList<Model>();
        private QuickSort quickSort;

        public BindingList<Model> Shell { get; set; } = new BindingList<Model>();
        private ShellSort shellSort;

        const int COLOR_COUNT = 700 / 10;
        const int HEIGHT = 700 / COLOR_COUNT;

        readonly Timer timer = new Timer();
        const float UPDATE_SPEED = 100f;

        readonly Random rand = new Random();

        public ViewModel()
        {
            Start();
        }

        public void Start()
        {
            for (int i = 0; i < COLOR_COUNT; i++)
            {
                int rNum = rand.Next(100, 255);

                Selection.Add(new Model
                {
                    Value = -rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb((byte)rNum, 0, 0))
                });

                Insertion.Add(new Model
                {
                    Value = rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb((byte)rNum, (byte)(rNum / 2), 0))
                });

                Heap.Add(new Model
                {
                    Value = -rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb((byte)rNum, (byte)rNum, 0))
                });

                Bubble.Add(new Model
                {
                    Value = rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb(0, (byte)rNum, 0))
                });

                Cocktail.Add(new Model
                {
                    Value = rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb(0, (byte)rNum, (byte)rNum))
                });

                Circle.Add(new Model
                {
                    Value = -rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb(0, (byte)(rNum / 1.5), (byte)rNum))
                });

                Merge.Add(new Model
                {
                    Value = -rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb((byte)(rNum / 2), 0, (byte)rNum))
                });

                Quick.Add(new Model
                {
                    Value = -rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb((byte)rNum, 0, (byte)rNum))
                }); 

                Shell.Add(new Model
                {
                    Value = -rNum,
                    Height = HEIGHT,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush(Color.FromRgb((byte)rNum, 0, (byte)(rNum / 2)))
                });
            }

            selectionSort = new SelectionSort(Selection);
            insertionSort = new InsertionSort(Insertion);
            heapSort = new HeapSort(Heap);
            bubbleSort = new BubbleSort(Bubble);
            cocktailSort = new CocktailSort(Cocktail);
            circleSort = new CircleSort(Circle);
            mergeSort = new MergeSort(Merge);
            quickSort = new QuickSort(Quick);
            shellSort = new ShellSort(Shell);

            timer.Elapsed += new ElapsedEventHandler(Update);
            timer.Interval = UPDATE_SPEED;
            timer.Enabled = true;
        }

        private void Update(object source, ElapsedEventArgs e)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    selectionSort.Update();
                    insertionSort.Update();
                    heapSort.Update();
                    bubbleSort.Update();
                    cocktailSort.Update();
                    circleSort.Update();
                    mergeSort.Update();
                    quickSort.Update();
                    shellSort.Update();
                });
            }
            catch
            { }
        }
    }

    public class Model : ListViewItem
    {
        public int Value { get; set; }
    }
}
