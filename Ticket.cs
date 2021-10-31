using System;

namespace TicketClasses
{
    public abstract class Ticket
    {
        public Ticket(string ticketId = null, string summary = null, string status = null, string priority = null,
            string submitter = null, string assigned = null, string watching = null)
        {
            TicketId = ticketId;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
        }

        public Ticket()
        {
        }

        public string TicketId { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public string Watching { get; set; }


        public override string ToString()
        {
            return $"{TicketId},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}";
        }
    }

    public class Bug : Ticket
    {
        public Bug(string ticketId = null, string summary = null, string status = null,
            string priority = null, string submitter = null, string assigned = null, string watching = null,
            string severity = null) : base(
            ticketId, summary, status, priority, submitter, assigned, watching)
        {
            Severity = severity;
        }

        public string Severity { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()},{Severity}";
        }
    }


    public class Enhancement : Ticket
    {
        public Enhancement(string ticketId = null,
            string summary = null, string status = null, string priority = null, string submitter = null,
            string assigned = null, string watching = null, string software = null, double cost = default,
            string reason = null, double estimate = default) : base(ticketId, summary, status, priority, submitter,
            assigned, watching)
        {
            Software = software;
            Cost = cost;
            Reason = reason;
            Estimate = estimate;
        }

        public string Software { get; set; }

        public double Cost { get; set; }

        public string Reason { get; set; }

        public double Estimate { get; set; }

        public override string ToString()
        {
            return
                $"{base.ToString()},{Software},{Cost:C},{Reason},{Estimate:N} ";
        }
    }

    public class Task : Ticket
    {
        public Task(string ticketId = null, string summary = null,
            string status = null, string priority = null, string submitter = null, string assigned = null,
            string watching = null,
            string projectName = null, DateTime dueDate = default
        ) : base(ticketId, summary, status, priority, submitter, assigned, watching)
        {
            ProjectName = projectName;
            DueDate = dueDate;
        }

        public string ProjectName { get; set; }

        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {ProjectName}, {DueDate:f}";
        }
    }
}