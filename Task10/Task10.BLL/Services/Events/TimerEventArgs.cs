using System;
namespace Task10.BLL.Services.Events
{
	public class TimerEventArgs : EventArgs
	{
		public string Message { get; }

		public TimerEventArgs(string message)
		{
			Message = message;
		}
	}
}
