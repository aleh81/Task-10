using System.Threading;

namespace Task10.BLL.Services
{
	public class Timer
	{
		public delegate void Display(string message);
		private Display _pusherMessages;

		private const string Message = "Time is over";

		public int MilliSeconds { get; private set; }
		private bool SubscriptionsExist => _pusherMessages != null;

		public Timer(int miliSecods) 
		{
			MilliSeconds = miliSecods;
		}

		public void RegisterHandler(Display display)
		{
			_pusherMessages += display;
		}

		public void UnRegisterHandler(Display display)
		{
			if (SubscriptionsExist)
			{
				_pusherMessages -= display;
			}
		}

		public void Start()
		{
			if (SubscriptionsExist)
			{
				Thread.Sleep(MilliSeconds);

				_pusherMessages.Invoke(Message);
			}
		}
	}
}
