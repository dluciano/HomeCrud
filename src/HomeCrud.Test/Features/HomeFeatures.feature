Feature: Home Features
	In order to manage home data
	As a anonymous
	I want to be able to create, read, update and delete homes

Scenario: Create Home
	When I create a home with the following data
		| Field   | Value         |
		| Name    | Los peña Home |
		| Address | Test Address  |
	Then should exists a home with data
		| Field   | Value         |
		| Name    | Los peña Home |
		| Address | Test Address  |
