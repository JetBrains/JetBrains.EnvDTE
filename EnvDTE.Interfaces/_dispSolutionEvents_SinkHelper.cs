using System;

namespace EnvDTE
{
    public sealed class _dispSolutionEvents_SinkHelper : _dispSolutionEvents
    {
        public _dispSolutionEvents_AfterClosingEventHandler m_AfterClosingDelegate;
        public _dispSolutionEvents_BeforeClosingEventHandler m_BeforeClosingDelegate;
        public int m_dwCookie;
        public _dispSolutionEvents_OpenedEventHandler m_OpenedDelegate;
        public _dispSolutionEvents_ProjectAddedEventHandler m_ProjectAddedDelegate;
        public _dispSolutionEvents_ProjectRemovedEventHandler m_ProjectRemovedDelegate;
        public _dispSolutionEvents_ProjectRenamedEventHandler m_ProjectRenamedDelegate;
        public _dispSolutionEvents_QueryCloseSolutionEventHandler m_QueryCloseSolutionDelegate;
        public _dispSolutionEvents_RenamedEventHandler m_RenamedDelegate;

        internal _dispSolutionEvents_SinkHelper()
        {
        }

        public void Opened()
        {
            throw new NotImplementedException();
        }

        public void BeforeClosing()
        {
            throw new NotImplementedException();
        }

        public void AfterClosing()
        {
            throw new NotImplementedException();
        }

        public void QueryCloseSolution(ref bool A_1)
        {
            throw new NotImplementedException();
        }

        public void Renamed(string A_1)
        {
            throw new NotImplementedException();
        }

        public void ProjectAdded(Project A_1)
        {
            throw new NotImplementedException();
        }

        public void ProjectRemoved(Project A_1)
        {
            throw new NotImplementedException();
        }

        public void ProjectRenamed(Project A_1, string A_2)
        {
            throw new NotImplementedException();
        }
    }
}
