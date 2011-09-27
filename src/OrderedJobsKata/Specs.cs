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

public class when_job_structure_contains_single_job
{
    Because of = () =>
    {
        orderedJobs = new OrderedJobs("a => "); 
    };

    It should_produce_a_sequence_containing_the_single_job = () =>
    {
        orderedJobs.Jobs[0].ShouldEqual('a');
    };

    static OrderedJobs orderedJobs;
}

public class when_job_structure_contains_multiple_jobs
{
    Because of = () =>
    {
        orderedJobs = new OrderedJobs(@"a => 
                                        b => 
                                        c => ");
    };

    It should_produce_a_sequence_containing_each_job = () =>
    {
        orderedJobs.Jobs[0].ShouldEqual('a');
        orderedJobs.Jobs[1].ShouldEqual('b');
        orderedJobs.Jobs[2].ShouldEqual('c');
    };

    static OrderedJobs orderedJobs;
}