namespace EnvDTE
{
	public interface Macros
	{
		DTE DTE { get; }
		DTE Parent { get; }
		bool IsRecording { get; }
		void EmitMacroCode(string Code);
		void Pause();
		void Resume();
	}
}
