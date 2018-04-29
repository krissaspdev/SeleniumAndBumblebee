using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Contoso.Model.Students
{
	public class SearchBox : SpecificBlock
	{
		public SearchBox(Session session, IWebElement tag) : base(session, tag)
		{
		}

		public ITextField<SearchBox> Name => new TextField<SearchBox>(this, FindElements(By.TagName("input")).First());

		public IClickable<StudentsPage> Search => new Clickable<StudentsPage>(this, FindElements(By.TagName("input")).Last());

		public IClickable<StudentsPage> BackToFullList => new Clickable<StudentsPage>(this, By.TagName("a"));

	}
}