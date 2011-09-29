using System;
using System.Collections.Generic;
using System.Linq;

public class OrderedJobs
{
    public string Jobs { get; private set; }

    public OrderedJobs(string jobStructure)
    {
        Jobs = String.Empty;

        if (jobStructure.Length <= 0) return;

        var map = jobStructure.ConvertToMap();
        
        map.Each(job => addUniqueJobs(followDependencies(job.Key, map)));
    }

    private string followDependencies(string job, IDictionary<string, string> map)
    {
        if (map[job].Empty()) return job;

        if (job == map[job]) throw new Exception("jobs can't depend on themselves");

        return followDependencies(map[job], map) + job;
    }

    private void addUniqueJobs(string jobs)
    {
        jobs.Where(job => !Jobs.Contains(job.ToString())).Each(job => Jobs += job);
    }
}