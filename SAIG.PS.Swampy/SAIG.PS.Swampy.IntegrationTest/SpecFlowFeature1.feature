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


Scenario: Config Replacement
	Given I have wildcard
	When I create a new environment
	Then All environment data is updated at read time. Note validation must happen when a config replacement value is modified as this will affect all other keys.


Scenario: Changing a replacement token
	Given I have an existing replacement token
	And I have config values that use it
	When I attempt to modify the replacement token
	Then The new replacement value must be validdated.


Scenario: Adding a new Key
	Given I have an existing set of environments
	When I add a new key
	Then The key is added to all environments but not validated

Scenario: Missing Key QuickView
	Given I have already created a number of environment entries
	And Some environments do not have all keys populated
	When I go to the value configuration page
	Then The view will show me in red a list of all the keys that do not match