using Client.Models;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Windows;


namespace Client;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private int port;
    private string filePath;
    private string ıp;

    public int Port { get => port; set { port = value; OnPropertyChanged(); } }

    public string FilePath { get => filePath; set { filePath = value; OnPropertyChanged(); } }

    public string Ip { get => ıp; set { ıp = value; OnPropertyChanged(); } }


    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void SendBtn_Click(object sender, RoutedEventArgs e)
    {
        if (FilePath is not null && FilePath != "" && Port > 0 && Ip is not null && Ip != "")
        {
            var ip = IPAddress.Parse(Ip);
            var endPoint = new IPEndPoint(ip, Port);

            var client = new TcpClient();

            try
            {
                client.Connect(endPoint);

                if (client.Connected)
                {
                    while (true)
                    {
                        var stream = client.GetStream();
                        var writer = new StreamWriter(stream);

                        var data = new FileData(FilePath, Port, Ip);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

    private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

        if (openFileDialog.ShowDialog() == true)
            FilePath = openFileDialog.FileName;

    }


    //-----------------------------------------------------------------------------------------------------

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
