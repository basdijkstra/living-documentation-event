Feature: LoanApplicationExample00
Because I want to be able to log in to ParaBank

Scenario: Login succeeds with valid credentials
  Given a user with username john and password demo
  When they perform a login on the ParaBank API
  Then the login should be successful
