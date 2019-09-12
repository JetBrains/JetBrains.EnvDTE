namespace EnvDTE
{
	public interface IDTWizard
	{
		void Execute(
			object Application,
			int hwndOwner,
			ref object[] ContextParams,
			ref object[] CustomParams,
			ref wizardResult retval);
	}
}
