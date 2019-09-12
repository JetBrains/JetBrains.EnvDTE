namespace EnvDTE
{
	public interface IVsTextEditFonts
	{
		string FontFamily { set; get; }
		vsFontCharSet FontCharacterSet { set; get; }
		short FontSize { set; get; }
	}
}
