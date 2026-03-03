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

using Ivi.Visa;

namespace HMC8043
{
    public partial class MainWindow : Window
    {
        private IMessageBasedSession _session;
        private bool _isOutputOn = false;
        private string _canal = "1"; // Valoarea implicita

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string resourceName = TxtDeviceId.Text;

                // Deschidem conexiunea
                _session = GlobalResourceManager.Open(resourceName) as IMessageBasedSession;

                _session.FormattedIO.WriteLine("*IDN?");
                string idnResponse = _session.FormattedIO.ReadLine();

                TxtStatus.Text = "Conectat:\n" + idnResponse;
                TxtStatus.Foreground = Brushes.Green;
            }
            catch (Exception ex)
            {
                TxtStatus.Text = "Eroare conectare:\n" + ex.Message;
                TxtStatus.Foreground = Brushes.Red;

                if (_session != null)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (RbCh1.IsChecked == true) _canal = "1";
            else if (RbCh2.IsChecked == true) _canal = "2";
            else if (RbCh3.IsChecked == true) _canal = "3";
            _session.FormattedIO.WriteLine($"INST OUT{_canal}");

            string tensiune = TxtVoltage.Text.Replace(',', '.');
            string curent = TxtCurrent.Text.Replace(',', '.');

            _session.FormattedIO.WriteLine($"VOLT {tensiune}");
            _session.FormattedIO.WriteLine($"CURR {curent}");
            MessageBox.Show($"Setări aplicate cu succes pe CH{_canal} ({tensiune}V, {curent}A)");


        }

        private void BtnOutput_Click(object sender, RoutedEventArgs e)
        {
            _isOutputOn = !_isOutputOn;
            if (RbCh1.IsChecked == true) _canal = "1";
            else if (RbCh2.IsChecked == true) _canal = "2";
            else if (RbCh3.IsChecked == true) _canal = "3";

            _session.FormattedIO.WriteLine($"INST OUT{_canal}");

            _session.FormattedIO.WriteLine("OUTP?");
            string stareaCurenta = _session.FormattedIO.ReadLine().Trim(); // .Trim() pentru a elimina spatiile 

            if (stareaCurenta == "0") 
            {
                _session.FormattedIO.WriteLine("OUTP 1"); 

                BtnOutput.Background = System.Windows.Media.Brushes.LightGreen;
                BtnOutput.Content = $"CH{_canal} ON";
                MessageBox.Show($"Canalul {_canal} a fost ACTIVAT");
            }
            else 
            {
                _session.FormattedIO.WriteLine("OUTP 0"); 

                BtnOutput.Background = System.Windows.Media.Brushes.LightCoral;
                BtnOutput.Content = $"CH{_canal} OFF";
                MessageBox.Show($"Canalul {_canal} a fost DEZACTIVAT");
                
            }
        }
    }
}