using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Server;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private int port;

    public int Port { get => port; set { port = value; OnPropertyChanged(); } }


    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}