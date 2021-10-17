using System;
using System.Collections.Generic;
using NLog.Web;

namespace TicketClasses
{
    internal class Program2
    {
        private static void Main2(string[] args)
        {
            var tickets = new List<Ticket>();
            var csv = new TicketFile("ticket.csv");
            string choice;
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();


            Console.WriteLine("1) Output CSV records.");
            Console.WriteLine("2) Add CSV record.");
            Console.WriteLine("3) Bug/Defect");
            Console.WriteLine("4) Enhancement");
            Console.WriteLine("5) Task");

            choice = Console.ReadLine();
            Int32.TryParse(Console.ReadLine(), out int inputNum);
            var stream = "";

            try
            {
                if (choice == "1" || inputNum == 1)
                {
                    
                    
                }
                
                if (choice == "2" || inputNum == 2)
                {
                    
                }
                
                if (choice == "3" || inputNum == 3)
                {
                    
                }
                
                if (choice == "4" || inputNum == 4)
                {
                    
                }
                
                if (choice == "5" || inputNum == 5)
                {
                    
                }
                
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