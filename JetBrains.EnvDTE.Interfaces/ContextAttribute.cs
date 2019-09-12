namespace EnvDTE
{
	public interface ContextAttribute
	{
		string this[] { get; }
		DTE DTE { get; }
		ContextAttributes Collection { get; }
		object Values { get; }
		void Remove();
	}
}
