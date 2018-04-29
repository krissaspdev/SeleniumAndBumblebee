using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Contoso.Model
{
    /// <summary>
    /// Base object for each page's functional block representation.
    /// </summary>
    public class BaseBlock : Block
    {
        public BaseBlock(Session session) : base(session)
        {
            Tag = Session.Driver.FindElement(By.TagName("body"));
        }
    }
}
