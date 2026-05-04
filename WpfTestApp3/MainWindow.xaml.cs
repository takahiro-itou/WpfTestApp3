using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            string memo = MemoTextBox.Text;
            string? category = (CategoryCombobox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if ( !string.IsNullOrWhiteSpace(memo))
            {
                MemoListView.Items.Add($"{memo} ({category})");
                MemoTextBox.Clear();
            }
        }
    }
}