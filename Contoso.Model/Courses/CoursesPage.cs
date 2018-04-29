using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using Contoso.Model.Students;
using OpenQA.Selenium;

namespace Contoso.Model.Courses
{
	public class CoursesPage : BaseBlock
	{
		public CoursesPage(Session session) : base(session)
		{
		}

		public ITable<CourseRow> Courses => new Table<CourseRow>(this, By.TagName("table"));

		public IClickable<CourseCreatePage> Create =>
			new Clickable<CourseCreatePage>(this, FindElements(By.XPath("div//a")).First());
	}
}