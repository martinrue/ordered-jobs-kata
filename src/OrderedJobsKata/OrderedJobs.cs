using System.Collections.Generic;

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
            if (jobHasDependency(job)) addJob(job.Value);

            addJob(job.Key);
        }
    }

    private void addJob(string job)
    {
        if (!Jobs.Contains(job)) Jobs += job;
    }

    private bool jobHasDependency(KeyValuePair<string, string> job)
    {
        return !job.Value.Empty();
    }
}