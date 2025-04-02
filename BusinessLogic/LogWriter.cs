namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LogWriter
    {
        private string logFilePath;

        public LogWriter(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void Write(string message)
        {
            string logEntry = $"{DateTime.Now}: {message}\n";
            File.AppendAllText(this.logFilePath, logEntry);
        }
    }
}
