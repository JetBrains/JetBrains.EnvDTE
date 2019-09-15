namespace EnvDTE
{
    public class BuildEventsClass : _BuildEvents, BuildEvents, _dispBuildEvents_Event
    {
        public extern BuildEventsClass();
        public virtual extern event _dispBuildEvents_OnBuildBeginEventHandler OnBuildBegin;
        public virtual extern event _dispBuildEvents_OnBuildDoneEventHandler OnBuildDone;
        public virtual extern event _dispBuildEvents_OnBuildProjConfigBeginEventHandler OnBuildProjConfigBegin;
        public virtual extern event _dispBuildEvents_OnBuildProjConfigDoneEventHandler OnBuildProjConfigDone;
    }
}
