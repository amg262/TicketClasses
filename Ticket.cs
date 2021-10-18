using System;

namespace TicketClasses
{
    public abstract class Ticket
    {
        public Ticket(string ticketId = null, string summary = null, string status = null, string priority = null,
            string submitter = null, string assigned = null, string watching = null, string severity = null)
        {
            TicketID = ticketId;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            Severity = severity;
        }

        public Ticket()
        {
        }

        public string TicketID { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public string Watching { get; set; }

        public string Severity { get; set; }

        public override string ToString()
        {
            return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}";
        }
    }

    public class Bug : Ticket
    {
        public Bug(string ticketId = null, string summary = null, string status = null, string priority = null,
            string submitter = null, string assigned = null, string watching = null, string severity = null) : base(
            ticketId, summary, status, priority, submitter, assigned, watching, severity)
        {
        }

        public Bug()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }


    public class Enhancement : Ticket
    {
        public Enhancement(string ticketId = null, string summary = null, string status = null, string priority = null,
            string submitter = null, string assigned = null, string watching = null, string software = null,
            double cost = default, string reason = null, double estimate = default)
        {
            TicketID = ticketId;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            Software = software;
            Cost = cost;
            Reason = reason;
            Estimate = estimate;
        }

        public Enhancement()
        {
        }

        public string TicketID { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public string Watching { get; set; }

        public string Software { get; set; }

        public double Cost { get; set; }

        public string Reason { get; set; }

        public double Estimate { get; set; }

        public override string ToString()
        {
            return
                $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}, {Software}, {Cost:C}, {Reason}, {Estimate:N} ";
        }
    }

    public class Task : Ticket
    {
        public Task(string ticketId = null, string summary = null, string status = null, string priority = null,
            string submitter = null, string assigned = null, string watching = null, string severity = null) : base(
            ticketId, summary, status, priority, submitter, assigned, watching, severity)
        {
        }


        public Task(string ticketId = null, string summary = null, string status = null, string priority = null,
            string submitter = null, string assigned = null, string watching = null, string projectName = null,
            DateTime dueDate = default)
        {
            TicketID = ticketId;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            ProjectName = projectName;
            DueDate = dueDate;
        }

        public Task()
        {
        }

        public string TicketID { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public string Watching { get; set; }

        public string ProjectName { get; set; }

        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return
                $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}, {ProjectName}, {DueDate:f}";
        }
    }
}