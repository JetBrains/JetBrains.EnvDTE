namespace EnvDTE
{
	public enum dbgEventReason
	{
		dbgEventReasonNone = 1,
		dbgEventReasonGo = 2,
		dbgEventReasonAttachProgram = 3,
		dbgEventReasonDetachProgram = 4,
		dbgEventReasonLaunchProgram = 5,
		dbgEventReasonEndProgram = 6,
		dbgEventReasonStopDebugging = 7,
		dbgEventReasonStep = 8,
		dbgEventReasonBreakpoint = 9,
		dbgEventReasonExceptionThrown = 10, // 0x0000000A
		dbgEventReasonExceptionNotHandled = 11, // 0x0000000B
		dbgEventReasonUserBreak = 12, // 0x0000000C
		dbgEventReasonContextSwitch = 13 // 0x0000000D
	}
}
