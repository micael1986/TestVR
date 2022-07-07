Feature: Verify the contact form fields

  Background: Open contact page
    Given the verisk contact page open


  Scenario Outline: The mandatory field has *
    Then the <element> is shown in contact page
    And  the <element> has the text <text> in contact
    Examples:
      | element       | text                                                                                                                                                                                                                                                        |
      | Name          | Name *                                                                                                                                                                                                                                                      |
      | Company       | Company *                                                                                                                                                                                                                                                   |
      | Job Title     | Job Title *                                                                                                                                                                                                                                                 |
      | Email address | Email address *                                                                                                                                                                                                                                             |
      | Phone number  | Phone number *                                                                                                                                                                                                                                              |
      | Message       | Message *                                                                                                                                                                                                                                                   |
      | Enquiry Type  | Enquiry Type *                                                                                                                                                                                                                                              |
      | Subscribing   | By subscribing to this, you are consenting to Verisk processing your personal information for the purpose of providing updates in relation to products and services that may be of interest. We will store this data until such time as you ask us to stop. |
      | Recaptcha     | Recaptcha *                                                                                                                                                                                                                                                 |
