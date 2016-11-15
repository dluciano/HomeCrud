Feature: Home Features
	In order to manage home data
	As a anonymous
	I want to be able to create, read, update and delete homes

Scenario: Create Home
	When I create a home with the following data
		| Field   | Value        |
		| Name    | Peña's Home  |
		| Address | Test Address |
	Then should exists a home with data
		| Field   | Value        |
		| Name    | Peña's Home  |
		| Address | Test Address |

Scenario: View Home Details
	Given I create a home with the following data
		| Field   | Value          |
		| Name    | Fransic's Home |
		| Address | Test Address   |
	And I create a home with the following data
		| Field   | Value          |
		| Name    | Trumps's Home  |
		| Address | Test Address 2 |
	When I list the last 2 created homes
	Then the following homes should exists
		| Name           | Address        |
		| Fransic's Home | Test Address   |
		| Trumps's Home  | Test Address 2 |

Scenario: Update Home
	Given I create a home with the following data
		| Field   | Value          |
		| Name    | Fransic's Home |
		| Address | Test Address   |
	And I update the last home created with the following data
		| Field   | Value          |
		| Name    | Hillary's Home |
		| Address | Test Address 3 |
	When I list the last 1 created homes
	Then the following homes should exists
		| Name           | Address        |
		| Hillary's Home | Test Address 3 |