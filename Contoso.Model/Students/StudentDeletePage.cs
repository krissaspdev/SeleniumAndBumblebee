using System;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Students
{
	public class StudentDeletePage : DeletePage<StudentsPage>
	{
		public StudentDeletePage(Session session) : base(session)
		{
			var values = FindElements(By.TagName("dd"));
			LastName = values[0].Text;
			FirstName = values[1].Text;
			EnrollmentDate = DateTime.Parse(values[2].Text);
		}

		public string LastName { get; }

		public string FirstName { get; }

		public DateTime EnrollmentDate { get; }
	}
}