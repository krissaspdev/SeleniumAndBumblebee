using System;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Contoso.Model.Instructors
{
	public class InstructorRow : Element
	{
		public InstructorRow(IBlock parent, By @by) : base(parent, @by)
		{
			ExtractProperties();
		}

		public InstructorRow(IBlock parent, IWebElement tag) : base(parent, tag)
		{
			ExtractProperties();
		}

		public DateTime HireDate { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public string Office { get; private set; }

		public string Courses { get; private set; }

		public IClickable<TaughtCoursesPage> Select { get; private set; }

		public IClickable<InstructorEditPage> Edit { get; private set; }

		public IClickable<InstructorDetailsPage> Details { get; private set; }

		public IClickable<InstructorDeletePage> Delete { get; private set; }

		private void ExtractProperties()
		{
			var columns = FindElements(By.TagName("td"));
			LastName = columns[0].Text;
			FirstName = columns[1].Text;
			HireDate = DateTime.Parse(columns[2].Text);
			Office = columns[3].Text;
			Courses = columns[3].Text;
			var actions = columns[5].FindElements(By.TagName("a"));
			Select = new Clickable<TaughtCoursesPage>(this, actions[0]);
			Edit = new Clickable<InstructorEditPage>(this, actions[1]);
			Details = new Clickable<InstructorDetailsPage>(this, actions[2]);
			Delete = new Clickable<InstructorDeletePage>(this, actions[3]);
		}
	}
}