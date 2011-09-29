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

public class when_job_structure_contains_multiple_jobs_with_single_dependency
{
    Because of = () =>
    {
        orderedJobs = new OrderedJobs(@"a => 
                                        b => c
                                        c => ");
    };

    It should_produce_a_sequence_containing_each_job_in_correct_order = () =>
    {
        orderedJobs.Jobs[0].ShouldEqual('a');
        orderedJobs.Jobs[1].ShouldEqual('c');
        orderedJobs.Jobs[2].ShouldEqual('b');
    };

    static OrderedJobs orderedJobs;
}

public class when_job_structure_contains_multiple_jobs_with_chained_dependencies
{
    Because of = () =>
    {
        orderedJobs = new OrderedJobs(@"a => 
                                        b => c
                                        c => f
                                        d => a
                                        e => b
                                        f => ");
    };

    It should_produce_a_sequence_containing_each_job_in_correct_order = () =>
    {
        orderedJobs.Jobs[0].ShouldEqual('a');
        orderedJobs.Jobs[1].ShouldEqual('f');
        orderedJobs.Jobs[2].ShouldEqual('c');
        orderedJobs.Jobs[3].ShouldEqual('b');
        orderedJobs.Jobs[4].ShouldEqual('d');
        orderedJobs.Jobs[5].ShouldEqual('e');
    };

    static OrderedJobs orderedJobs;
}