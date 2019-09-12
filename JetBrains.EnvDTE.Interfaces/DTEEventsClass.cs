using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EnvDTE
{
  
  
  
  
  
  public class DTEEventsClass : _DTEEvents, DTEEvents, _dispDTEEvents_Event
  {
    
    public extern DTEEventsClass();

    public virtual extern event _dispDTEEvents_OnStartupCompleteEventHandler OnStartupComplete;

    
    public virtual extern void add_OnStartupComplete(
      _dispDTEEvents_OnStartupCompleteEventHandler A_1);

    
    public virtual extern void remove_OnStartupComplete(
      _dispDTEEvents_OnStartupCompleteEventHandler A_1);

    public virtual extern event _dispDTEEvents_OnBeginShutdownEventHandler OnBeginShutdown;

    
    public virtual extern void add_OnBeginShutdown(_dispDTEEvents_OnBeginShutdownEventHandler A_1);

    
    public virtual extern void remove_OnBeginShutdown(_dispDTEEvents_OnBeginShutdownEventHandler A_1);

    public virtual extern event _dispDTEEvents_ModeChangedEventHandler ModeChanged;

    
    public virtual extern void add_ModeChanged(_dispDTEEvents_ModeChangedEventHandler A_1);

    
    public virtual extern void remove_ModeChanged(_dispDTEEvents_ModeChangedEventHandler A_1);

    public virtual extern event _dispDTEEvents_OnMacrosRuntimeResetEventHandler OnMacrosRuntimeReset;

    
    public virtual extern void add_OnMacrosRuntimeReset(
      _dispDTEEvents_OnMacrosRuntimeResetEventHandler A_1);

    
    public virtual extern void remove_OnMacrosRuntimeReset(
      _dispDTEEvents_OnMacrosRuntimeResetEventHandler A_1);
  }
}
