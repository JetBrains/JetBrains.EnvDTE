namespace EnvDTE80
{
    public enum dbgEventReason2
    {
        dbgEventReason2None = 1,
        dbgEventReason2Go = 2,
        dbgEventReason2AttachProgram = 3,
        dbgEventReason2DetachProgram = 4,
        dbgEventReason2LaunchProgram = 5,
        dbgEventReason2EndProgram = 6,
        dbgEventReason2StopDebugging = 7,
        dbgEventReason2Step = 8,
        dbgEventReason2Breakpoint = 9,
        dbgEventReason2ExceptionThrown = 10, // 0x0000000A
        dbgEventReason2ExceptionNotHandled = 11, // 0x0000000B
        dbgEventReason2UserBreak = 12, // 0x0000000C
        dbgEventReason2ContextSwitch = 13, // 0x0000000D
        dbgEventReason2Evaluation = 14, // 0x0000000E
        dbgEventReason2UnwindFromException = 15 // 0x0000000F
    }
}
