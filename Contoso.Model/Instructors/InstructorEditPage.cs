using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Instructors
{
	public class InstructorEditPage : EditPage<InstructorsPage>
	{
		public InstructorEditPage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form//div"));
			LastName = new ValidatedTextField<InstructorEditPage>(this, inputs[0]);
			FirstName = new ValidatedTextField<InstructorEditPage>(this, inputs[1]);
			HireDate = new ValidatedDateField<InstructorEditPage>(this, inputs[2]);
			Office = new TextField<InstructorCreatePage>(this, inputs[3].FindElement(By.TagName("input")));
		}

		public IValidatedTextField<InstructorEditPage> LastName { get; }

		public IValidatedTextField<InstructorEditPage> FirstName { get; }

		public IValidatedDateField<InstructorEditPage> HireDate { get; }

		public ITextField<InstructorCreatePage> Office { get; }
	}
}