
using EnvDTE;


namespace EnvDTE80
{
	public interface CodeTypeRef2 : CodeTypeRef
	{
		new DTE DTE { get; }
		new object Parent { get; }
		new vsCMTypeRef TypeKind { get; }
		new CodeType CodeType { get; set; }
		new CodeTypeRef ElementType { get; set; }
		new string AsString { get; }
		new string AsFullName { get; }
		new int Rank { get; set; }
		bool IsGeneric { get; }
		new CodeTypeRef CreateArrayType(int Rank = 1);
	}
}
