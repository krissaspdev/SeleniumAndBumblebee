using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Contoso.Model.Common
{
	public class ValidatedTextField<TResult> : TextField<TResult>, IValidatedTextField<TResult> where TResult : IBlock
	{
		private readonly IWebElement _container;

		public ValidatedTextField(IBlock parent, By @by) : base(parent, parent.Tag.FindElement(by).FindElement(By.TagName("input")))
		{
			_container = FindElement(@by);
		}

		public ValidatedTextField(IBlock parent, IWebElement element) : base(parent, element.FindElement(By.TagName("input")))
		{
			_container = element;
		}

		public bool IsValid => string.IsNullOrEmpty(_container.FindElement(By.TagName("span")).Text);
	}
}