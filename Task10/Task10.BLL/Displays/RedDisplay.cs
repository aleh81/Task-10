using System;
using Task10.BLL.Displays.Abstract;
using Task10.BLL.Services.Events;

namespace Task10.BLL.Displays
{
	public class RedDisplay : Display
	{
		public override void Show(string text)
		{
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(new string(' ', 45) + text);
		}

		public override void Show_EventArgs(object sender, TimerEventArgs e)
		{
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(new string(' ', 25) + e.Message +
							  " " + e.Seconds + " seconds");
		}

		public override void Show_Ticks(object sender, TimerEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine( new string(' ', 25) + e.Seconds);
		}
	}
}
