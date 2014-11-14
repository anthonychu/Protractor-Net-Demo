Feature: Simple Math
	In order to solve simple math problems
	As a user
	I want to perform simple arithmetic on two numbers


Scenario Outline: Add two numbers
	Given I have a new calculator
	When I add <first> and <second>
	Then the latest result should be <expectedResult>

	Examples: 
	| first | second | expectedResult |
	| 2     | 3      | 5              |
	| -1    | 1      | 0              |


Scenario Outline: Divide two numbers
	Given I have a new calculator
	When I divide <first> by <second>
	Then the latest result should be <expectedResult>

	Examples: 
	| first | second | expectedResult |
	| 2     | 2      | 1              |
	| 1     | 0      | Infinity       |
