namespace EnvDTE90
{
    public interface HTMLWindow3
    {
        vsHTMLViews CurrentView { get; set; }
        vsHTMLPanes CurrentPane { get; set; }
        void WaitForBackgroundProcessingComplete(vsHTMLBackgroundTasks Task);
    }
}
