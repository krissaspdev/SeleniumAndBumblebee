using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Courses
{
	public class CourseEditPage : EditPage<CoursesPage>
	{
		public CourseEditPage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form/div"));
			Number = inputs[0].FindElement(By.TagName("div")).Text;
			Title = new TextField<CourseEditPage>(this, inputs[1].FindElement(By.TagName("input")));
			Credits = new ValidatedTextField<CourseEditPage>(this, inputs[2]);
			Department = new SelectBox<CourseEditPage>(this, inputs[3].FindElement(By.TagName("select")));
		}
		
		public string Number { get; }

		public ITextField<CourseEditPage> Title { get; }

		public IValidatedTextField<CourseEditPage> Credits { get; }

		public ISelectBox<CourseEditPage> Department { get; }
	}
}