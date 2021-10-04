using System;
using System.Collections.Generic;
using System.IO;
using NLog;
using NLog.Web;

namespace TicketClasses
{
    public class TicketFile : IDisposable
    {
        private static Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        
        
        
        public string FilePath { get; set; }
        public List<Ticket> TicketsList { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }

        public TicketFile(string filePath = null, List<Ticket> ticketsList = null)
        {
            FilePath = filePath;
            this.TicketsList = ticketsList;
            this.Reader = new StreamReader(FilePath);
            this.Writer = new StreamWriter(FilePath);
        }

        public void WriteToFile()
        {
            
            if (!File.Exists(FilePath))
            {
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(one);
                sw.WriteLine(two);

                foreach (var index in records)
                {
                    record_str += index;
                    record_str += ",";
                }

                if (record_str.Length > 1)
                {
                    rec_str = record_str.Substring(0, record_str.Length - 1);
                }

                sw.Write(rec_str);

                sw.Close();
            }
            
        }
        

        public void Dispose()
        {
            Reader?.Dispose();
            Writer?.Dispose();
        }
    }
}