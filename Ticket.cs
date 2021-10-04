namespace TicketClasses
{
    public class Ticket
    {
        public Ticket(string ticketId = null, string summary = null, string status = null, string priority = null,
            string submitter = null, string assigned = null, string watching = null)
        {
            TicketID = ticketId;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
        }
        
        

        public string TicketID { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public string Watching { get; set; }

        public override string ToString()
        {
            return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}\n";
        }
    }
}