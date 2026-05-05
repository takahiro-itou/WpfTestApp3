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

            var person = new Person
            {
                Name = "田中太郎",
                Age = 30,
                Job = "ソフトウェアエンジニア",
            };
            var company = new Company
            {
                Name = "株式会社サンプル",
                Department = "開発部",
            };

            this.DataContext = person;
            this.CompanyGroup.DataContext = company;
        }

    }

    public class Person
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Job { get; set; }
    }
    public class Company
    {
        public required string Name { get; set; }
        public required string Department { get; set; }
    }


}