namespace EnvDTE80
{
    public interface _dispPublishEvents
    {
        void OnPublishBegin(ref bool Continue);
        void OnPublishDone(bool Success);
    }
}
