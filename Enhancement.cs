namespace TicketClasses
{
    public class Enhancement
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
}