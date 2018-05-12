using System;
using Timer = Task10.BLL.Services.Timer;
using Task10.BLL.Displays;

namespace Task10.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			var timer = new Timer(1000);

			var redDisplay = new RedDisplay();
			var blueDisplay = new BlueDisplay();

			timer.RegisterHandler(redDisplay.Show);
			timer.RegisterHandler(blueDisplay.Show);

			for(var i=0; i<5; i++)
			{
				timer.Start();
			}

			Console.Read();
		}
	}
}
