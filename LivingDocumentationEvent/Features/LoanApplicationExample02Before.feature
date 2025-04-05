Feature: LoanApplicationExample02Before
Because I want to be able to log in to ParaBank both through the UI and the API

Scenario: Login succeeds through the API with valid credentials
  Given a user with username john and password demo
  When they perform a login on the ParaBank API
  Then the login should be successful

Scenario: Login succeeds through the frontend with valid credentials
  Given a frontend user with username john and password demo
  When they perform a login on the ParaBank frontend
  Then the frontend login should be successful
