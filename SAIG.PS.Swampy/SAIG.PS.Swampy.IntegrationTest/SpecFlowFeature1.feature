Feature: Addition
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

	
Scenario: Retrieve config value
	Given I have provided "SIT1" into the environment service 
	And I have entered "CommonDBConnectionString" key into the environment service
	When I call the service
	Then the result should be "data source= AUSYDHC-PSQSQ07.saigprod.local ;initial catalog=Common;User ID= eonapp ;Password= 330n@pp10ck ;persist security info=False;packet size=4096"
	

Scenario: Add a new endpoint
	Given I have added a new endpoint
	When I call the service for sit1
	Then The key should be there for all environments


