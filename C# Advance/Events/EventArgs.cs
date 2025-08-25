using System;
using System.Threading;
public class DownloadEventArgs : EventArgs
{
    public string FileName { get; set; }
    public double Size { get; set; }
}
public class FileDowloaded
{
    public event EventHandler<DownloadEventArgs> DownloadCompleted;
    public void Download(string fileName)
    {
        Console.WriteLine($"Downloading '{fileName}'...");
        Thread.Sleep(2000);
        var args = new DownloadEventArgs
        {
            FileName = fileName,
            Size = new Random().Next(1, 100)
        };
        OnDownloadCompleted(args);
    }
    protected virtual void OnDownloadCompleted(DownloadEventArgs e)
    {
        DownloadCompleted?.Invoke(this, e);
    }
}
public class Example1
{
    public static void Run()
    {
        FileDowloaded downloader = new FileDowloaded();
        downloader.DownloadCompleted += downloader_DownloadCompleted;
        downloader.Download("report.pdf");
    }
    static void downloader_DownloadCompleted(object sender, DownloadEventArgs e)
    {
        Console.WriteLine($"File '{e.FileName}' downloaded ({e.Size} MB).");
    }
}