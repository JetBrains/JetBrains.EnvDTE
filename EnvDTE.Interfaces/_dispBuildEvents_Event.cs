namespace EnvDTE
{
    public interface _dispBuildEvents_Event
    {
        event _dispBuildEvents_OnBuildBeginEventHandler OnBuildBegin;
        event _dispBuildEvents_OnBuildDoneEventHandler OnBuildDone;
        event _dispBuildEvents_OnBuildProjConfigBeginEventHandler OnBuildProjConfigBegin;
        event _dispBuildEvents_OnBuildProjConfigDoneEventHandler OnBuildProjConfigDone;
    }
}
