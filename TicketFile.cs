using System;
using System.Collections.Generic;
using System.IO;

namespace TicketClasses
{
    public abstract class TicketFileHandler
    {
        public List<string> Preset = new()
        {
            "TicketId,Summary,Status,Priority,Submitter,Assigned,Watching",
            "1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones"
        };

        public TicketFileHandler(string filePath, List<Ticket> ticketsList = null)
        {
            FilePath = filePath;
            TicketsList = ticketsList;
            count = 0;
        }

        public uint count { get; set; }
        public string FilePath { get; set; }
        public List<Ticket> TicketsList { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }

        public void WriteToFile(Ticket ticket)
        {
            Writer = new StreamWriter(FilePath, true);
            Writer.WriteLine(ticket.ToString());
            Writer.Close();
        }

        public void ReadFromFile()
        {
            Reader = new StreamReader(FilePath);

            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
                count++;
            }

            Console.WriteLine($"{count} Record(s) Found");
            Reader.Close();
        }
    }

    public class TicketFile : TicketFileHandler
    {
        public List<string> Preset = new()
        {
            "TicketId,Summary,Status,Priority,Submitter,Assigned,Watching",
            "1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones"
        };

        public TicketFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
        {
            FilePath = filePath;
        }


        public string FilePath { get; set; }
        public List<Ticket> TicketsList { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }


        public new void WriteToFile(Ticket ticket)
        {
            Writer = new StreamWriter(FilePath, true);
            Writer.WriteLine(ticket.ToString());
            Writer.Close();
        }
    }

    public class EnhancementFile : TicketFileHandler
    {
        public List<string> Preset = new()
        {
            "TicketId,Summary,Status,Priority,Submitter,Assigned,Watching,Software,Cost,Reason,Estimate",
            "1,This is a enhancement ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones,Adobe Photoshop CC,99.99,We Need It, 10.00"
        };

        public EnhancementFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public List<Ticket> TicketsList { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }

        public void WriteToFile(Enhancement ticket)
        {
            Writer = new StreamWriter(FilePath, true);
            Writer.WriteLine(ticket.ToString());
            Writer.Close();
        }
    }

    public class TaskFile : TicketFileHandler
    {
        public List<string> Preset = new()
        {
            "TicketId,Summary,Status,Priority,Submitter,Assigned,Watching,ProjectName,DueDate",
            $"1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones,Project One,{typeof(DateTime)}"
        };


        public TaskFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public List<Ticket> TicketsList { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }


        public void WriteToFile(Task ticket)
        {
            Writer = new StreamWriter(FilePath, true);

            Writer.WriteLine(ticket.ToString());

            Writer.Close();
        }
    }
}