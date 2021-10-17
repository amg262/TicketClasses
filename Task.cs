using System;

namespace TicketClasses
{
    public class Task
    {
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