using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketClasses
{
    internal class Program
    {
        public List<Ticket> TicketsList { get; set; }

        public static List<string> CsvRecords { get; set; }

        public static string[] CsvRecordSplit { get; set; }

        private static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            Console.WriteLine("1) Output CSV records.");
            Console.WriteLine("2) Add CSV record. (Legacy code -> tickets.csv");
            Console.WriteLine("3) Bug/Defect");
            Console.WriteLine("4) Enhancement");
            Console.WriteLine("5) Task");
            Console.WriteLine("6) Search");

            Console.WriteLine("Search Query: ");
            string query = Console.ReadLine();

            int.TryParse(Console.ReadLine(), out var inputNum);

            string[] csvRaw = null;
            string[] csvRaw2 = null;
            string[] csvRaw3 = null;

            string line2;
            string line3;
            string line;
            List<string> list = new List<string>();

            List<Bug> bugs = new List<Bug>();
            List<Task> tasks = new List<Task>();
            List<Enhancement> enhance = new List<Enhancement>();
            StreamReader reader = new StreamReader("ticket.csv");
            StreamReader reader2 = new StreamReader("task.csv");
            StreamReader reader3 = new StreamReader("enhancements.csv");


            try
            {
                if (inputNum == 1)
                {
                    Console.WriteLine("(B)ugs  |  (E)nhancements  |  (T)asks");
                    var key = Console.ReadLine().ToUpper();

                    if (key == "B")
                    {
                        TicketFileHandler file = new TicketFile("tickets.csv");
                        file.ReadFromFile();
                    }
                    else if (key == "E")
                    {
                        EnhancementFile file = new EnhancementFile("enhancements.csv");
                        file.ReadFromFile();
                    }
                    else if (key == "T")
                    {
                        TicketFileHandler file = new TaskFile("tasks.csv");
                        file.ReadFromFile();
                    }
                }


                if (inputNum == 2 || inputNum == 3)
                {
                    Console.Write("Ticket ID>");
                    var id = Console.ReadLine();

                    Console.Write("Summary>");
                    var summary = Console.ReadLine();

                    Console.Write("Status>");
                    var status = Console.ReadLine();

                    Console.Write("Priority>");
                    var priority = Console.ReadLine();

                    Console.Write("Submitter>");
                    var submitter = Console.ReadLine();

                    Console.Write("Assigned>");
                    var assigned = Console.ReadLine();

                    Console.Write("Watching>");
                    var watching = Console.ReadLine();

                    Console.Write("Severity>");
                    var severity = Console.ReadLine();

                    var ticket = new Bug(id, summary, status, priority, submitter, assigned, watching, severity);
                    TicketFileHandler file = new TicketFile("tickets.csv");
                    file.WriteToFile(ticket);
                }

                if (inputNum == 4)
                {
                    Console.Write("Ticket ID>");
                    var id = Console.ReadLine();

                    Console.Write("Summary>");
                    var summary = Console.ReadLine();

                    Console.Write("Status>");
                    var status = Console.ReadLine();

                    Console.Write("Priority>");
                    var priority = Console.ReadLine();

                    Console.Write("Submitter>");
                    var submitter = Console.ReadLine();

                    Console.Write("Assigned>");
                    var assigned = Console.ReadLine();

                    Console.Write("Watching>");
                    var watching = Console.ReadLine();

                    Console.Write("Software>");
                    var software = Console.ReadLine();

                    Console.Write("Cost>");
                    double.TryParse(Console.ReadLine(), out var cost);

                    Console.Write("Reason>");
                    var reason = Console.ReadLine();

                    Console.Write("Estimate>");
                    double.TryParse(Console.ReadLine(), out var estimate);

                    var enhancement = new Enhancement(id, summary, status, priority, submitter, assigned, watching,
                        software, cost, reason, estimate);

                    var file = new EnhancementFile("enhancements.csv");
                    file.WriteToFile(enhancement);
                }

                if (inputNum == 5)
                {
                    Console.Write("Ticket ID>");
                    var id = Console.ReadLine();

                    Console.Write("Summary>");
                    var summary = Console.ReadLine();

                    Console.Write("Status>");
                    var status = Console.ReadLine();

                    Console.Write("Priority>");
                    var priority = Console.ReadLine();

                    Console.Write("Submitter>");
                    var submitter = Console.ReadLine();

                    Console.Write("Assigned>");
                    var assigned = Console.ReadLine();

                    Console.Write("Watching>");
                    var watching = Console.ReadLine();

                    Console.Write("Project Name>");
                    var projectName = Console.ReadLine();

                    Console.Write("Due Date>");
                    var due = Convert.ToDateTime(Console.ReadLine());

                    var task = new Task(id, summary, status, priority, submitter, assigned,
                        watching, projectName, due);

                    var file = new TaskFile("tasks.csv");
                    file.WriteToFile(task);
                }

                if (inputNum == 6)
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        csvRaw = line.Split(",");

                        //Console.WriteLine(csvRaw[1]);

                        Bug b = new Bug();

                        b.TicketId = csvRaw[0];
                        b.Summary = csvRaw[1];
                        b.Status = csvRaw[2];
                        b.Priority = csvRaw[3];
                        b.Submitter = csvRaw[4];
                        b.Assigned = csvRaw[5];
                        b.Watching = csvRaw[6];

                        bugs.Add(b);
                    }

                    while (!reader2.EndOfStream)
                    {
                        line2 = reader2.ReadLine();
                        csvRaw2 = line2.Split(",");

                        //Console.WriteLine(csvRaw[1]);

                        Task t = new Task();

                        t.TicketId = csvRaw2[0];
                        t.Summary = csvRaw2[1];
                        t.Status = csvRaw2[2];
                        t.Priority = csvRaw2[3];
                        t.Submitter = csvRaw2[4];
                        t.Assigned = csvRaw2[5];
                        t.Watching = csvRaw2[6];

                        tasks.Add(t);
                    }


                    while (!reader3.EndOfStream)
                    {
                        line3 = reader3.ReadLine();
                        csvRaw3 = line3.Split(",");

                        //Console.WriteLine(csvRaw[1]);

                        Enhancement e = new Enhancement();

                        e.TicketId = csvRaw3[0];
                        e.Summary = csvRaw3[1];
                        e.Status = csvRaw3[2];
                        e.Priority = csvRaw3[3];
                        e.Submitter = csvRaw3[4];
                        e.Assigned = csvRaw3[5];
                        e.Watching = csvRaw3[6];

                        enhance.Add(e);
                    }

                    reader.Close();
                    reader2.Close();
                    reader3.Close();

                    List<Ticket> tix = new List<Ticket>();

                    foreach (var bug in bugs.Where(m => m.TicketId.Contains(query))) tix.Add(bug);
                    foreach (var bug in bugs.Where(m => m.Summary.Contains(query))) tix.Add(bug);
                    foreach (var bug in bugs.Where(m => m.Status.Contains(query))) tix.Add(bug);
                    foreach (var bug in bugs.Where(m => m.Priority.Contains(query))) tix.Add(bug);
                    foreach (var bug in bugs.Where(m => m.Submitter.Contains(query))) tix.Add(bug);
                    foreach (var bug in bugs.Where(m => m.Assigned.Contains(query))) tix.Add(bug);
                    foreach (var bug in bugs.Where(m => m.Watching.Contains(query))) tix.Add(bug);

                    foreach (var enhancement in enhance.Where(m => m.TicketId.Contains(query))) tix.Add(enhancement);
                    foreach (var enhancement in enhance.Where(m => m.Summary.Contains(query))) tix.Add(enhancement);
                    foreach (var enhancement in enhance.Where(m => m.Status.Contains(query))) tix.Add(enhancement);
                    foreach (var enhancement in enhance.Where(m => m.Priority.Contains(query))) tix.Add(enhancement);
                    foreach (var enhancement in enhance.Where(m => m.Submitter.Contains(query))) tix.Add(enhancement);
                    foreach (var enhancement in enhance.Where(m => m.Assigned.Contains(query))) tix.Add(enhancement);
                    foreach (var enhancement in enhance.Where(m => m.Watching.Contains(query))) tix.Add(enhancement);


                    foreach (var task in tasks.Where(m => m.TicketId.Contains(query))) tix.Add(task);
                    foreach (var task in tasks.Where(m => m.Summary.Contains(query))) tix.Add(task);
                    foreach (var task in tasks.Where(m => m.Status.Contains(query))) tix.Add(task);
                    foreach (var task in tasks.Where(m => m.Priority.Contains(query))) tix.Add(task);
                    foreach (var task in tasks.Where(m => m.Submitter.Contains(query))) tix.Add(task);
                    foreach (var task in tasks.Where(m => m.Assigned.Contains(query))) tix.Add(task);
                    foreach (var task in tasks.Where(m => m.Watching.Contains(query))) tix.Add(task);

                    foreach (var a in tix)
                    {
                        Console.WriteLine(a.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw;
            }
        }
    }
}