using System;
using Task10.BLL.Displays.Abstract;
using Task10.BLL.Services.Events;

namespace Task10.BLL.Displays
{
	public class BlueDisplay : Display
	{
		public override void Show(string text)
		{
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(text);
		}

		public override void Show_EventArgs(object sender, TimerEventArgs e)
		{
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(e.Message +
			                  " " + e.Seconds + " seconds");
		}

		public override void Show_Ticks(object sender, TimerEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(e.Seconds);
		}
	}
}
