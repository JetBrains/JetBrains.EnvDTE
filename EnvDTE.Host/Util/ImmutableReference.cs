namespace JetBrains.EnvDTE.Host.Util
{
	public sealed class ImmutableReference<T>
	{
		public ImmutableReference(T value) => Value = value;
		public T Value { get; }
	}
}
