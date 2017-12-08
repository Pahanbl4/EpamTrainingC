using System;
using System.Collections.Generic;
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

        public Watcher()
        {
            _infoHandler = new InfoHandler();
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Path = "C:\\Managers";
            _fileWatcher.Filter = "*.csv";
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;

            _fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileWatcher.Created += new FileSystemEventHandler(OnChanged);
            _fileWatcher.EnableRaisingEvents = true;
        }

        public void run()
        {

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
