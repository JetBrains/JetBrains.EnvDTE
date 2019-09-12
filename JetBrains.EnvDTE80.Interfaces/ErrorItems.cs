
using EnvDTE;


namespace EnvDTE80
{
	public interface ErrorItems
	{
		DTE DTE { get; }
		ErrorList Parent { get; }
		int Count { get; }
		ErrorItem Item(object index);
	}
}
