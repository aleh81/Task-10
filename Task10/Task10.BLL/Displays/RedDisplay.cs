using System;
using Task10.BLL.Displays.Abstract;

namespace Task10.BLL.Displays
{
	public class RedDisplay : Display
	{
		public override void Show(string text)
		{
			Console.BackgroundColor = ConsoleColor.Red;
			Console.WriteLine(text);
		}
	}
}
