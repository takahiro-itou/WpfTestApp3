
using System.Windows.Controls;
using WpfTestApp3.ViewModels;

namespace WpfTestApp3.Views
{
    public partial class CounterView : UserControl
    {
        public CounterView()
        {
            InitializeComponent();
        }

        public void SetViewModel(CounterViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}
