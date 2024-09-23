namespace Client.Models;

public class FileData
{
    public string FilePath { get; set; }

    public int Port { get; set; }

    public string Ip { get; set; }

    public FileData(string filePath, int port, string ip)
    {
        FilePath = filePath;
        Port = port;
        Ip = ip;
    }
}
