namespace EnvDTE
{
	public interface CodeTypeRef
	{
		DTE DTE { get; }
		object Parent { get; }
		vsCMTypeRef TypeKind { get; }
		CodeType CodeType { get; set; }
		CodeTypeRef ElementType { get; set; }
		string AsString { get; }
		string AsFullName { get; }
		int Rank { get; set; }
		CodeTypeRef CreateArrayType(int Rank = 1);
	}
}
