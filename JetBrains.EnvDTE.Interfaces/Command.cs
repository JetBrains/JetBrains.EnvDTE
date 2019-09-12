namespace EnvDTE
{
	public interface Command
	{
		string this[] { get; }
		Commands Collection { get; }
		DTE DTE { get; }
		string Guid { get; }
		int ID { get; }
		bool IsAvailable { get; }
		object Bindings { get; set; }
		string LocalizedName { get; }
		object AddControl(object Owner, int Position = 1);
		void Delete();
	}
}
