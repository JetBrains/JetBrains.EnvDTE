
using EnvDTE;


namespace EnvDTE80
{
	public interface ErrorItem
	{
		DTE DTE { get; }
		ErrorItems Collection { get; }
		vsBuildErrorLevel ErrorLevel { get; }
		string Description { get; }
		string FileName { get; }
		int Line { get; }
		int Column { get; }
		string Project { get; }
		void Navigate();
	}
}
