Feature: Person Features
	In order to manage which person lives in a home
	As a anonymous
	I want to be able to create, read, update and delete persons that lives in a home

	Background: 
		Given I create one home with the following data
			| Field   | Value              |
			| Name    | Person Peña's Home |
			| Address | Test Address       |

Scenario: Add person to home
	When I add a person with the following data to the last added home
		| Field          | Value        |
		| FirstName      | Dawlin       |
		| LastName       | Peña Luciano |
		| Gender         | Male         |
		| Identification | 00128739281  |
	Then the last person created should contain the following data
		| Field          | Value              |
		| FirstName      | Dawlin             |
		| LastName       | Peña Luciano       |
		| Gender         | Male               |
		| Identification | 00128739281        |
		| Home           | Person Peña's Home |
	And the last home created should contain 1 person with id '00128739281'

Scenario: List people
	Given I add a person with the following data to the last added home
		| Field          | Value        |
		| FirstName      | Dawlin       |
		| LastName       | Peña Luciano |
		| Gender         | Male         |
		| Identification | 00128739281  |
	And I add a person with the following data to the last added home
		| Field          | Value       |
		| FirstName      | Pedro       |
		| LastName       | Peña        |
		| Gender         | Male        |
		| Identification | 00138739281 |
	When I list the people
	Then should exists the following people
		| FullName            | Gender | Identification | Home               |
		| Dawlin Peña Luciano | Male   | 00128739281    | Person Peña's Home |
		| Pedro Peña          | Male   | 00138739281    | Person Peña's Home |	

Scenario: Person details
	Given I add a person with the following data to the last added home
		| Field          | Value        |
		| FirstName      | Dawlin       |
		| LastName       | Peña Luciano |
		| Gender         | Male         |
		| Identification | 00128739281  |
	When I access the last person details
	Then the person details should contains the following data
		| Field          | Value              |
		| FirstName      | Dawlin             |
		| LastName       | Peña Luciano       |
		| Gender         | Male               |
		| Identification | 00128739281        |
		| Home           | Person Peña's Home |

Scenario: Update person details
	Given I add a person with the following data to the last added home
		| Field          | Value        |
		| FirstName      | Dawlin       |
		| LastName       | Peña Luciano |
		| Gender         | Male         |
		| Identification | 00128739281  |
	And I update the last person details with the following data
		| Field          | Value           |
		| FirstName      | Nilwad          |
		| LastName       | Luciano Paulino |
		| Gender         | Female          |
		| Identification | 20128739281     |
	When I access the last person details
	Then the person details should contains the following data
		| Field          | Value              |
		| FirstName      | Nilwad             |
		| LastName       | Luciano Paulino    |
		| Gender         | Female             |
		| Identification | 20128739281        |
		| Home           | Person Peña's Home |

Scenario: Delete person
	Given I add a person with the following data to the last added home
		| Field          | Value        |
		| FirstName      | Dawlin       |
		| LastName       | Peña Luciano |
		| Gender         | Male         |
		| Identification | 00128739281  |
	And I add a person with the following data to the last added home
		| Field          | Value       |
		| FirstName      | Berto       |
		| LastName       | Ortics      |
		| Gender         | Female      |
		| Identification | 00128339281 |
	When I delete the last added person
	Then the last home added should contain 1 person
	And the last person data should contain the following data
		| Field          | Value               |
		| FullName       | Dawlin Peña Luciano |
		| Gender         | Male                |
		| Identification | 00128739281         |