using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsActivityLog
    {
    int LogEntry( uint actType,  string pszSource,  string pszDescription);

    int LogEntryGuid( uint actType, string pszSource,  string pszDescription,  Guid guid);

    int LogEntryHr( uint actType,  string pszSource,  string pszDescription,  int hr);

    int LogEntryGuidHr( uint actType,  string pszSource,  string pszDescription,  Guid guid,  int hr);

    int LogEntryPath( uint actType,  string pszSource,  string pszDescription,  string pszPath);

    int LogEntryGuidPath(
       uint actType,
       string pszSource,
       string pszDescription,
       Guid guid,
       string pszPath);

    int LogEntryHrPath(
       uint actType,
       string pszSource,
       string pszDescription,
       int hr,
       string pszPath);

    int LogEntryGuidHrPath(
       uint actType,
       string pszSource,
       string pszDescription,
       Guid guid,
       int hr,
       string pszPath);
    }
}
