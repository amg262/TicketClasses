using System;
using NLog.Web;

namespace TicketClasses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            Console.WriteLine("1) Output CSV records.");
            Console.WriteLine("2) Add CSV record. (Legacy code -> tickets.csv");
            Console.WriteLine("3) Bug/Defect");
            Console.WriteLine("4) Enhancement");
            Console.WriteLine("5) Task");
            Console.WriteLine("6) Search");

            int.TryParse(Console.ReadLine(), out var inputNum);

            try
            {
                if (inputNum == 6)
                {
                }

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
                        TicketFileHandler file = new EnhancementFile("enhancements.csv");
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