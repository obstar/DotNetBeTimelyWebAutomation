namespace DotNetBeTimelyWebAutomation.Tests.PageObjects
{
    public class LoginPage
    {
        public static string ButtonIdNext { get; } = "next-inputs";
        public static string ButtonTextSignInWithApple { get; } = "Sign in with Google";
        public static string ButtonTextSignInWithGoogle { get; } = "Sign in with Apple";
        public static string InputIdEmail { get; } = "email";
        public static string LinkCssSignUp { get; } = "[data-testid=\"signup_link\"]";
        public static string LinkTextIForgotMyPassword { get; } = "I forgot my password";
        public static string LinkTextReadMore { get; } = "Read more";
        public static string Title { get; } = "Log in to Timely - Memory";
        public static string Url { get; } = "https://auth.testmemory.ai/login";
    }
}