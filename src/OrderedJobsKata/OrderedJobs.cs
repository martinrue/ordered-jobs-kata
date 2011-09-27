using System.Linq;

public class OrderedJobs
{
    public string Jobs { get; private set; }

    public OrderedJobs(string jobStructure)
    {
        Jobs = string.Empty;

        if (jobStructure.Length <= 0) return;

        foreach (var job in jobStructure.Split("\r\n"))
        {
            Jobs += job.TrimStart().First();
        }
    }
}