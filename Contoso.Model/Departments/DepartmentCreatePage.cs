using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Departments
{
	public class DepartmentCreatePage : BaseBlock
	{
		public DepartmentCreatePage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form//div"));
			Name = new TextField<DepartmentCreatePage>(this, inputs[0].FindElement(By.TagName("input")));
			Budget = new ValidatedTextField<DepartmentCreatePage>(this, inputs[1]);
			StartDate = new ValidatedDateField<DepartmentCreatePage>(this, inputs[2]);
			Instructor = new SelectBox<DepartmentCreatePage>(this, inputs[3].FindElement(By.TagName("select")));
		}

		public ITextField<DepartmentCreatePage> Name { get; }

		public IValidatedTextField<DepartmentCreatePage> Budget { get; }

		public IValidatedDateField<DepartmentCreatePage> StartDate { get; }

		public ISelectBox<DepartmentCreatePage> Instructor { get; }
	}
}