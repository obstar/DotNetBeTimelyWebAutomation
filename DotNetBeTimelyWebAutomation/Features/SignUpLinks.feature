Feature: SignUpLinks


Background:
	Given I go to staging timely Sign up page

Scenario: SignUpLinks - User can click Log In link
	When I click Log In link on Sign Up page
	Then user can see Login page

Scenario: SignUpLinks - User can click Terms of Service link
	When I click Terms of Service link on Sign Up page
	Then user can see Terms Of Service page