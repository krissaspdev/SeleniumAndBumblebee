using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Instructors
{
	public class InstructorCreatePage : CreatePage<InstructorsPage>
	{
		public InstructorCreatePage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form//div"));
			LastName = new ValidatedTextField<InstructorCreatePage>(this, inputs[0]);
			FirstName = new ValidatedTextField<InstructorCreatePage>(this, inputs[1]);
			HireDate = new ValidatedDateField<InstructorCreatePage>(this, inputs[2]);
			Office = new TextField<InstructorCreatePage>(this, inputs[3].FindElement(By.TagName("input")));
		}

		public IValidatedTextField<InstructorCreatePage> LastName { get; }

		public IValidatedTextField<InstructorCreatePage> FirstName { get; }

		public IValidatedDateField<InstructorCreatePage> HireDate { get; }

		public ITextField<InstructorCreatePage> Office { get; }

	}
}