Feature: LoanApplicationExample01After
That looks much better! And the code is easier to maintain and extend, too!

Scenario: A loan application within regulatory boundaries should be approved - after
  Given a registered bank user
  | Name | Valid line of credit |
  | John | true                 |
  And they have a bank account
  | ID    | Type     | Balance |
  | 12345 | checking | 1500    |
  When they submit a loan application
  | Applicant | Amount | Down payment | From account ID |
  | John      | 1000   | 100          | 12345           |
  Then the loan application is approved
