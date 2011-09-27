using System.Linq;

public class OrderedJobs
{
    public string Jobs { get; private set; }

    public OrderedJobs(string jobStructure)
    {
        Jobs = string.Empty;

        if (jobStructure.Length <= 0) return;

        Jobs += jobStructure.First();
    }
}