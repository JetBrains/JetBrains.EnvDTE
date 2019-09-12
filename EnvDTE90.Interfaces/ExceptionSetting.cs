
using EnvDTE;


namespace EnvDTE90
{
	public interface ExceptionSetting
	{
		DTE DTE { get; }
		Debugger Parent { get; }
		ExceptionSettings Collection { get; }
		string Name { get; }
		bool BreakWhenThrown { get; }
		bool BreakWhenUserUnhandled { get; }
		bool UserDefined { get; }
		uint Code { get; }
	}
}
