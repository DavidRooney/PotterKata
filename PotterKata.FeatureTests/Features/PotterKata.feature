Feature: PotterKata
	In order to be a wizard
	As a developer
	I must do TDD

Background:
	Given There are harry potter books in the store

Scenario: one copy is 8 euros
	When I buy 1 book
	Then the basket will cost 8 euros

Scenario: Two books gets 5% discount on total price
	When I buy 2 books
	Then the basket will receive a 5% discount