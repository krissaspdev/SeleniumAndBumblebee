using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Students
{
	public class StudentCreatePage : CreatePage<StudentsPage>
	{
		public StudentCreatePage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form//div"));
			LastName = new ValidatedTextField<StudentCreatePage>(this, inputs[0]);
			FirstName = new ValidatedTextField<StudentCreatePage>(this, inputs[1]);
			EnrollmentDate = new ValidatedDateField<StudentCreatePage>(this, inputs[2]);
		}

		public IValidatedTextField<StudentCreatePage> LastName { get; }

		public IValidatedTextField<StudentCreatePage> FirstName { get; }

		public IValidatedDateField<StudentCreatePage> EnrollmentDate { get; }
	}
}