using System;
using Task10.BLL.Displays.Abstract;
using Task10.BLL.Services.Delegates;

namespace Task10.BLL.Services
{
	public class Displayer
	{
		public Display DisaplayA { get; }
		public Display DisplayB { get; }

		public delegate void EventHandler(Display a, Display b);

		public Displayer(Display a, Display b)
		{
			DisaplayA = a;
			DisplayB = b;
		}

		public void Using_Delegate(object obj)
		{
			var timer = new Timer(1000);

			timer.StartTime += DisaplayA.Show;
			timer.EndTime += DisplayB.Show;

			for (var i = 0; i < 5; i++)
			{
				timer.Begin(); ;
			}

			Console.ResetColor();
			Console.WriteLine();
		}

		public void Using_Event(object obj)
		{
			var eventTimer = new Events.Timer(1000);

			eventTimer.StartTime += DisaplayA.Show_EventArgs;
			eventTimer.EndTime += DisplayB.Show_EventArgs;

			for (var i = 0; i < 5; i++)
			{
				eventTimer.Begin();
			}

			Console.WriteLine();
		}
	}
}
