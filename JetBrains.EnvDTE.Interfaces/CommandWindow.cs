namespace EnvDTE
{
	public interface CommandWindow
	{
		DTE DTE { get; }
		Window Parent { get; }
		TextDocument TextDocument { get; }
		void SendInput(string Command, bool Execute);
		void OutputString(string Text);
		void Clear();
	}
}
