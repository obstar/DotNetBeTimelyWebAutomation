namespace DotNetBeTimelyWebAutomation.Tests.Config
{
   public class EndPoints
    {
        public static EndPoints Production = new EndPoints
        {
            ServerHost = "giphy.com",
            ServerScheme = "https",
        };

        public string ServerHost { get; private set; }
        public string ServerScheme { get; private set; }
    }
}
