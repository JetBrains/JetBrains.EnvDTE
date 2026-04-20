namespace Microsoft.VisualStudio.ProjectSystem.VS;

public struct HResult
{
  public static readonly HResult OK = 0;
  public static readonly HResult False = 1;
  public static readonly HResult NotImplemented = unchecked((int)0x80004001);
  public static readonly HResult NoInterface = unchecked((int)0x80004002);
  public static readonly HResult MemberNotFound = unchecked((int)0x80020003);
  public static readonly HResult InvalidArg = unchecked((int)0x80070057);
  public static readonly HResult Unexpected = unchecked((int)0x8000FFFF);
  public static readonly HResult Fail = unchecked((int)0x80004005);
  public static readonly HResult Pending = unchecked((int)0x8000000A);
  public static readonly HResult Abort = unchecked((int)0x80004004);
  public static readonly HResult IncompatibleProject = unchecked((int)0x80042003);
  public static readonly HResult UnsupportedFlavorProject = unchecked((int)0x80042010);
  public static readonly HResult WrongThread = unchecked((int)0x8001010E);
  private readonly int _hr;

  private HResult(int hr) : this() => _hr = hr;

  public static implicit operator HResult(int hr) => new(hr);

  public static implicit operator int(HResult result) => result._hr;

  public static bool operator ==(HResult result1, HResult result2) => result1._hr == result2._hr;

  public static bool operator !=(HResult result1, HResult result2) => !(result1 == result2);

  public override bool Equals(object obj) =>
      obj switch
      {
          null => false,
          HResult hresult => hresult._hr == _hr,
          int num => num == _hr,
          _ => false
      };

  public override int GetHashCode() => _hr.GetHashCode();
}
