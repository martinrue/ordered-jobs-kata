using System;
using Machine.Specifications;

// Step 1 – Empty String
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

// Step 2 – Single Job
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

// Step 3 – Multiple Jobs
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

// Step 4 – Multiple Jobs, Single Dependency
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

// Step 5 – Multiple Jobs, Multiple Dependencies
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

// Step 6 – Multiple Jobs, Self Referencing Dependency
public class when_job_structure_contains_self_referencing_dependency
{
    Because of = () =>
    {
        try
        {
            new OrderedJobs(@"a => 
                              b => 
                              c => c");
        }
        catch (Exception ex)
        {
            exception = ex;
        }
    };

    It should_throw_an_error = () =>
    {
        exception.Message.ShouldContain("can't depend on themselves");
    };

    static Exception exception;
}

// Step 7 – Multiple Jobs, Circular Dependency Chain
public class when_job_structure_contains_circular_dependency_chain
{
    Because of = () =>
    {
        try
        {
            new OrderedJobs(@"a => 
                              b => c
                              c => f
                              d => a
                              e => 
                              f => b");
        }
        catch (Exception ex)
        {
            exception = ex;
        }
    };

    It should_throw_an_error = () =>
    {
        exception.Message.ShouldContain("can't have circular dependencies");
    };

    static Exception exception;
}