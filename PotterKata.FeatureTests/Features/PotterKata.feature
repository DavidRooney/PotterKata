Feature: PotterKata
	In order to be a wizard
	As a developer
	I must do TDD

Background:
	Given There are harry potter books in the store

Scenario: One copy is 8 euros
	When I buy '1' book
	Then the basket will cost 8 euros

Scenario: Two copies of the same book will cost 16 euros
	When I buy '2' of the '1st' book
	Then the basket will cost 16 euros

Scenario: Three copies of the same book will cost 16 euros
	When I buy '3' of the '1st' book
	Then the basket will cost 24 euros

Scenario: Two different books gets 5% discount on total price
	When I buy '2' different books
	Then the basket will receive a 5% discount

Scenario: Three different books gets 10% discount on total price
	When I buy '10' different books
	Then the basket will receive a 10% discount