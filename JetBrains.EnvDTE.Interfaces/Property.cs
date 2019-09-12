namespace EnvDTE
{
	public interface Property
	{
		object this[] { get; set; }
		short NumIndices { get; }
		object Application { get; }
		Properties Parent { get; }
		string Name { get; }
		Properties Collection { get; }
		object Object { get; set; }
		DTE DTE { get; }
		void let_Value(object lppvReturn);
		object get_IndexedValue(object Index1, object Index2, object Index3, object Index4);
		void set_IndexedValue(object Index1, object Index2, object Index3, object Index4, object Val);
	}
}
