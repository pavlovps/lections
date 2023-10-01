namespace Tutorial;

public class SRP
{
    public bool IsNumberInFileNonSRP(string fileName)
    {
        var text = File.ReadAllText(fileName);

        var numberIsIn = text.Contains("1");

        return numberIsIn;
    }

    private string ReadText(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    private bool CheckNumber(string text)
    {
        return text.Contains("1");
    }

    public bool IsNumberInFileSRP(string fileName)
    {
        var text = ReadText(fileName);
        
        var numberIsIn = CheckNumber(text);

        return numberIsIn;
    }
}