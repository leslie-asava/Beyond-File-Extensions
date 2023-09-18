using System;
using System.IO;

class FileModificationMonitor
{
    /*static void Main(string[] args)
    {
        // Specify the directory to monitor
        string directoryToMonitor = @"C:\Users\Leslie\Downloads";

        // Create a new instance of FileSystemWatcher
        FileSystemWatcher watcher = new FileSystemWatcher(directoryToMonitor);

        // Subscribe to the Changed event
        watcher.Changed += OnFileChanged;

        // Set the NotifyFilter to include LastWrite (file changes)
        watcher.NotifyFilter = NotifyFilters.LastWrite;

        // Start monitoring
        watcher.EnableRaisingEvents = true;

        Console.WriteLine($"Monitoring directory: {directoryToMonitor}");
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }*/

    private static void OnFileChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Changed)
        {
            // This event is triggered when a file is changed, including downloads
            Console.WriteLine($"File {e.FullPath} was downloaded or modified.");

            // Perform your desired action here, such as logging the download.
            // You can also check the file extension, size, or other criteria to determine if it's a download.
        }
    }
}
