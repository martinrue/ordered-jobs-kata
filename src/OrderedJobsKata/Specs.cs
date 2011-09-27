using Machine.Specifications;

public class when_job_structure_is_empty_string
{
    Because of = () =>
    {
        orderedJobs = new OrderedJobs(string.Empty);
    };

    It should_produce_an_empty_sequence = () =>
    {
        orderedJobs.Jobs.Length.ShouldEqual(0);
    };

    static OrderedJobs orderedJobs;
}