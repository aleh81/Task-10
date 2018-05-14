using System;
namespace Task10.BLL.Services.Events
{
	public class TimerEventArgs
	{
		public string Message { get; }

		public TimerEventArgs(string message)
		{
			Message = message;
		}
	}
}
