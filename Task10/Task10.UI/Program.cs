using System;
using System.Threading;
using Task10.BLL.Displays;
using Task10.BLL.Services;

namespace Task10.UI
{
	class Program
	{
		public const int Milliseconds = 1000;

		static void Main(string[] args)
		{
			var redDisplay = new RedDisplay();
			var blueDisplay = new BlueDisplay();

			var displayer = new Displayer
				(redDisplay, blueDisplay, Milliseconds);

			#region Timer using events

			var evMethThread = new Thread
				(new ParameterizedThreadStart(displayer.Using_Event));
			evMethThread.Start();

			#endregion

			#region Timer using delegate

			var delMethThread = new Thread
			(new ParameterizedThreadStart
				(displayer.Using_Delegate));
			delMethThread.Start();

			#endregion

			#region Main Thread

			MainThread();

			#endregion

			Console.Read();
		}

		private static void MainThread()
		{
			for (var i = 0; i < 5; i++)
			{
				Thread.Sleep(1000);
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(new string(' ', 35) + "Main Thread");
			}
		}
	}
}
