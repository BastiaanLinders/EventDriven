# Curly.EventDriven.Immediate

## Goal
Dead simple implementation of `Curly.EventDriven.Abstractions`. This EventBroker handles events immediately and synchronously, purely focused to keep your code compartmentalized.

## Package content
* `ImmediateEvenBroker`

## Usage

1. Create an `IEvent`.
    ```csharp
    public class TheWorldWasGreetedEvent : IEvent
	{
		public string Message { get; }

		public TheWorldWasGreetedEvent(string message)
		{
			Message = message;
		}
	}
    ```
    
1. Implement an `EventHandler` which implements `IHandle<TEvent>`.
    ```csharp
    public class WorldGreetingsEventHandler : IHandle<TheWorldWasGreetedEvent>
	{
		public void Handle(TheWorldWasGreetedEvent @event)
		{
			Console.WriteLine($"The world was greeted with the following message: '{@event.Message}'");
		}
	}
	```
1. Add the `EventHandler` and `ImmediateEventBroker` to your `IServiceCollection`.
    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddTransient<IHandle<TheWorldWasGreetedEvent>, WorldGreetingsEventHandler>();
        services.AddScoped<IEventBroker, ImmediateEventBroker>();
        ...
    }
    ```
1. `Publish` your `IEvent`.
    ```csharp
        public void GreetTheWorld()
		{
			Console.WriteLine("Hello world!!!");
			_eventBroker.Publish(new TheWorldWasGreetedEvent("Hello world!!!"));
		}
    ```

## Example
Check out the Example described above:  [GitHub - Curly.EventDriven - HelloWorld example](https://github.com/BastiaanLinders/EventDriven/tree/develop/Sandbox.Examples/HelloWorld/)