using System;
using System.Threading;
using Task10.BLL.Displays;
using Task10.BLL.Services;

namespace Task10.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			var redDisplay = new RedDisplay();
			var blueDisplay = new BlueDisplay();

			var displayer = new Displayer(redDisplay, blueDisplay);

			#region Timer using events

			var evMethThread = new Thread(new ParameterizedThreadStart
				(displayer.Using_Event));
			evMethThread.Start();

			#endregion

			#region Timer using delegate

			var delMethThread = new Thread(new ParameterizedThreadStart
				(displayer.Using_Delegate));
			delMethThread.Start();

			#endregion

			Console.Read();
		}
	}
}
