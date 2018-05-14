using System;
using System.Reflection;
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

		public event DisplayHandler Tick;

		public int Seconds { get; private set; }

		public object GetTargetStartTimer => StartTime?.Target;

		public object GetTargetEndTimer => EndTime?.Target;

		public MethodInfo GetMethodStartTimer => StartTime?.Method;

		public MethodInfo GetMethodEndtimer => EndTime?.Method;

		public MethodInfo GetMethodTick => Tick?.Method;

		public Delegate[] GetInvocationListStartTimer =>
			StartTime?.GetInvocationList();

		public Delegate[] GetInvocationListEndTimer =>
			EndTime?.GetInvocationList();

		public Delegate[] GetInvocationListTick =>
			Tick?.GetInvocationList();

		public Timer(int seconds)
		{
			Seconds = seconds;
		}

		public void Begin()
		{
			var stop = false;

			var thread = new Thread(new ThreadStart(() =>
			{
				while (!stop)
				{
					var timerState = "Start";

					OnStart(this, new TimerEventArgs
						(timerState, Seconds));

					do
					{

						OnTick(this, new TimerEventArgs(timerState, Seconds));
						Seconds--;

						Thread.Sleep(1000);

						timerState = "During";

					} while (Seconds > 0);

					stop = true;
					timerState = "End";

					OnEnd(this, new TimerEventArgs
						(timerState, Seconds));
				}
			}));

			thread.Start();
		}

		protected virtual void OnTick(object sender, TimerEventArgs e)
		{
			Tick?.Invoke(sender, e);
		}

		protected virtual void OnStart(object sender, TimerEventArgs e)
		{
			StartTime?.Invoke(sender, e);
		}

		protected virtual void OnEnd(object sender, TimerEventArgs e)
		{
			EndTime?.Invoke(sender, e);
		}
	}
}
