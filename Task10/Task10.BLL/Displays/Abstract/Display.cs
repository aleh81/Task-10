using Task10.BLL.Services.Events;

namespace Task10.BLL.Displays.Abstract
{
	public abstract class Display
	{
		public abstract void Show(string text);

		public abstract void Show_EventArgs(object sender, TimerEventArgs e);
	}
}
