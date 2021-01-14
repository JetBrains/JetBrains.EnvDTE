namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsThreadPool
    {
        int ScheduleTask(uint pTaskProc, uint pvParam, uint priority);


        int ScheduleWaitableTask(uint hWait, uint pTaskProc, uint pvParam);


        int UnscheduleWaitableTask(uint hWait);
    }
}
