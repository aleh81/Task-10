using System.Threading;
using Task10.BLL.Displays.Abstract;
using Timer = Task10.BLL.Services.Delegates.Timer;

namespace Task10.BLL.Services
{
	public class Displayer
	{
		public Display DisaplayA { get; }

		public Display DisplayB { get; }

		public int Milliseconds { get; }

		public Displayer(Display a, Display b, int milliseconds)
		{
			DisaplayA = a;
			DisplayB = b;
			Milliseconds = milliseconds;
		}

		public void Using_Delegate(object obj)
		{
			var timer = new Timer(Milliseconds);

			timer.StartTime += DisaplayA.Show;
			timer.EndTime += DisplayB.Show;

			//timer.StartTime.Invoke("Hello");
			//That is why better using events.
			//Because external code has access.

			for (var i = 0; i < 5; i++)
			{
				Thread.Sleep(20);
				timer.Begin(); ;
			}
		}

		public void Using_Event(object obj)
		{
			var timer = new Events.Timer(Milliseconds);
			
			timer.StartTime += DisaplayA.Show_EventArgs;
			timer.EndTime += DisplayB.Show_EventArgs;

			//timer.StartTime.Invoke("Hello");
			//this execute imposible, external code has not acess
			//bicause this event.

			for (var i = 0; i < 5; i++)
			{
				timer.Begin();
			}
		}
	}
}
