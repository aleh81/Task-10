﻿using System;
using System.Reflection;
using System.Threading;

namespace Task10.BLL.Services.Delegates
{
	/// <summary>
	/// This class using delegates
	/// </summary>
	public class Timer
	{
		public delegate void DisplayHandler(string message);

		public DisplayHandler StartTime { get; set; }

		public DisplayHandler EndTime { get; set; }

		private const string EndTimerMessage = "Timer stop";
		private const string StartTimerMessage = "Timer start";

		public int MilliSeconds { get; }

		public object GetTargetStartTimer => StartTime?.Target;

		public object GetTargetEndTimer => EndTime?.Target;

		public MethodInfo GetMethodStartTimer => StartTime?.Method;

		public MethodInfo GetMethodEndtimer => EndTime?.Method;

		public Delegate[] GetInvocationListStartTimer =>
			StartTime?.GetInvocationList();

		public Delegate[] GetInvocationListEndTimer =>
			EndTime?.GetInvocationList();

		public Timer(int miliSecods)
		{
			MilliSeconds = miliSecods;
		}

		public void Begin()
		{
			StartTime?.Invoke(StartTimerMessage);

			Thread.Sleep(MilliSeconds);

			EndTime?.Invoke(EndTimerMessage);
		}
	}
}