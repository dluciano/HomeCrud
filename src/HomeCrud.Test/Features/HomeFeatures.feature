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

Scenario: List Homes
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

Scenario: View Home Details
	Given I create a home with the following data
		| Field   | Value          |
		| Name    | Fransic's Home |
		| Address | Test Address   |
	And I add a person with the following data to that home
		| Field          | Value        |
		| FirstName      | Dawlin       |
		| LastName       | Peña Luciano |
		| Gender         | Male         |
		| Identification | 00128739231  |
	And I add a person with the following data to that home
		| Field          | Value       |
		| FirstName      | Sister      |
		| LastName       | Peña        |
		| Gender         | Female      |
		| Identification | 00128739233 |
	When I access the details of the last created home
	Then the following home should exists
		| Field   | Value          |
		| Name    | Fransic's Home |
		| Address | Test Address   |
	And the person count should be 2
	And the following person data should be displayed
		| FullName            | Gender | 
		| Dawlin Peña Luciano | Male   | 
		| Sister Peña         | Female | 
	
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

Scenario: Delete Home
	Given I create a home with the following data
		| Field   | Value            |
		| Name    | NotDelete's Home |
		| Address | Test Address     |
	And I create a home with the following data
		| Field   | Value        |
		| Name    | Trump's Home |
		| Address | Test Address |
	And I add a person with the following data to that home
		| Field          | Value       |
		| FirstName      | Sister      |
		| LastName       | Peña        |
		| Gender         | Female      |
		| Identification | 00128739233 |
	And I add a person with the following data to that home
		| Field          | Value       |
		| FirstName      | Test        |
		| LastName       | Peña        |
		| Gender         | Female      |
		| Identification | 00138739233 |
	When I delete the last home
	Then should exists a home with data
		| Field   | Value            |
		| Name    | NotDelete's Home |
		| Address | Test Address     |
	And the count of homes should be 1
	And shouldn't exists people