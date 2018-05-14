using System.Threading;

namespace Task10.BLL.Services.Events
{
	/// <summary>
	/// This class using events
	/// </summary>
	public class Timer 
	{
		public delegate void DisplayHandler(object sender, TimerEventArgs e);

		public event DisplayHandler StartTime;

		public event DisplayHandler EndTime;

		private const string EndTimerMessage = "Timer stop";
		private const string StartTimerMessage = "Timer start";

		public int MilliSeconds { get; }

		public object GetTargetStartTimer => StartTime?.Target;

		public Timer(int miliSecods)
		{
			MilliSeconds = miliSecods;
		}

		public void Begin()
		{
			StartTime?.Invoke(this, new TimerEventArgs(StartTimerMessage));

			Thread.Sleep(MilliSeconds);

			EndTime?.Invoke(this, new TimerEventArgs(EndTimerMessage));
		}
	}
}
