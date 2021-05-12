@Register
Feature: SignUp


Background:
	Given I go to staging timely Sign up page

Scenario: SignUp - User can load Sign Up page
	Then user can see Sign Up page

Scenario: SignUp - User can successfully sign up to Timely with custom details
	When I enter my custom details on Sign Up page
	And I click Start free 14 day trial button on Sign Up page
	Then user can see Welcome page