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

        public List<string> Preset = new List<string>()
        {
            "TicketID,Summary,Status,Priority,Submitter,Assigned,Watching",
            "1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones"
        };

        public string FilePath { get; set; }
        public List<Ticket> TicketsList { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }

        public TicketFile(string filePath, List<Ticket> ticketsList = null)
        {
            FilePath = filePath;
            this.TicketsList = ticketsList;
        }

        public void WriteToFile(Ticket ticket)
        {
            this.Writer = new StreamWriter(FilePath, true);

            if (!File.Exists(FilePath))
            {
                Writer.WriteLine(Preset[0]);
                Writer.WriteLine(Preset[1]);
            }

            Writer.WriteLine(ticket.ToString());

            Writer.Close();
        }

        public void ReadFromFile()
        {
            this.Reader = new StreamReader(FilePath);

            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
            }

            Reader.Close();
        }

        public void Dispose()
        {
            Reader?.Dispose();
            Writer?.Dispose();
        }
    }
}