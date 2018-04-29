using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Students
{
	public class StudentEditPage : EditPage<StudentsPage>
	{
		public StudentEditPage(Session session) : base(session)
		{
			var inputs = FindElements(By.XPath("//form//input[@class='form-control']"));
			LastName = new TextField<StudentCreatePage>(this, inputs[0]);
			FirstName = new TextField<StudentCreatePage>(this, inputs[1]);
			EnrollmentDate = new DateField<StudentCreatePage>(this, inputs[2]);
		}
		
		public ITextField<StudentCreatePage> LastName { get; }

		public ITextField<StudentCreatePage> FirstName { get; }

		public IDateField<StudentCreatePage> EnrollmentDate { get; }
	}
}