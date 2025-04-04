Feature: LoanApplicationExample01Before
What do you think of this feature? Any problems?

Scenario: A loan application within regulatory boundaries should be approved - before
  Given John is a registered bank user
  And their line of credit is valid
  And they have a checking account with ID 12345
  And their account 12345 has a balance of 1500
  When they seek a 1000 dollar loan
  And the monthly down payment is 100
  And the monthly down payment is deducted from account 12345
  And the loan application is submitted
  Then the loan application is approved
