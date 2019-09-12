
using EnvDTE;


namespace EnvDTE80
{
	public interface Engine
	{
		string Name { get; }
		string ID { get; }
		int AttachResult { get; }
		DTE DTE { get; }
		Transport Parent { get; }
		Engines Collection { get; }
	}
}
