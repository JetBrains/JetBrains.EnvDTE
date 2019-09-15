using System;

namespace EnvDTE
{
    internal sealed class _dispSolutionEvents_EventProvider : _dispSolutionEvents_Event, IDisposable
    {
        public _dispSolutionEvents_EventProvider(object A_1)
        {
        }

        public event _dispSolutionEvents_OpenedEventHandler Opened;
        public event _dispSolutionEvents_BeforeClosingEventHandler BeforeClosing;
        public event _dispSolutionEvents_AfterClosingEventHandler AfterClosing;
        public event _dispSolutionEvents_QueryCloseSolutionEventHandler QueryCloseSolution;
        public event _dispSolutionEvents_RenamedEventHandler Renamed;
        public event _dispSolutionEvents_ProjectAddedEventHandler ProjectAdded;
        public event _dispSolutionEvents_ProjectRemovedEventHandler ProjectRemoved;
        public event _dispSolutionEvents_ProjectRenamedEventHandler ProjectRenamed;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
