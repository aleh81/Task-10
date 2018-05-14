using System;
namespace Task10.BLL.Services.Events
{
	public class TimerEventArgs : EventArgs
	{
		public string Message { get; }

		public int Seconds { get; }

		public TimerEventArgs(string message, int seconds)
		{
			Message = message;
			Seconds = seconds;
		}
	}
}
