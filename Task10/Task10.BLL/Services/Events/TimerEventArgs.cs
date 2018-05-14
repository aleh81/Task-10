using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10.BLL.Services.Events
{
	public class TimerEventArgs
	{
		public string Message { get; }

		public TimerEventArgs(string message)
		{
			Message = message;
		}
	}
}
