Feature: Trademe
	

    @ListingUsedCars
Scenario: Check there is at least one listing in the TradeMe UsedCars category.
	Given I login 
	And I am on Trademe Home page
    And I navigate to 'motors page' page
	And I am on motors page
	Then Check there is at least one listing in the TradeMe UsedCars category
	
	@make
Scenario: Check that the make Kia exists
	Given I login 
	And I navigate to 'motors page' page
	And I am on motors page
	And I navigate to 'used cars' page
	And I am on used cars page
    And I click on Cars for sale
	Then  that the make 'Kia' exists
	 
	@Bikes
Scenario:Check any existing Used Bike listing and confirm that the following details are shown for that Bike
	Given I login 
	And I navigate to 'motors page' page
	And I am on motors page
	And I click on motor bikes for sale
	And I click on Tourers
	And I click on Tourers details button
	Then Details are displayed

	@Details
Scenario:Check any existing Used Car listing and confirm that the following details are shown for that car
    Given I login 
	And I navigate to 'motors page' page
	And I am on motors page
	And I click on Cars for sale
	And I click on Nissan
	And I click on Nissan details button
	Then Details are displayed

	
	
    