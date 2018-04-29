using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Contoso.Model.Common
{
	public class DeletePage<TSource> : BaseBlock where TSource : IBlock
	{
		public DeletePage(Session session) : base(session)
		{
			Delete = new Clickable<TSource>(this, By.XPath(".//form//input[@type='submit']"));
			BackToList = new Clickable<TSource>(this, By.XPath(".//form//a"));
		}

		public IClickable<TSource> Delete { get; }

		public IClickable<TSource> BackToList { get; }
	}
}