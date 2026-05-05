
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        private readonly Person person;

        public MainWindow()
        {
            InitializeComponent();

            person = new Person
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

        private void OnDecrementAge(object sender, RoutedEventArgs e)
        {
            -- person.Age;
        }
        private void OnIncrementAge(object sender, RoutedEventArgs e)
        {
            ++ person.Age;
        }

    }

    public class Person : INotifyPropertyChanged
    {
        private string _name = "";
        private int _age;
        private string _job = "";

        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Age {
            get => _age;
            set {
                _age = value;
                OnPropertyChanged();
            }
        }
        public string Job {
            get => _job;
            set {
                _job = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Company
    {
        public required string Name { get; set; }
        public required string Department { get; set; }
    }

}
