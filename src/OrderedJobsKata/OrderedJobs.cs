public class OrderedJobs
{
    public string Jobs { get; private set; }

    public OrderedJobs(string jobStructure)
    {
        Jobs = string.Empty;

        if (jobStructure.Length <= 0) return;

        var map = jobStructure.ConvertToMap();

        foreach (var job in map)
        {
            if (!job.Value.Empty())
            {
                if (!Jobs.Contains(job.Value)) Jobs += job.Value;
            }

            if (!Jobs.Contains(job.Key)) Jobs += job.Key;
        }
    }
}