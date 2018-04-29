using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using Contoso.Model.Students;
using OpenQA.Selenium;

namespace Contoso.Model.Departments
{
	public class DepartmentsPage : BaseBlock
	{
		public DepartmentsPage(Session session) : base(session)
		{
		}

		public ITable<DepartmentRow> Departments => new Table<DepartmentRow>(this, By.TagName("table"));

		public IClickable<DepartmentCreatePage> Create =>
			new Clickable<DepartmentCreatePage>(this, FindElements(By.XPath("div//a")).First());
	}
}