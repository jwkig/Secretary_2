using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using Secretary.Common;
using Secretary.DbModel;
using Secretary.Properties;

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
            Application.Current.DispatcherUnhandledException += (sender, e) =>
            {
                MessageBox.Show(e.Exception.GetSourceMessage(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {                        
            using (var context = new SecretaryDBContext() {Database = {Connection = {ConnectionString = $"Data Source={Settings.Default.DataBaseFileName}" } }})
            {
                var active = context.Publishers.Where(p => p.IsActive.Value).ToList();
                active.ForEach(p => p.BirhtDade = DateTime.Now);
                //var publisher = new Publisher();
                //context.Publishers.Add(publisher);
                context.SaveChanges();
            }
        }
    }
}