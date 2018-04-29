using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Courses
{
	public class CourseCreatePage : CreatePage<CoursesPage>
	{
		public CourseCreatePage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form//div"));
			Number = new ValidatedTextField<CoursesPage>(this, inputs[0]);
			Title = new TextField<CoursesPage>(this, inputs[1].FindElement(By.TagName("input")));
			Credits = new ValidatedTextField<CoursesPage>(this, inputs[2]);
			Department = new SelectBox<CoursesPage>(this, inputs[3].FindElement(By.TagName("select")));
		}

		public IValidatedTextField<CoursesPage> Number { get; }

		public ITextField<CoursesPage> Title { get; }

		public IValidatedTextField<CoursesPage> Credits { get; }

		public ISelectBox<CoursesPage> Department { get; }
	}
}