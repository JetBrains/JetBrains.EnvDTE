using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EnvDTE
{
  
  
  
  public interface EditPoint : TextPoint
  {
    
    new DTE DTE {   get; }

    
    new TextDocument Parent {   get; }

    
    new int Line {  get; }

    
    new int LineCharOffset {  get; }

    
    new int AbsoluteCharOffset {  get; }

    
    new int DisplayColumn {  get; }

    
    new bool AtEndOfDocument {  get; }

    
    new bool AtStartOfDocument {  get; }

    
    new bool AtEndOfLine {  get; }

    
    new bool AtStartOfLine {  get; }

    
    new int LineLength {  get; }

    
    
    new bool EqualTo( TextPoint Point);

    
    
    new bool LessThan( TextPoint Point);

    
    
    new bool GreaterThan( TextPoint Point);

    
    
    new bool TryToShow( vsPaneShowHow How = vsPaneShowHow.vsPaneShowCentered,  object PointOrCount);

    
    
    
    new CodeElement get_CodeElement( vsCMElement Scope);

    
    
    
    new EditPoint CreateEditPoint();

    
    
    void CharLeft( int Count = 1);

    
    
    void CharRight( int Count = 1);

    
    
    void EndOfLine();

    
    
    void StartOfLine();

    
    
    void EndOfDocument();

    
    
    void StartOfDocument();

    
    
    void WordLeft( int Count = 1);

    
    
    void WordRight( int Count = 1);

    
    
    void LineUp( int Count = 1);

    
    
    void LineDown( int Count = 1);

    
    
    void MoveToPoint( TextPoint Point);

    
    
    void MoveToLineAndOffset( int Line,  int Offset);

    
    
    void MoveToAbsoluteOffset( int Offset);

    
    
    void SetBookmark();

    
    
    void ClearBookmark();

    
    
    bool NextBookmark();

    
    
    bool PreviousBookmark();

    
    
    void PadToColumn( int Column);

    
    
    void Insert( string Text);

    
    
    void InsertFromFile( string File);

    
    
    
    string GetText( object PointOrCount);

    
    
    
    string GetLines( int Start,  int ExclusiveEnd);

    
    
    void Copy( object PointOrCount,  bool Append = false);

    
    
    void Cut( object PointOrCount,  bool Append = false);

    
    
    void Delete( object PointOrCount);

    
    
    void Paste();

    
    
    bool ReadOnly( object PointOrCount);

    
    
    bool FindPattern(
       string Pattern,
       int vsFindOptionsValue = 0,
       ref EditPoint EndPoint = null,
       ref TextRanges Tags = null);

    
    
    bool ReplacePattern(
       TextPoint Point,
       string Pattern,
       string Replace,
       int vsFindOptionsValue = 0,
       ref TextRanges Tags = null);

    
    
    void Indent( TextPoint Point = null,  int Count = 1);

    
    
    void Unindent( TextPoint Point = null,  int Count = 1);

    
    
    void SmartFormat( TextPoint Point);

    
    
    void OutlineSection( object PointOrCount);

    
    
    void ReplaceText( object PointOrCount,  string Text,  int Flags);

    
    
    void ChangeCase( object PointOrCount,  vsCaseOptions How);

    
    
    void DeleteWhitespace( vsWhitespaceOptions Direction = vsWhitespaceOptions.vsWhitespaceOptionsHorizontal);
  }
}
