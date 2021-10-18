# Ticket Classes #

Q: Modify your Ticket system application to use appropriate classes and objects

A: I ended up breaking it out to Program.cs, Ticket.cs, TicketFile.cs

### The TicketFile Object ### 

Takes in a Ticket object and writes it to a file or read and outputs the file

```c#
public class TicketFile : IDisposable
    {
        //truncated above code
        public void WriteToFile(Ticket ticket)
        {
            Writer = new StreamWriter(FilePath, true);

            if (!File.Exists(FilePath))
            {
                Writer.WriteLine(Preset[0]);
                Writer.WriteLine(Preset[1]);
            }

            Writer.WriteLine(ticket.ToString());

            Writer.Close();
        }

        public void ReadFromFile()
        {
            Reader = new StreamReader(FilePath);

            while (!Reader.EndOfStream) Console.WriteLine(Reader.ReadLine());

            Reader.Close();
        }
    }
```

