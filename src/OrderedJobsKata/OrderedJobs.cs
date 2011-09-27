public class OrderedJobs
{
    public string Jobs { get; private set; }

    public OrderedJobs(string jobStructure)
    {
        Jobs = string.Empty;
    }
}