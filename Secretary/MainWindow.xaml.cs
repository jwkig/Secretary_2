using System.Linq;
using System.Windows;
using Secretary.DbModel;

namespace Secretary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private int _count;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new SecretaryDBContext())
            {
                var active = context.Publishers.Where(p => p.IsActive.Value);
                _count = active.Count();
                //var publisher = new Publisher();
                //context.Publishers.Add(publisher);
                //context.SaveChanges();
            }
        }
    }
}