using System;
using System.Reflection;
using System.Threading;

namespace Task10.BLL.Services.Delegates
{
	/// <summary>
	/// This class using delegates
	/// </summary>
	public class Timer
	{
		public delegate void DisplayHandler(string message);

		public DisplayHandler StartTime { get; set; } = null;

		public DisplayHandler EndTime { get; set; } = null;

		private const string EndTimerMessage = "Timer stop";
		private const string StartTimerMessage = "Timer start";

		public int MilliSeconds { get; }

		public Timer(int miliSecods)
		{
			MilliSeconds = miliSecods;
		}

		public void Begin()
		{
			StartTime?.Invoke(StartTimerMessage);

			Thread.Sleep(MilliSeconds);

			EndTime?.Invoke(EndTimerMessage);
		}
	}
}
