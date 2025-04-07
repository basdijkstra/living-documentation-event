Feature: LoanApplicationExample02Before
Because I want to be able to login to ParaBank both through the UI and the API

Scenario: Logging in through the UI is possible
  Given a user with username john and password demo
  When they perform a login on the ParaBank frontend
  Then the frontend login should be successful


































#Scenario: Logging in through the API is possible
#  Given a user with username john and password demo
#  When they perform a login on the ParaBank API
#  Then the API login should be successful
