namespace EnvDTE
{
	public interface IVsGlobalsCallback
	{
		void WriteVariablesToData(string pVariableName, ref object varData);
		void ReadData(Globals pGlobals);
		void ClearVariables();
		void VariableChanged();
		void CanModifySource();
		void GetParent(ref object ppOut);
	}
}
