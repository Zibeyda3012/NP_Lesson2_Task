using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Server;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string imagePath;

    public string ImagePath { get => imagePath; set { imagePath = value; OnPropertyChanged(); } }


    public MainWindow()
    {
        InitializeComponent();
    }

    private void startBtn_Click(object sender, RoutedEventArgs e)
    {
        var port = Convert.ToInt32(portBox.Text);
        var ep = new IPEndPoint(IPAddress.Any, port);

        using var listener = new TcpListener(ep);
        listener.Start();

        MessageBox.Show("Server started,listening to port");

        Task.Run(() =>
        {
            while (true)
            {
                var client = listener.AcceptTcpClient();

                if (client.Connected)
                {
                    using var stream = client.GetStream();
                    using var reader = new StreamReader(stream);
                    var data = reader.ReadToEnd();

                    ImagePath = data;

                }

            }
        });

    }

    //------------------------------------------------------------------------------------------------------

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}