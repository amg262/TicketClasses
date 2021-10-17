using System;
using System.Collections.Generic;
using System.IO;
using NLog;
using NLog.Web;

namespace TicketClasses
{
    public class EnhancementFile : IDisposable
    {
        private static Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public List<string> Preset = new()
        {
            "TicketID,Summary,Status,Priority,Submitter,Assigned,Watching,Software,Cost,Reason,Estimate",
            "1,This is a enhancement ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones,Adobe Photoshop CC,99.99,We Need It, 10.00"
        };

        public EnhancementFile(string filePath, List<Ticket> ticketsList = null)
        {
            FilePath = filePath;
            TicketsList = ticketsList;
        }

        public string FilePath { get; set; }
        public List<Ticket> TicketsList { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }

        public void Dispose()
        {
            Reader?.Dispose();
            Writer?.Dispose();
        }

        public void WriteToFile(Ticket ticket)
        {
            Writer = new StreamWriter(FilePath, true);

            // if (!File.Exists(FilePath))
            // {
            //     Writer.WriteLine(Preset[0]);
            //     Writer.WriteLine(Preset[1]);
            // }

            Writer.WriteLine(ticket.ToString());

            Writer.Close();
        }

        public void ReadFromFile()
        {
            Reader = new StreamReader(FilePath);

            while (!Reader.EndOfStream) Console.WriteLine(Reader.ReadLine());

            Reader.Close();
        }
    }
}