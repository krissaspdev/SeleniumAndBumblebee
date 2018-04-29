using System.Linq;
using System.Reflection;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Students
{
	public class StudentsPage : BaseBlock
	{
		public StudentsPage(Session session) : base(session)
		{
			Students = new Table<StudentRow>(this, By.TagName("table"));
			Create = new Clickable<StudentCreatePage>(this, FindElements(By.XPath("div//a")).First());
			Search = new SearchBox(Session, FindElement(By.TagName("form")));
		}

		public ITable<StudentRow> Students { get; }

		public IClickable<StudentCreatePage> Create { get; }

		public SearchBox Search { get; }
	}
}