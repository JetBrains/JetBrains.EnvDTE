namespace EnvDTE
{
	public interface _FontsAndColors
	{
		string FontFamily { get; set; }
		vsFontCharSet FontCharacterSet { get; set; }
		short FontSize { get; set; }
		FontsAndColorsItems FontsAndColorsItems { get; }
	}
}
