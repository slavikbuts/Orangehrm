Feature: Scenarios
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Scenario 1
	Given I open "https://orangehrm-demo-6x.orangehrmlive.com/"
	And I login as Admin
	| Username | Password |
	| admin    | admin123 |
	When I add a new user into the system
	| Employee     | Password  |
	| Andrew Daley | qwerty123 |
	Then the new user can log into the system
