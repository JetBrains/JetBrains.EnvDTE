namespace JetBrains.EnvDTE.Host.Manager
{
	public class IdSource
	{
		private int CurrentId { get; set; }

		public int GenerateNewId()
		{
			CurrentId += 1;
			return CurrentId;
		}
	}
}
