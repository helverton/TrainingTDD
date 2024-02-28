Feature: Product Management

Scenario: Saving a new product
	Given I enter "Product 1" name and "Product test BDD" description to new product
	When I save the product
	Then product should be saved in the database
	And product should be saved with quantity 0
	And product should be saved with Active status

Scenario: Updating product name
	Given a product with name "Widget" and quantity 100
	When I update the product name to "Super Widget"
	Then the product name should be "Super Widget"

Scenario: Updating product quantity
	Given a product with name "Gizmo" and quantity 50
	When I update the product quantity to 75
	Then the product quantity should be 75

Scenario: Deleting a product with zero quantity
	Given a product with name "Obsolete Item" and quantity 0
	When I attempt to delete the product
	Then the product should be successfully deleted

Scenario: Deleting a product with non-zero quantity
	Given a product with name "High-Value Item" and quantity 500
	When I attempt to delete the product
	Then the deletion should be rejected due to non-zero quantity