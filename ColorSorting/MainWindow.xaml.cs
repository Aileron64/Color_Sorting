using System.Windows;
using System.Windows.Input;

namespace ColorSorting
{
    public partial class MainWindow : Window
    {
        readonly ViewModel VM = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM;
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //VM.Start();
                MessageBox.Show("TEST");
            }
        }
    }
}
