namespace EnvDTE
{
    public class BuildEventsClass : _BuildEvents, BuildEvents, _dispBuildEvents_Event
    {
        public BuildEventsClass() { }

        public virtual event _dispBuildEvents_OnBuildBeginEventHandler OnBuildBegin;
        public virtual event _dispBuildEvents_OnBuildDoneEventHandler OnBuildDone;
        public virtual event _dispBuildEvents_OnBuildProjConfigBeginEventHandler OnBuildProjConfigBegin;
        public virtual event _dispBuildEvents_OnBuildProjConfigDoneEventHandler OnBuildProjConfigDone;
    }
}
