Feature: SpecFlowGet

Return primary colors

Scenario: Get primary colors
	Given I am a client
	When I make a Get request to 'SpecFlow'
	Then The response status code is 200
	And The result should be primary colors