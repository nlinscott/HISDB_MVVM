using System.Windows;
using HISDB_MVVM_Interface.VM;

namespace HISDB_MVVM_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new NavigationVM();
        }

    }
}
