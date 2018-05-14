using System;
using Task10.BLL.Displays;
using Task10.BLL.Displays.Abstract;
using TimerEvent = Task10.BLL.Services.Events.Timer;

namespace Task10.UI
{
	class Program
	{
		public const int Seconds = 10;

		static void Main(string[] args)
		{
			var redDisplay = new RedDisplay();
			var blueDisplay = new BlueDisplay();

			#region Test Events

				TestEvents(redDisplay, blueDisplay);

			#endregion

			Console.Read();
		}

		private static void TestEvents(Display displayA, Display displayB)
		{
			var timer = new TimerEvent(Seconds);

			timer.Tick += displayA.Show_Ticks;
			timer.StartTime += displayA.Show_EventArgs;
			timer.EndTime += displayA.Show_EventArgs;

			timer.Tick += displayB.Show_Ticks;
			timer.StartTime += displayB.Show_EventArgs;
			timer.EndTime += displayB.Show_EventArgs;

			timer.Begin();
		}
	}
}
