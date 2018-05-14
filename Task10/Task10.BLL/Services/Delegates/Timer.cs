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

		private DisplayHandler StartTime { get; set; }

		private DisplayHandler EndTime { get; set; }

		private DisplayHandler Tick { get; set; }

		public int Seconds { get; private set; }

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

		public Timer(int miliSecods)
		{
			Seconds = miliSecods;
		}

		public void RegisterStartTimeHandler(DisplayHandler handler)
		{
			StartTime += handler;
		}

		public void RegisterEndTimeHandler(DisplayHandler handler)
		{
			EndTime += handler;
		}

		public void RegisterTickHandler(DisplayHandler handler)
		{
			Tick += handler;
		}

		public void UnRegisterStartTimeHandler(DisplayHandler handler)
		{
			StartTime -= handler;
		}

		public void UnRegisterEndTimeHandler(DisplayHandler handler)
		{
			EndTime -= handler;
		}

		public void UnRegisterTickHandler(DisplayHandler handler)
		{
			Tick -= handler;
		}

		public void Begin()
		{
			var stop = false;

			var thread = new Thread(new ThreadStart(() =>
			{
				while (!stop)
				{
					var timerState = "Start";

					OnStart(timerState + " " + Seconds + " seconds");

					do
					{

						OnTick(Seconds.ToString());
						Seconds--;

						Thread.Sleep(1000);

						timerState = "During";

					} while (Seconds > 0);

					stop = true;
					timerState = "End";

					OnEnd(timerState + " " + Seconds + " seconds");

				}
			}));

			thread.Start();
		}

		protected virtual void OnTick(string message)
		{
			Tick?.Invoke(message);
		}

		protected virtual void OnStart(string message)
		{
			StartTime?.Invoke(message);
		}

		protected virtual void OnEnd(string message)
		{
			EndTime?.Invoke(message);
		}
	}
}
