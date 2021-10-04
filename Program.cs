using System;
using System.Collections.Generic;
using System.IO;
using NLog.Layouts;
using NLog.Web;

namespace TicketClasses
{
    class Program
    {
        List<Ticket> tix = new List<Ticket>();

        private string file = "ticket.csv";
        private string choice;
        NLog.Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public void GetUserInput()
        {
            Console.WriteLine("1) Output CSV records.");
            Console.WriteLine("2) Add CSV record.");

            choice = Console.ReadLine();
            string stream = "";

            if (choice == "2")
            {
                string record_str = "";
                string rec_str = "";
                string[] records = new string[7];


                Console.Write("Ticket ID>");
                string id = Console.ReadLine();
                records[0] = id;

                Console.Write("Summary>");
                string summary = Console.ReadLine();
                records[1] = summary;


                Console.Write("Status>");
                string status = Console.ReadLine();
                records[2] = status;


                Console.Write("Priority>");
                string priority = Console.ReadLine();
                records[3] = priority;


                Console.Write("Submitter>");
                string submitter = Console.ReadLine();
                records[4] = submitter;


                Console.Write("Assigned>");
                string assigned = Console.ReadLine();
                records[5] = assigned;


                Console.Write("Watching>");
                string watching = Console.ReadLine();
                records[6] = watching;

                Ticket ticket = new Ticket(id, summary, status, priority, submitter, assigned, watching);
            }
        }

        static void Main(string[] args)
        {
            List<Ticket> tickets = new List<Ticket>();
            TicketFile csv = new TicketFile("ticket.csv");

            string file = "tickets.csv";
            string choice;
            string one = "TicketID,Summary,Status,Priority,Submitter,Assigned,Watching";
            string two = "1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones";
            NLog.Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();


            Console.WriteLine("1) Output CSV records.");
            Console.WriteLine("2) Add CSV record.");

            choice = Console.ReadLine();
            string stream = "";

            if (choice == "2")
            {
                string record_str = "";
                string rec_str = "";
                string[] records = new string[7];


                Console.Write("Ticket ID>");
                string id = Console.ReadLine();
                records[0] = id;

                Console.Write("Summary>");
                string summary = Console.ReadLine();
                records[1] = summary;


                Console.Write("Status>");
                string status = Console.ReadLine();
                records[2] = status;


                Console.Write("Priority>");
                string priority = Console.ReadLine();
                records[3] = priority;


                Console.Write("Submitter>");
                string submitter = Console.ReadLine();
                records[4] = submitter;


                Console.Write("Assigned>");
                string assigned = Console.ReadLine();
                records[5] = assigned;


                Console.Write("Watching>");
                string watching = Console.ReadLine();
                records[6] = watching;

                Ticket ticket = new Ticket(id, summary, status, priority, submitter, assigned, watching);

                tickets.Add(ticket);
                csv.WriteToFile(ticket);
            }
            else
            {
                csv.ReadFromFile();
            }
        }
    }
}