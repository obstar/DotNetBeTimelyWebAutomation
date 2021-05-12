namespace DotNetBeTimelyWebAutomation.Tests.PageObjects
{
    public class SignUpPage
    {
        public static string ButtonCssStartFreeDayTrial { get; } = "div.create-account";
        public static string ButtonTextSignUpWithApple { get; } = "Sign up with Google";
        public static string ButtonTextSignUpWithGoogle { get; } = "Sign up with Apple";
        public static string InputIdFullName { get; } = "name";
        public static string InputIdPassword { get; } = "password";
        public static string InputIdWorkEmail { get; } = "email";
        public static string LinkTextLogIn { get; } = "Log In";
        public static string LinkTextTermsOfService { get; } = "Terms of Service.";
        public static string Title { get; } = "Register your Timely account - Timely";
        public static string Url { get; } = "https://app.betimely.com/join";
    }
}