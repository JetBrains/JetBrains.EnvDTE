namespace EnvDTE
{
	public interface _dispOutputWindowEvents
	{
		void PaneAdded(OutputWindowPane pPane);
		void PaneUpdated(OutputWindowPane pPane);
		void PaneClearing(OutputWindowPane pPane);
	}
}
