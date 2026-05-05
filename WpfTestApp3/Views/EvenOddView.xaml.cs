
using System.Windows.Controls;
using WpfTestApp3.ViewModels;

namespace WpfTestApp3.Views
{
    /// <summary>
    /// EvenOddView.xaml の相互作用ロジック
    /// </summary>
    public partial class EvenOddView : UserControl
    {
        public EvenOddView()
        {
            InitializeComponent();
        }
        public void SetViewModel(EvenOddViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}
