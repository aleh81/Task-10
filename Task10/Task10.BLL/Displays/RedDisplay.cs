﻿using System;
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
			Console.WriteLine(text);
		}

		public override void Show_EventArgs(object sender, TimerEventArgs e)
		{
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(new string(' ', 15) + e.Message);
		}
	}
}
