using System;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Departments
{
	public class DepartmentDeletePage : DeletePage<DepartmentsPage>
	{
		public DepartmentDeletePage(Session session) : base(session)
		{
			var values = FindElements(By.TagName("dd"));
			Name = values[0].Text;
			Budget = decimal.Parse(values[1].Text);
			StartDate = DateTime.Parse(values[2].Text);
			Administrator = values[3].Text;
		}

		public string Name { get; }

		public string Administrator { get; }

		public DateTime StartDate { get; }

		public decimal Budget { get; }
	}
}