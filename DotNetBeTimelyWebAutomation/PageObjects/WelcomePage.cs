namespace DotNetBeTimelyWebAutomation.Tests.PageObjects
{
    public class WelcomePage
    {
        public static string ButtonCssNext { get; } = "[data-testid=\"next_button_stepjs\"]"; 
        public static string ButtonTextJustMe { get; } = "Just me";
        public static string ButtonText2To19People { get; } = "2–19 people";
        public static string ButtonText20PeopleOrMore { get; } = "20 people or more";
        public static string InputCssSearch { get; } = "[data-testid=\"input_field\"]";
        public static string Title { get; } = "Welcome to Timely! – Timely";
    }
}