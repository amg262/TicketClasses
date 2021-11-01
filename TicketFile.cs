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

        public List<string> CsvRecords { get; set; }

        public string[] CsvRecordSplit { get; set; }
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
            int i = 0;
            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
                CsvRecords.Add((string) Console.ReadLine());
                CsvRecordSplit = CsvRecords[i].Split(",");

                count++;
            }

            foreach (var v in CsvRecords)
            {
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

        public new List<Ticket> ReadFromFile()
        {
            Reader = new StreamReader(FilePath);
            int i = 0;
            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
                CsvRecords.Add((string) Console.ReadLine());
                CsvRecordSplit = CsvRecords[i].Split(",");
                Ticket t = new Bug(CsvRecordSplit[0], CsvRecordSplit[1], CsvRecordSplit[2], CsvRecordSplit[3],
                    CsvRecordSplit[4], CsvRecordSplit[5], CsvRecordSplit[6], CsvRecordSplit[7]);
                TicketsList.Add(t);
                count++;
            }

            Console.WriteLine($"{count} Record(s) Found");
            Reader.Close();

            return TicketsList;
        }
    }

    public class EnhancementFile
    {
        public EnhancementFile(string filePath, List<Ticket> ticketsList = null)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        public bool IsCreated { get; set; }

        public List<Ticket> TicketsList { get; set; }

        public List<string> CsvRecords { get; set; }

        public string[] CsvRecordSplit { get; set; }

        private int count;
        public void WriteToFile(Enhancement ticket)
        {
            Writer = new StreamWriter(FilePath, true);
            Writer.WriteLine(ticket.ToString());
            Writer.Close();
        }

        public new List<Ticket> ReadFromFile()
        {
            Reader = new StreamReader(FilePath);
            int i = 0;
            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
                CsvRecords.Add((string) Reader.ReadLine());
                CsvRecordSplit = CsvRecords[i].Split(",");
                Ticket t = new Enhancement(CsvRecordSplit[0], CsvRecordSplit[1], CsvRecordSplit[2], CsvRecordSplit[3],
                    CsvRecordSplit[4], CsvRecordSplit[5], CsvRecordSplit[6], CsvRecordSplit[7],
                    Convert.ToDouble(CsvRecordSplit[8]), CsvRecordSplit[7], Convert.ToDouble(CsvRecordSplit[8]));
                TicketsList.Add(t);
                count++;
            }


            Console.WriteLine($"tix: {TicketsList.Count}");
            //Console.WriteLine($"{count} Record(s) Found");
            Reader.Close();

            return TicketsList;
        }
        
        public List<Ticket> ReadFromFile2()
        {
            Reader = new StreamReader(FilePath);
            int i = 0;
            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
                CsvRecords.Add((string) Console.ReadLine());
                CsvRecordSplit = CsvRecords[i].Split(",");
                Ticket t = new Enhancement(CsvRecordSplit[0], CsvRecordSplit[1], CsvRecordSplit[2], CsvRecordSplit[3],
                    CsvRecordSplit[4], CsvRecordSplit[5], CsvRecordSplit[6], CsvRecordSplit[7],
                    Convert.ToDouble(CsvRecordSplit[8]), CsvRecordSplit[7], Convert.ToDouble(CsvRecordSplit[8]));
                TicketsList.Add(t);
                count++;
            }


            Console.WriteLine($"tix: {TicketsList.Count}");
            //Console.WriteLine($"{count} Record(s) Found");
            Reader.Close();

            return TicketsList;
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

        public new List<Ticket> ReadFromFile()
        {
            Reader = new StreamReader(FilePath);
            int i = 0;
            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
                CsvRecords.Add((string) Console.ReadLine());
                CsvRecordSplit = CsvRecords[i].Split(",");
                Ticket t = new Task(CsvRecordSplit[0], CsvRecordSplit[1], CsvRecordSplit[2], CsvRecordSplit[3],
                    CsvRecordSplit[4], CsvRecordSplit[5], CsvRecordSplit[6], CsvRecordSplit[7],
                    Convert.ToDateTime(CsvRecordSplit[8]));
                TicketsList.Add(t);
                count++;
            }

            //Console.WriteLine($"{count} Record(s) Found");
            Reader.Close();

            return TicketsList;
        }
    }
}