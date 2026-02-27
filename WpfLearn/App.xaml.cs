using System.Configuration;
using System.Data;
using System.Windows;
using WpfLearn.ViewModel;

namespace WpfLearn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WpfLearn.MainWindow window = new MainWindow();
            UserViewModel VM = new UserViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }

}
