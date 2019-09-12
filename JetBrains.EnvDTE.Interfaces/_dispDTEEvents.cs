namespace EnvDTE
{
	public interface _dispDTEEvents
	{
		void OnStartupComplete();
		void OnBeginShutdown();
		void ModeChanged(vsIDEMode LastMode);
		void OnMacrosRuntimeReset();
	}
}
