
using EnvDTE;


namespace EnvDTE80
{
	public interface EditPoint2 : EditPoint
	{
		new DTE DTE { get; }
		new TextDocument Parent { get; }
		new int Line { get; }
		new int LineCharOffset { get; }
		new int AbsoluteCharOffset { get; }
		new int DisplayColumn { get; }
		new bool AtEndOfDocument { get; }
		new bool AtStartOfDocument { get; }
		new bool AtEndOfLine { get; }
		new bool AtStartOfLine { get; }
		new int LineLength { get; }
		new bool EqualTo(TextPoint Point);
		new bool LessThan(TextPoint Point);
		new bool GreaterThan(TextPoint Point);
		new bool TryToShow(vsPaneShowHow How = vsPaneShowHow.vsPaneShowCentered, object PointOrCount = null);
		new CodeElement get_CodeElement(vsCMElement Scope);
		new EditPoint CreateEditPoint();
		new void CharLeft(int Count = 1);
		new void CharRight(int Count = 1);
		new void EndOfLine();
		new void StartOfLine();
		new void EndOfDocument();
		new void StartOfDocument();
		new void WordLeft(int Count = 1);
		new void WordRight(int Count = 1);
		new void LineUp(int Count = 1);
		new void LineDown(int Count = 1);
		new void MoveToPoint(TextPoint Point);
		new void MoveToLineAndOffset(int Line, int Offset);
		new void MoveToAbsoluteOffset(int Offset);
		new void SetBookmark();
		new void ClearBookmark();
		new bool NextBookmark();
		new bool PreviousBookmark();
		new void PadToColumn(int Column);
		new void Insert(string Text);
		new void InsertFromFile(string File);
		new string GetText(object PointOrCount);
		new string GetLines(int Start, int ExclusiveEnd);
		new void Copy(object PointOrCount, bool Append = false);
		new void Cut(object PointOrCount, bool Append = false);
		new void Delete(object PointOrCount);
		new void Paste();
		new bool ReadOnly(object PointOrCount);

		new bool FindPattern(
			string Pattern,
			int vsFindOptionsValue = 0,
			EditPoint EndPoint = null,
			TextRanges Tags = null);

		new bool ReplacePattern(
			TextPoint Point,
			string Pattern,
			string Replace,
			int vsFindOptionsValue = 0,
			TextRanges Tags = null);

		new void Indent(TextPoint Point = null, int Count = 1);
		new void Unindent(TextPoint Point = null, int Count = 1);
		new void SmartFormat(TextPoint Point);
		new void OutlineSection(object PointOrCount);
		new void ReplaceText(object PointOrCount, string Text, int Flags);
		new void ChangeCase(object PointOrCount, vsCaseOptions How);
		new void DeleteWhitespace(vsWhitespaceOptions Direction = vsWhitespaceOptions.vsWhitespaceOptionsHorizontal);
		void InsertNewLine(int Count = 1);
	}
}
