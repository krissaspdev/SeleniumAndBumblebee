using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Contoso.Model.Common;
using OpenQA.Selenium;

namespace Contoso.Model.Instructors
{
	public class InstructorsPage : BaseBlock
	{
		public InstructorsPage(Session session) : base(session)
		{
		}

		public ITable<InstructorRow> Instructors => new Table<InstructorRow>(this, By.TagName("table"));
		
		public IClickable<InstructorCreatePage> Create =>
			new Clickable<InstructorCreatePage>(this, FindElements(By.XPath("div//a")).First());
	}
}