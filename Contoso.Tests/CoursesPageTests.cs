using System;
using System.Linq;
using Bumblebee.Setup;
using Contoso.Model;
using Contoso.Model.Courses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contoso.Tests
{
	[TestClass]
	public class CoursesPageTests
    {

        private CoursesPage _pageUnderTest;
        private static Session _session;

        [ClassInitialize]
		public static void OneTimeSetup(TestContext context)
        {
            var session = Threaded<Session>.With(new Tools.Chrome(TimeSpan.FromSeconds(10)));
            session.Driver.Navigate().GoToUrl(Settings.ResetAddress);
            _session = session;
        }

		[TestInitialize]
		public void TestSetup()
		{
            var homePage = _session.NavigateTo<ShellPage>(Settings.HomeAddress);
            _pageUnderTest = homePage.Navigation.Courses.Click();
        }

        [TestMethod]
        public void Add_ValidRequiredData_CourseCreated()
        {
            var counterBeforeAdd = _pageUnderTest.Courses.Rows.Count();

            var createPage = _pageUnderTest.Create.Click();
            createPage.Number.EnterText("1");
            createPage.Title.EnterText("ABC");
            createPage.Credits.EnterText("1");
            createPage.Department.Options.First(x => x.Text == "Economics").Click();
            var newCoursesList = createPage.Create.Click();
            var counterAfterAdd = newCoursesList.Courses.Rows.Count();

            bool isInInList = newCoursesList.Courses.Rows.Any(x => x.Title == "ABC");

            Assert.AreEqual(counterAfterAdd, counterBeforeAdd + 1);
            Assert.IsTrue(isInInList);
        }

        [TestCleanup]
		public void TestCleanup()
		{
		}

		[ClassCleanup]
		public static void OneTimeCleanup()
		{
            _session.End();
        }
	}
}