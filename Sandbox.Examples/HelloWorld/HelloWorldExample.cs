using Sandbox.Abstractions;
using Sandbox.Examples.HelloWorld.Abstractions;

namespace Sandbox.Examples.HelloWorld
{
	public class HelloWorldExample : ISandboxTest
	{
		private readonly IHelloWorldService _helloWorldService;

		public HelloWorldExample(IHelloWorldService helloWorldService)
		{
			_helloWorldService = helloWorldService;
		}

		public void Run()
		{
			_helloWorldService.GreetTheWorld();
		}
	}
}