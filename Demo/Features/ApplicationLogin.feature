Feature: ApplicationLogin

Scenario Outline: Login
	Given Navigte to URL "www.google.com"
	When Input the credentials <UserName> and <Password>
	And Click on "Login"
	Then Verify user get correct result

@source:testData.xlsx
Examples:
	|UserName|Password|