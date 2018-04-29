using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.About;
using Contoso.Model.Courses;
using Contoso.Model.Departments;
using Contoso.Model.Instructors;
using Contoso.Model.Students;
using OpenQA.Selenium;

namespace Contoso.Model
{
    /// <summary>
    /// Represents application Navigation.
    /// </summary>
    public class NavigationBox : BaseBlock
    {
        public NavigationBox(Session session) : base(session)
        {
            Tag = FindElement(By.XPath("//nav//ul"));
        }

        /// <summary>
        /// Gets access to home page.
        /// </summary>
        public IClickable<ShellPage> Home => new Clickable<ShellPage>(this, FindElements(By.XPath("li"))[0]);

        /// <summary>
        /// Gets access to about page.
        /// </summary>
        public IClickable<AboutPage> About => new Clickable<AboutPage>(this, FindElements(By.XPath("li"))[1]);

        /// <summary>
        /// Gets access to students management page.
        /// </summary>
        public IClickable<StudentsPage> Students => new Clickable<StudentsPage>(this, FindElements(By.XPath("li"))[2]);

        /// <summary>
        /// Gets access to courses managements page.
        /// </summary>
        public IClickable<CoursesPage> Courses => new Clickable<CoursesPage>(this, FindElements(By.XPath("li"))[3]);

        /// <summary>
        /// Gets access to intructors managements page.
        /// </summary>
        public IClickable<InstructorsPage> Instructors => new Clickable<InstructorsPage>(this, FindElements(By.XPath("li"))[4]);

        /// <summary>
        /// Gets access to intructors managements page.
        /// </summary>
        public IClickable<DepartmentsPage> Departments => new Clickable<DepartmentsPage>(this, FindElements(By.XPath("li"))[5]);
    }
}