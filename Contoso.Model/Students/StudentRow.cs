using System;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Contoso.Model.Students
{
	public class StudentRow : Element
	{
		public StudentRow(IBlock parent, By @by) : base(parent, @by)
		{
			ExtractProperties();
		}

		public StudentRow(IBlock parent, IWebElement tag) : base(parent, tag)
		{
			ExtractProperties();
		}

		public DateTime EnrollmentDate { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public IClickable<StudentEditPage> Edit { get; private set; }

		public IClickable<StudentDetailsPage> Details { get; private set; }

		public IClickable<StudentDeletePage> Delete { get; private set; }

		private void ExtractProperties()
		{
			var columns = FindElements(By.TagName("td"));
			LastName = columns[0].Text;
			FirstName = columns[1].Text;
			EnrollmentDate = DateTime.Parse(columns[2].Text);

			var actions = columns[3].FindElements(By.TagName("a"));
			Edit = new Clickable<StudentEditPage>(this, actions[0]);
			Details = new Clickable<StudentDetailsPage>(this, actions[1]);
			Delete = new Clickable<StudentDeletePage>(this, actions[2]);
		}
	}
}