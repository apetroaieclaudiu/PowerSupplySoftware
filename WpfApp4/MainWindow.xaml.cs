using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort _serialPort = new SerialPort();
        public MainWindow()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            InitializeComponent();

            // Display each port name to the console.
            foreach (string port in ports)
            {
                ConnectionList.Items.Add(port);
            }
        }

        private void ConnectionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _serialPort.PortName = ConnectionList.SelectedItem.ToString();
                _serialPort.BaudRate = 115200;
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                ConnectionStatus.Text = "Error";
            }
            finally {
                if (_serialPort.IsOpen)
                    ConnectionStatus.Text = "Connected";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConnectionStatus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
