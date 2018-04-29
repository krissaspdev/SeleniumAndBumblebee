using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Contoso.Model.Common
{
	public class ValidatedDateField<TResult> : DateField<TResult>, IValidatedDateField<TResult> where TResult : IBlock
	{
		private readonly IWebElement _container;

		public ValidatedDateField(IBlock parent, By @by) : base(parent, parent.Tag.FindElement(by).FindElement(By.TagName("input")))
		{
			_container = FindElement(@by);
		}

		public ValidatedDateField(IBlock parent, IWebElement element) : base(parent, element.FindElement(By.TagName("input")))
		{
			_container = element;
		}

		public bool IsValid => string.IsNullOrEmpty(_container.FindElement(By.TagName("span")).Text);
	}
}