using System;

namespace EnvDTE
{
	internal sealed class _dispBuildEvents_EventProvider : _dispBuildEvents_Event, IDisposable
	{
		public event _dispBuildEvents_OnBuildBeginEventHandler OnBuildBegin;
		public event _dispBuildEvents_OnBuildDoneEventHandler OnBuildDone;
		public event _dispBuildEvents_OnBuildProjConfigBeginEventHandler OnBuildProjConfigBegin;
		public event _dispBuildEvents_OnBuildProjConfigDoneEventHandler OnBuildProjConfigDone;
		public void Dispose() => throw new NotImplementedException();
	}
}
