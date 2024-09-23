using System.ComponentModel;
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



    //------------------------------------------------------------------------------------------------------

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}