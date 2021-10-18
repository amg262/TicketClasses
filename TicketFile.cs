using System;
using System.Collections.Generic;
using System.IO;

namespace TicketClasses
{
    public abstract class TicketFileHandler
    {
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
        public EnhancementFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
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
        public TaskFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
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