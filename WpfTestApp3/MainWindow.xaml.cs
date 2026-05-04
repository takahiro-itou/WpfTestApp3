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

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string content = ContentTextBox.Text;

            MessageBox.Show($"メモを保存しました（ダミー）\n\nTitle: {title}\nContent: {content}",
                "Save", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnClearButtonClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("内容をクリアしますか？", "Confirm",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if ( result == MessageBoxResult.Yes )
            {
                TitleTextBox.Clear();
                ContentTextBox.Clear();
            }
        }
    }
}