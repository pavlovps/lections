using Tutorial;

public interface IWorker
{
    string DescribeTheDay(double hours);
}

public abstract class Worker
{
    public string NonVirtual { get; set; } = "Worker";

    public virtual string Virtual { get; set; } = "vWorker";

    public int TryParse(string text)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));

        if (int.TryParse(text, out var i)) return i;
        else throw new ArgumentException($"Text {text} is not int", nameof(text));
    }
}

public class OfficeWorker : Worker, IWorker
{
    public new string NonVirtual { get; set; } = "OfficeWorker";
    
    public override string Virtual { get; set; } = "vOfficeWorker";

    public string DescribeTheDay(double hours)
    {
        return $"I worked at office for {hours} hours";
    }

    public new int TryParse(string text)
    {
        if (text == null) return 0;

        if (text == "let's do") throw new ArithmeticException("Some not expected exception");

        return int.Parse(text);
    }
}

public class RoadWorker : Worker, IWorker
{
    public new string NonVirtual { get; set; } = "RoadWorker";
    
    public override string Virtual { get; set; } = "vRoadWorker";

    public string DescribeTheDay(double hours)
    {
        return $"I worked on road for {hours} hours";
    }
}

public static class Cons
{
    public static void Main()
    {
        OOPExamples();
        CaseExample();
        DIPExample();
    }

    private static void CaseExample()
    {
        IWorker worker = new OfficeWorker();

        if (worker is OfficeWorker) Console.WriteLine("OfficeWorker");
        else if (worker is RoadWorker) Console.WriteLine("RoadWorker");
        else Console.WriteLine("Error");
        
        /*
         OfficeWorker
         */
        
        AskWorkerClass(new OfficeWorker());
        AskWorkerClass(new RoadWorker());
        /*
            Non virtual: Worker
            Virtual: vOfficeWorker
            Non virtual: Worker
            Virtual: vRoadWorker
         */
    }

    private static void OOPExamples()
    {
        AskWorker(new OfficeWorker(), 9.5);

        AskWorker(new RoadWorker(), 3);
        

        /*
            I worked at office for 9,5 hours
            I worked on road for 3 hours
         */
    }

    private static void AskWorker(IWorker worker, double hours)
    {
        Console.WriteLine(worker.DescribeTheDay(hours));
    }
    
    private static void AskWorkerClass(Worker worker)
    {
        Console.WriteLine($"Non virtual: {worker.NonVirtual}");
        
        Console.WriteLine($"Virtual: {worker.Virtual}");
    }

    private static void DIPExample()
    {
        var higher = new HigherClass();
        higher.Do();
        
        Console.WriteLine($"Drawn number: {higher.DrawnNumber}");
        /*
         Drawn number: 3
         */
    }
}