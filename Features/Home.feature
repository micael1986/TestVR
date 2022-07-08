Feature: Verify the toolbar in homepage when the browser is greater or equal than 1024

  Background: Open homepage
    Given the verisk home page open

  Scenario: The logo is shown in the toolbar
    Then the logo is shown in navigation bar

  Scenario Outline: The nav options are shown in the homepage
    Then the <element> is shown in navigation bar
    And  the <element> has the text <element> in navigation bar
    Examples:
      | element  |
      | Products |
      | News     |
      | Company  |
      | Careers  |
      | Contact  |

  Scenario: The user can navigate to the contact page from homepage
    When the Contact is shown in navigation bar
    And the user accept all in cookie modal if exist
    And the user clicks on Contact in navigation bar
    Then the contact page is shown
