using System;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Contoso.Model.Departments
{
	public class DepartmentRow : Element
	{
		public DepartmentRow(IBlock parent, By @by) : base(parent, @by)
		{
			ExtractProperties();
		}

		public DepartmentRow(IBlock parent, IWebElement tag) : base(parent, tag)
		{
			ExtractProperties();
		}

		public DateTime StartDate { get; private set; }

		public string Name { get; private set; }

		public string Admistrator { get; private set; }

		public decimal Budget { get; private set; }

		public IClickable<DepartmentEditPage> Edit { get; private set; }

		public IClickable<DepartmentDetailsPage> Details { get; private set; }

		public IClickable<DepartmentDeletePage> Delete { get; private set; }

		private void ExtractProperties()
		{
			var columns = FindElements(By.TagName("td"));
			Name = columns[0].Text;
			Budget = decimal.Parse(columns[1].Text);
			StartDate = DateTime.Parse(columns[2].Text);
			Admistrator = columns[3].Text;

			var actions = columns[4].FindElements(By.TagName("a"));
			Edit = new Clickable<DepartmentEditPage>(this, actions[0]);
			Details = new Clickable<DepartmentDetailsPage>(this, actions[1]);
			Delete = new Clickable<DepartmentDeletePage>(this, actions[2]);
		}
	}
}