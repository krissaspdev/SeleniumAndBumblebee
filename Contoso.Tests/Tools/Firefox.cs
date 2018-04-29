using System;
using System.Diagnostics.CodeAnalysis;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Contoso.Tests.Tools
{
	internal class Firefox : IDriverEnvironment
	{
		private readonly TimeSpan _timeToWait;

		public Firefox(TimeSpan timeout)
		{
			_timeToWait = timeout;
		}

		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification =
			"Managing of web driver scope is not important here")]
		public virtual IWebDriver CreateWebDriver()
		{
			var profile = new FirefoxProfile();
			profile.SetPreference("security.insecure_field_warning.contextual.enabled", false);
			profile.SetPreference("browser.privatebrowsing.autostart", true);

			var driver = new FirefoxDriver(profile);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = _timeToWait;

			return driver;
		}
	}
}