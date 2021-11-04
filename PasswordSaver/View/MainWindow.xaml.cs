using PasswordSaver.ViewModel;
using System.Windows;

namespace PasswordSaver.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = mainWindowViewModel;

            InitializeComponent();
        }
    }
}
