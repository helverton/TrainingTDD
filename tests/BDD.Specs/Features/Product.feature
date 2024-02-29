Feature: Product
Simple save new product

@save
Scenario: Saving a new product
	Given I enter name 'Product 1' and description 'Product test BDD'
	When I save the product
	Then Product saved in the database
