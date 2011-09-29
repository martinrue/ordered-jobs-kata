using System;
using System.Collections.Generic;
using System.Linq;

public class OrderedJobs
{
    public string Jobs { get; private set; }
    private string jobsInCurrentRecursion;

    public OrderedJobs(string jobStructure)
    {
        Jobs = String.Empty;

        if (jobStructure.Empty()) return;

        var map = jobStructure.ConvertToMap();
        
        map.Each(job => addUniqueJobs(followDependencies(job.Key, map)));
    }

    private void addUniqueJobs(string jobs)
    {
        jobs.Where(job => !Jobs.Contains(job.ToString())).Each(job => Jobs += job);
    }

    private string followDependencies(string job, IDictionary<string, string> map)
    {
        if (map[job].Empty())
        {
            jobsInCurrentRecursion = String.Empty;
            return job;
        }

        if (job == map[job]) throw new Exception("jobs can't depend on themselves");

        keepAnEyeOutForCircularDependencies(job);

        return followDependencies(map[job], map) + job;
    }

    private void keepAnEyeOutForCircularDependencies(string job)
    {
        jobsInCurrentRecursion += job;

        if (jobsInCurrentRecursion.Length != jobsInCurrentRecursion.Distinct().Count())
            throw new Exception("can't have circular dependencies");
    }
}