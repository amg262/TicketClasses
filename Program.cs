using System;
using System.Collections.Generic;
using NLog.Web;

namespace TicketClasses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tickets = new List<Ticket>();
            var csv = new TicketFile("ticket.csv");
            string choice;
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();


            Console.WriteLine("1) Output CSV records.");
            Console.WriteLine("2) Add CSV record.");

            choice = Console.ReadLine();
            var stream = "";

            try
            {
                if (choice == "2")
                {
                    var record_str = "";
                    var rec_str = "";
                    var records = new string[7];


                    Console.Write("Ticket ID>");
                    var id = Console.ReadLine();
                    records[0] = id;

                    Console.Write("Summary>");
                    var summary = Console.ReadLine();
                    records[1] = summary;


                    Console.Write("Status>");
                    var status = Console.ReadLine();
                    records[2] = status;


                    Console.Write("Priority>");
                    var priority = Console.ReadLine();
                    records[3] = priority;


                    Console.Write("Submitter>");
                    var submitter = Console.ReadLine();
                    records[4] = submitter;


                    Console.Write("Assigned>");
                    var assigned = Console.ReadLine();
                    records[5] = assigned;


                    Console.Write("Watching>");
                    var watching = Console.ReadLine();
                    records[6] = watching;

                    var ticket = new Ticket(id, summary, status, priority, submitter, assigned, watching);

                    tickets.Add(ticket);
                    csv.WriteToFile(ticket);
                }
                else
                {
                    csv.ReadFromFile();
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