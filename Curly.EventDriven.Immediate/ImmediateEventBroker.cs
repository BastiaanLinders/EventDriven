using System;
using System.Collections.Generic;
using System.Linq;
using Curly.EventDriven.Abstractions;
using Microsoft.Extensions.Logging;

namespace Curly.EventDriven.Immediate
{
	public class ImmediateEventBroker : IEventBroker
	{
		private readonly ILogger _logger;
		private readonly IServiceProvider _serviceProvider;

		public ImmediateEventBroker(ILogger<ImmediateEventBroker> logger, IServiceProvider serviceProvider)
		{
			_logger = logger;
			_serviceProvider = serviceProvider;
		}

		public void Publish<T>(T logicEvent) where T : IEvent
		{
			_logger.LogTrace($"Event was published of type {typeof(T)}");
			var handlers = ((IEnumerable<IHandle<T>>) _serviceProvider.GetService(typeof(IEnumerable<IHandle<T>>)))
				.ToList();

			foreach (var handler in handlers)
			{
				_logger.LogTrace($"Invoking handle on {handler.GetType()}.");
				handler.Handle(logicEvent);
			}
		}
	}
}