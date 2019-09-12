
using EnvDTE;


namespace EnvDTE100
{
	public interface Expression2 : Expression
	{
		new string Name { get; }
		new string Type { get; }
		new Expressions DataMembers { get; }
		new string Value { get; set; }
		new bool IsValidValue { get; }
		new DTE DTE { get; }
		new Debugger Parent { get; }
		new Expressions Collection { get; }
		void MakeObjectID();
		void DeleteObjectID();
	}
}
