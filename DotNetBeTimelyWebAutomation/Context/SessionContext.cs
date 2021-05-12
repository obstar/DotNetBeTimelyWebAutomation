namespace DotNetBeTimelyWebAutomation.Tests.Context
{
    public class SessionContext
    {
        public SessionContext()
        {
            User = new UserInfo();
        }

        public UserInfo User { get; set; }
    }
}