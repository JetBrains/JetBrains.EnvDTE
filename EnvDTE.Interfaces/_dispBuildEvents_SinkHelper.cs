using System;

namespace EnvDTE
{
    public sealed class _dispBuildEvents_SinkHelper : _dispBuildEvents
    {
        public int m_dwCookie;
        public _dispBuildEvents_OnBuildBeginEventHandler m_OnBuildBeginDelegate;
        public _dispBuildEvents_OnBuildDoneEventHandler m_OnBuildDoneDelegate;
        public _dispBuildEvents_OnBuildProjConfigBeginEventHandler m_OnBuildProjConfigBeginDelegate;
        public _dispBuildEvents_OnBuildProjConfigDoneEventHandler m_OnBuildProjConfigDoneDelegate;

        internal _dispBuildEvents_SinkHelper()
        {
        }

        public void OnBuildBegin(vsBuildScope A_1, vsBuildAction A_2)
        {
            throw new NotImplementedException();
        }

        public void OnBuildDone(vsBuildScope A_1, vsBuildAction A_2)
        {
            throw new NotImplementedException();
        }

        public void OnBuildProjConfigBegin(string A_1, string A_2, string A_3, string A_4)
        {
            throw new NotImplementedException();
        }

        public void OnBuildProjConfigDone(
            string A_1,
            string A_2,
            string A_3,
            string A_4,
            bool A_5)
        {
            throw new NotImplementedException();
        }
    }
}
