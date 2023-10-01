namespace Tutorial;

public interface IHigher
{
    void Draw(int i);
}

public class LowerClass
{
    private readonly IHigher _higher;

    public LowerClass(IHigher higher)
    {
        _higher = higher;
    }

    public void Do()
    {
        /*
         * Do stuff here
         */
        
        _higher.Draw(3);
    }
}

public class HigherClass : IHigher
{
    public int DrawnNumber { get; private set; }
    
    public void Do()
    {
        var lower = new LowerClass(this);
        
        lower.Do();
    }

    public void Draw(int i)
    {
        DrawnNumber = i;
    }
}