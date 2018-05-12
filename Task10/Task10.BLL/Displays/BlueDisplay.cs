using System;
using Task10.BLL.Displays.Abstract;

namespace Task10.BLL.Displays
{
	public class BlueDisplay : Display
	{
		public override void Show(string text)
		{
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.WriteLine(text);
		}
	}
}
