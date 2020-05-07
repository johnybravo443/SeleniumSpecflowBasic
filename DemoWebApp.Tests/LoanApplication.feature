Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background: 
	Given I am on the loan application screen

@one
Scenario: Application completed successfully
		And I enter a first name of Sarah
		And I enter a second name of Smith
		And I select that I have a loan account
		And I confirm my acceptance of the terms and conditions
	When I sbumit the application
	Then I should see the application complete confirmation for Sarah

@dt
Scenario: DT Application completed successfully
	#Given I am on the loan application screen
		And I enter a customer name
		| attribute | value |
		| FirstName | Sarah |
		| LastName  | Smith |
		And I select that I have a Savings account
		And I confirm my acceptance of the terms and conditions
	When I sbumit the application
	Then I should see the application complete confirmation for Sarah

@so
Scenario Outline: SO Application completed successfully
	#Given I am on the loan application screen
		And I enter a first name of <FirstName>
		And I enter a second name of <LastName>
		And I select that I have a loan account
		And I confirm my acceptance of the terms and conditions
	When I sbumit the application
	Then I should see the application complete confirmation for <FirstName>
	Examples: 
		| FirstName | LastName |
		| Sarah     | Smith    |
		| James     | Bond     |

@tnc
Scenario: Cannot submit application unless terms and conditions accepted
	#Given I am on the loan application screen
		And I enter a first name of Gentry
		And I enter a second name of Jones
		And I select that I have a loan account
	When I sbumit the application
	Then I should see an error message telling me I must accept the terms and conditions

@others
Scenario: Magical Powers
	Given I have magical powers
	| name      | value | power |
	| spear     | 55    | 80    |
	| death ray | 99    | 100   |
		And I visisted bank 3 days ago 

@others @ignore
Scenario: Weapons are worth money
	Given I have the following weapons 
	| name  | value |
	| Sword | 50    |
	| Pick  | 40    |
	| Knife | 10    |
