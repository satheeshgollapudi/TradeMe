Feature: Article_Employer
	In order to manage my articles
	As an employer
	I want to add, edit, and delete my articles

@employer
Scenario: Edit articles
	Given I login as 'employer'
	And I navigate to 'manage article' page
	When I press the edit button on the first article, update the information of this article
	Then the article's information should be my updated information
