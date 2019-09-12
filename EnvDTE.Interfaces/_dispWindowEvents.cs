namespace EnvDTE
{
	public interface _dispWindowEvents
	{
		void WindowClosing(Window Window);
		void WindowMoved(Window Window, int Top, int Left, int Width, int Height);
		void WindowActivated(Window GotFocus, Window LostFocus);
		void WindowCreated(Window Window);
	}
}
