using System;
using System.Collections.Generic;
using System.Linq;
using Curly.EventDriven.Abstractions;
using Microsoft.Extensions.Logging;

namespace Curly.EventDriven
{
	public class EventBroker : IEventBroker
	{
		private readonly ILogger _logger;
		private readonly IServiceProvider _serviceProvider;

		public EventBroker(ILogger<EventBroker> logger, IServiceProvider serviceProvider)
		{
			_logger = logger;
			_serviceProvider = serviceProvider;
		}

		public void Publish<T>(T logicEvent)
		{
			_logger.LogTrace($"Event was published of type {typeof(T)}");
			var immediateHandlers = (IEnumerable<IHandleImmediately<T>>)_serviceProvider.GetService(typeof(IEnumerable<IHandleImmediately<T>>));
			_logger.LogTrace($"Resolved {immediateHandlers.Count()} eventhandlers");
			foreach (var immediateHandler in immediateHandlers)
			{
				immediateHandler.Handle(logicEvent);
			}
		}
	}
}
