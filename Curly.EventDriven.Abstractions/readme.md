# Curly.EventDriven.Abstractions

## Goal
Abstractions for implementating event driven software.

## Package content
* `IEvent`
* `IEventBroker`
* `IHandle`

## Usage

1. Events must implement `IEvent`.
    ```csharp
	public class CustomEvent : IEvent
	{
		...
	}
    ```
    
1. Use `IEventBroker` to publish events.
    ```csharp
	public CustomClass(IEventBroker eventBroker)
	{
		_eventBroker = eventBroker;
	}

	public void DoSomething()
	{
		...
		_eventBroker.Publish(new CustomEvent());
	}
	```
1. Create `EventHandlers` that implement `IHandle<TEvent>`.
    ```csharp
    public class CustomEventHandler : IHandle<CustomEvent>
	{
		public void Handle(CustomEvent @event)
		{
			...
		}
	}
    ```

## Example
Check out a simple hello world examle:  [GitHub - Curly.EventDriven - HelloWorld example](https://github.com/BastiaanLinders/EventDriven/tree/develop/Sandbox.Examples/HelloWorld/)