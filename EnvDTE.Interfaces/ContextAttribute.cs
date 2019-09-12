namespace EnvDTE
{
	public interface ContextAttribute
	{
		string Name { get; }
		DTE DTE { get; }
		ContextAttributes Collection { get; }
		object Values { get; }
		void Remove();
	}
}
