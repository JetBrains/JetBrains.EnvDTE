namespace EnvDTE
{
    public interface _EnvironmentGeneral
    {
        vsStartUp OnStartUp { set; get; }
        bool ShowStatusBar { set; get; }
        int WindowMenuContainsNItems { set; get; }
        int MRUListContainsNItems { set; get; }
        short AnimationSpeed { get; set; }
        bool Animations { get; set; }
        bool ShowCommandWindowCompletion { get; set; }
        bool CloseButtonActiveTabOnly { set; get; }
        bool AutohidePinActiveTabOnly { set; get; }
    }
}
