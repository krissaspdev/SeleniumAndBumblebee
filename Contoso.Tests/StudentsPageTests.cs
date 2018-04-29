using System;
using System.Linq;
using Bumblebee.Setup;
using Contoso.Model;
using Contoso.Model.Students;
using Contoso.Tests.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contoso.Tests
{
	[TestClass]
	public class StudentsPageTests
	{
		private StudentsPage _pageUnderTest;
		private static Session _session;

		[ClassInitialize]
		public static void OnTimeSetup(TestContext context)
		{
			 var session = Threaded<Session>.With(new Tools.Chrome(TimeSpan.FromSeconds(10)));
			session.Driver.Navigate().GoToUrl(Settings.ResetAddress);
			_session = session;
		}

		[TestInitialize]
		public void TestSetup()
		{
			var homePage = _session.NavigateTo<ShellPage>(Settings.HomeAddress);
			_pageUnderTest = homePage.Navigation.Students.Click();
		}

		//[TestMethod]
		//public void Add_ValidRequiredData_Added()
		//{
		//	var createPage = _pageUnderTest.Create.Click();

		//	createPage.LastName.EnterText("Pio");
		//	createPage.FirstName.EnterText("Ter");
		//	createPage.EnrollmentDate.EnterDate(DateTime.Now.Date);
		//	var students = createPage.Create.Click();

		//	var added = students.Students.Rows.FirstOrDefault(row => row.LastName == "Pio");
		//	Assert.IsNotNull(added);
		//}

        [TestMethod]
        public void Edit_FirstOnList_Modified()
        {
            var firstStudent = _pageUnderTest.Students.Rows.First();
            var counterBeforeEdit = _pageUnderTest.Students.Rows.Count();

            var editPage = firstStudent.Edit.Click();

            editPage.FirstName.EnterText("Jan");
            editPage.LastName.EnterText("Kowalski");
            editPage.EnrollmentDate.EnterDate(editPage.EnrollmentDate.Value.Value.AddDays(2));
            var modifiedList = editPage.Save.Click();
            var counterAfterEdit = modifiedList.Students.Rows.Count();

            var newObject =  modifiedList.Students.Rows.FirstOrDefault(x => x.FirstName == "Jan" && x.LastName == "Kowalski");

            Assert.IsNotNull(newObject);
            Assert.AreEqual(counterBeforeEdit, counterAfterEdit);
        }

        [TestMethod]
        public void Delete_LastOnList_Deleted()
        {
            var firstStudent = _pageUnderTest.Students.Rows.Last();
            string firstStudentFirstName = firstStudent.FirstName;
            string firstStudentLastName = firstStudent.LastName;

            var counterBeforeDelete = _pageUnderTest.Students.Rows.Count();
            var deletePage = firstStudent.Delete.Click();

            var modifiedList = deletePage.Delete.Click();

            var counterAfterDelete = modifiedList.Students.Rows.Count();

            var deletedStudent = modifiedList.Students.Rows.FirstOrDefault(x => 
            x.FirstName == firstStudentFirstName
            && x.LastName == firstStudentLastName);

            Assert.AreEqual(counterBeforeDelete, counterAfterDelete + 1);
            Assert.IsNull(deletedStudent);
        }

        [TestMethod]
        public void CreateValidation_Nothing_Show()
        {
            var createForm = _pageUnderTest.Create.Click();
            var invalidForm = createForm.Create.Click<StudentCreatePage>();

            Assert.IsFalse(invalidForm.FirstName.IsValid, "First name validation information is missing");
            Assert.IsFalse(invalidForm.LastName.IsValid, "Last name validation information is missing");
        }

        [ClassCleanup]
		public static void OnTimeCleanup()
		{
			_session.End();
		}
	}
}