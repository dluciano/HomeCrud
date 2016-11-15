Feature: Person Features
	In order to manage which person lives in a home
	As a anonymous
	I want to be able to create, read, update and delete persons that lives in a home

	Background: 
	Given I create one home with the following data
		| Field   | Value        |
		| Name    | Peña's Home  |
		| Address | Test Address |

Scenario: Add person to home
	When I add a person to the last added home, with the following data
		| Field     | Value        |
		| FirstName | Dawlin       |
		| LastName  | Peña Luciano |
		| Gender    | Male         |
		| Id        | 00128739281  |
	Then the last person created should contain the following data
		| Field     | Value        |
		| FirstName | Dawlin       |
		| LastName  | Peña Luciano |
		| Gender    | Male         |
		| Id        | 00128739281  |
	And the last home created should contain a person with id '00128739281'