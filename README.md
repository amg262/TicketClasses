# Ticket Classes: Mid-term Update #

Modify your Ticket system application - add support for different Ticket Types

1. Bug/Defect
2. Enhancement
3. Task

Tickets.csv  --   
TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity

Enhancements.csv  --  
TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate

Tasks.csv  --  
TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate


## The Ticket Object Abstraction and Sub-classes ##

The previous class of Ticket was turned into a abstract class due to each new type of ticket (tasks, enhancements, bugs)
all will contain a large portion of common fields and code. Abstraction and inheritance is best used for this.

```c#
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
    public Bug(string severity, string ticketId = null, string summary = null, string status = null,
        string priority = null, string submitter = null, string assigned = null, string watching = null) : base(
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
    public Enhancement(string software, double cost, string reason, double estimate, string ticketId = null,
        string summary = null, string status = null, string priority = null, string submitter = null,
        string assigned = null, string watching = null) : base(ticketId, summary, status, priority, submitter,
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
    public Task(string projectName, DateTime dueDate, string ticketId = null, string summary = null,
        string status = null, string priority = null, string submitter = null, string assigned = null,
        string watching = null) : base(ticketId, summary, status, priority, submitter, assigned, watching)
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
```

## The TicketFileHandler and Sub-classes ##

I abstracted the TicketFile class into a Handler class with 3 implementations needed due to the different formats
because of the different fields used in objects ToString() override.

```c#
public abstract class TicketFileHandler
{
    public TicketFileHandler(string filePath, List<Ticket> ticketsList = null)
    {
        FilePath = filePath;
        TicketsList = ticketsList;
        count = 0;
    }

    public uint count { get; set; }
    public string FilePath { get; set; }
    public List<Ticket> TicketsList { get; set; }
    public StreamReader Reader { get; set; }
    public StreamWriter Writer { get; set; }
    public bool IsCreated { get; set; }

    public void WriteToFile(Ticket ticket)
    {
        Writer = new StreamWriter(FilePath, true);
        Writer.WriteLine(ticket.ToString());
        Writer.Close();
    }

    public void ReadFromFile()
    {
        Reader = new StreamReader(FilePath);

        while (!Reader.EndOfStream)
        {
            Console.WriteLine(Reader.ReadLine());
            count++;
        }

        Console.WriteLine($"{count} Record(s) Found");
        Reader.Close();
    }
}

public class TicketFile : TicketFileHandler
{
    public TicketFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
    {
        FilePath = filePath;
    }
    
    public string FilePath { get; set; }
    public List<Ticket> TicketsList { get; set; }
    public StreamReader Reader { get; set; }
    public StreamWriter Writer { get; set; }
    public bool IsCreated { get; set; }


    public new void WriteToFile(Ticket ticket)
    {
        Writer = new StreamWriter(FilePath, true);
        Writer.WriteLine(ticket.ToString());
        Writer.Close();
    }
}

public class EnhancementFile : TicketFileHandler
{
    public EnhancementFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
    {
        FilePath = filePath;
    }

    public string FilePath { get; set; }
    public StreamReader Reader { get; set; }
    public StreamWriter Writer { get; set; }
    public bool IsCreated { get; set; }

    public void WriteToFile(Enhancement ticket)
    {
        Writer = new StreamWriter(FilePath, true);
        Writer.WriteLine(ticket.ToString());
        Writer.Close();
    }
}

public class TaskFile : TicketFileHandler
{
    public TaskFile(string filePath, List<Ticket> ticketsList = null) : base(filePath, ticketsList)
    {
        FilePath = filePath;
    }

    public string FilePath { get; set; }
    public StreamReader Reader { get; set; }
    public StreamWriter Writer { get; set; }
    public bool IsCreated { get; set; }


    public void WriteToFile(Task ticket)
    {
        Writer = new StreamWriter(FilePath, true);

        Writer.WriteLine(ticket.ToString());

        Writer.Close();
    }
}
```

### I know, I should re-used some of this code but didn't due to having this project 100% working and as much as the perfectionist in my head is itching to optimize, the rational & practical side says "Fuck it, its 100% A+ work as is, go to bed. No one will ever even read this GitHub markdown page anyway so even typing this is pointless :)" ###
```c#
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

        int.TryParse(Console.ReadLine(), out var inputNum);

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

                var ticket = new Bug(severity, id, summary, status, priority, submitter, assigned, watching);
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

                var enhancement = new Enhancement(software, cost, reason, estimate, id, summary, status,
                    priority, submitter, assigned, watching);

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

                var task = new Task(projectName, due, id, summary, status, priority, submitter, assigned,
                    watching);

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
```

