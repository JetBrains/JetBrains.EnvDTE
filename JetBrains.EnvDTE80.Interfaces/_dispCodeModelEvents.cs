
using EnvDTE;


namespace EnvDTE80
{
	public interface _dispCodeModelEvents
	{
		void ElementAdded(CodeElement Element);
		void ElementChanged(CodeElement Element, vsCMChangeKind Change);
		void ElementDeleted(object Parent, CodeElement Element);
	}
}
