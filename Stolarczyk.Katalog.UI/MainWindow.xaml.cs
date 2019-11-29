using System.Windows;

namespace Stolarczyk.Katalog.UI
{
    using Stolarczyk.Katalog.UI.View;
    using Stolarczyk.Katalog.UI.ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            Content = new MainView() {DataContext = viewModel};

        }
    }
}
