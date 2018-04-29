using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Courses
{
	public class CourseDeletePage : DeletePage<CoursesPage>
	{
		public CourseDeletePage(Session session) : base(session)
		{
			var values = FindElements(By.TagName("dd"));
			Number = int.Parse(values[0].Text);
			Title = values[1].Text;
			Credits = int.Parse(values[2].Text);
			Department = values[3].Text;
		}

		public int Number { get; }

		public string Title { get; }

		public int Credits { get; }

		public string Department { get; }
	}
}