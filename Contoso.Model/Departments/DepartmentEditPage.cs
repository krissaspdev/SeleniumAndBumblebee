using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Departments
{
	public class DepartmentEditPage : EditPage<DepartmentsPage>
	{
		public DepartmentEditPage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form//div"));
			Name = new TextField<DepartmentEditPage>(this, inputs[0].FindElement(By.TagName("input")));
			Budget = new ValidatedTextField<DepartmentEditPage>(this, inputs[1]);
			StartDate = new ValidatedDateField<DepartmentEditPage>(this, inputs[2]);
			Instructor = new SelectBox<DepartmentEditPage>(this, inputs[3].FindElement(By.TagName("select")));
		}

		public ITextField<DepartmentEditPage> Name { get; }

		public IValidatedTextField<DepartmentEditPage> Budget { get; }

		public IValidatedDateField<DepartmentEditPage> StartDate { get; }

		public ISelectBox<DepartmentEditPage> Instructor { get; }
	}
}