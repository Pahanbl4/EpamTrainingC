using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
   public class Watcher
    {
        private InfoHandler _infoHandler;
        private FileSystemWatcher _fileWatcher;
        private Task task;
        private string path = ConfigurationManager.AppSettings["Path"];

        public Watcher()
        {
            _infoHandler = new InfoHandler();
            _fileWatcher = new FileSystemWatcher(path, "*.csv")
            {
                NotifyFilter = NotifyFilters.FileName
            };

            _fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileWatcher.Created += new FileSystemEventHandler(OnChanged);
            _fileWatcher.EnableRaisingEvents = true;
        }

       

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            task = new Task(() => CallParse(source, e));
            task.Start();
        }


        public void CallParse(object source, FileSystemEventArgs e)
        {
            string path;
            path = e.FullPath;
            _infoHandler.SaveRecords(path);
        }
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
