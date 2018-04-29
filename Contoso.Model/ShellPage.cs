using Bumblebee.Setup;

namespace Contoso.Model
{
    /// <summary>
    /// Represents main shell which hosts other parts of application. Shell contains main menu and global actions.
    /// </summary>
    public class ShellPage : BaseBlock
    {
        private NavigationBox _navigation;

        public ShellPage(Session session) : base(session)
        {
            _navigation = new NavigationBox(session);
        }

        /// <summary>
        /// Gets application's navigation menu.
        /// </summary>
        public NavigationBox Navigation => _navigation;
    }
}
