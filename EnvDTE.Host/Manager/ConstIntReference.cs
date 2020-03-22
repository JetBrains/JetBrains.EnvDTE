namespace JetBrains.EnvDTE.Host.Manager
{
	public sealed class ConstIntReference
	{
		public ConstIntReference(int value) => Value = value;
		public int Value { get; }
	}
}
