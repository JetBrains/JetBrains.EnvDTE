using System;
using JetBrains.Collections.Viewable;
using JetBrains.Diagnostics;

namespace JetBrains.EnvDTE.Client;

// TODO: Replace with premade scheduler, probably SingleThreadScheduler
/// <summary>
/// Executes the given action just in the current thread in Queue method
/// </summary>
public class SimpleInpaceExecutingScheduler(ILog logger) : IScheduler
{
    public void Queue(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            logger.Error(ex);
        }
    }

    public bool IsActive => true;

    public bool OutOfOrderExecution => false;
}
