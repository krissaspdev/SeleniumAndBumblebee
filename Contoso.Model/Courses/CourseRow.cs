using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Contoso.Model.Courses
{
	public class CourseRow : Element
	{
		public CourseRow(IBlock parent, By @by) : base(parent, @by)
		{
			ExtractProperties();
		}

		public CourseRow(IBlock parent, IWebElement tag) : base(parent, tag)
		{
			ExtractProperties();
		}

		public int Number { get; private set; }
		public string Title { get; private set; }
		public int Credits { get; private set; }
		public string Department { get; private set; }
		
		public IClickable<CourseEditPage> Edit { get; private set; }

		public IClickable<CourseDetailsPage> Details { get; private set; }

		public IClickable<CourseDeletePage> Delete { get; private set; }

		private void ExtractProperties()
		{
			var columns = FindElements(By.TagName("td"));
			Number = int.Parse(columns[0].Text);
			Title = columns[1].Text;
			Credits = int.Parse(columns[2].Text);
			Department = columns[3].Text;

			var actions = columns[4].FindElements(By.TagName("a"));
			Edit = new Clickable<CourseEditPage>(this, actions[0]);
			Details = new Clickable<CourseDetailsPage>(this, actions[1]);
			Delete = new Clickable<CourseDeletePage>(this, actions[2]);
		}
	}
}