Feature: Product management
    Product management process
	Save
	Update

@save
Scenario: Saving a new product
	Given name 'Product BDD' and description 'Product test BDD' to the new product
	When I save the product
	Then Product should be in the database 
	Then Status should be '1' Active
	Then Quantity should be '0'

@update
Scenario: Update product name
	Given a product to update with name 'Product BDD 2' and description 'Product test BDD'
	When I update the name to 'Product 1 updt'
	Then the product name should be 'Product 1 updt'


@stock_issue
Scenario: Issue stock greater than available quantity
	Given a product to stock issue with name 'Product BDD' and description 'Product test BDD'
	Then I enter negative quantity '-15' and try to save the result should be 'false'


@delete
Scenario: Deleting a product with non-zero quantity
	Given a product to delete with name 'Product BDD 2' and description 'Product test BDD'
	Then I try to delete the product the result should be 'false'