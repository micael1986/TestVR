Feature: Verify the toolbar in homepage when the browser is greater or equal than 1024

  Background: Open homepage
    Given the verisk home page open

  Scenario: The logo is shown in the toolbar
    Then the logo is shown in navigation bar

  Scenario: The nav options are shown in the homepage
    When the 'Products,News,Company,Careers,Contact' are shown in navigation bar
    Then the Products has the text Products in navigation bar
    And  the News has the text News in navigation bar
    And  the Company has the text Company in navigation bar
    And  the Careers has the text Careers in navigation bar
    And  the Contact has the text Contact in navigation bar

  Scenario: The user can navigate to the contact page from homepage
    When the Contact is shown in navigation bar
    And the user accept all in cookie modal if exist
    And the user clicks on Contact in navigation bar
    Then the contact page is shown
