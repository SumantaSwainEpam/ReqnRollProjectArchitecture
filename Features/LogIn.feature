Feature: Login functionality for SauceDemo application

  Background:
    Given user launches SauceDemo application

  Scenario Outline: Login validation with multiple credential combinations

    When user enters username "<username>"
    And user enters password "<password>"
    And user clicks on login button
    Then user should see "<expectedResult>"

    Examples:
      | username        | password     | expectedResult |
      | standard_user   | secret_sauce | success        |
      | locked_out_user | secret_sauce | failure        |
      | problem_user    | secret_sauce | success        |
     