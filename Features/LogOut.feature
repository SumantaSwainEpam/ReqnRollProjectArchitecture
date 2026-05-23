Feature: Logout functionality for SauceDemo application

  Background:
    Given user launches SauceDemo application
    When user enters username "standard_user"
    And user enters password "secret_sauce"
    And user clicks on login button
    Then user should see "success"

  Scenario Outline: Logout validation with different user sessions

    When user clicks on menu button
    And user clicks on logout button
    Then user should navigate to login page with "<expectedResult>"

    Examples:
      | expectedResult |
      | success        |