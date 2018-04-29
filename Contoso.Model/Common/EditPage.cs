using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Contoso.Model.Common
{
	public class EditPage<TSource> : BaseBlock where TSource : IBlock
	{
		public EditPage(Session session) : base(session)
		{
			Tag = FindElement(By.ClassName("body-content"));
		}

		public IClickable<TSource> Save => new Clickable<TSource>(this, By.XPath(".//form//input[@type='submit']"));

		public IClickable<TSource> BackToList => new Clickable<TSource>(this, By.TagName("a"));
	}
}