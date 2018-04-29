using System;
using System.Diagnostics.CodeAnalysis;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Contoso.Tests.Tools
{
	internal class Chrome : IDriverEnvironment
	{
		private readonly TimeSpan _timeToWait;

		public Chrome(TimeSpan timeToWait)
		{
			_timeToWait = timeToWait;
		}

		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Managing of web driver scope is not important here")]
		public virtual IWebDriver CreateWebDriver()
		{
			var options = new ChromeOptions();
			options.AddArgument("--incognito");
			options.AddArgument("--no-sandbox");
			options.AddArgument("start-maximized");
			options.AddArgument("--verbose");
			options.SetLoggingPreference(LogType.Driver, LogLevel.All);

			ChromeDriver webDriver = new ChromeDriver(options);
			webDriver.Manage().Timeouts().ImplicitWait = _timeToWait;
			return webDriver;
		}
	}
}