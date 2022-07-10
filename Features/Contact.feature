Feature: Verify the contact form fields

  Background: Open contact page
    Given the verisk contact page open


  Scenario: The mandatory field has *
    When the 'Name,Company,Job Title,Email address,Phone number,Message,Enquiry Type,Subscribing,Recaptcha' are shown in contact page
    Then the Name has the label text Name * in contact page
    And the Company has the label text Company * in contact page
    And the Job Title has the label text Job Title * in contact page
    And the Email address has the label text Email address * in contact page
    And the Phone number has the label text Phone number * in contact page
    And the Message has the label text Message * in contact page
    And the Enquiry Type has the label text Enquiry Type * in contact page
    And the Subscribing has the label text By subscribing to this, you are consenting to Verisk processing your personal information for the purpose of providing updates in relation to products and services that may be of interest. We will store this data until such time as you ask us to stop. in contact page
    And the Recaptcha has the label text Recaptcha * in contact page

  Scenario Outline: An error message is shown in the mandatory fields (Less Recaptcha, maybe bug?)
    When the user accept all in cookie modal if exist
    And the <element> is shown in contact page
    And the user clicks on Submit in contact page
    Then the <element> has the error text <text> in contact page
    Examples:
      | element       | text                                     |
      | Name          | Please provide a value for Name          |
      | Company       | Please provide a value for Company       |
      | Job Title     | Please provide a value for Job Title     |
      | Email address | Please provide a value for Email address |
      | Phone number  | Please provide a value for Phone number  |
      | Message       | Please provide a value for Message       |
      | Enquiry Type  | Please provide a value for Enquiry Type  |

  Scenario: An error message is shown in recaptcha
    When the user accept all in cookie modal if exist
    And the user edit Name with the value TestName in contact page
    And the user edit Company with the value TestCompany in contact page
    And the user edit Job Title with the value TestJobTitle in contact page
    And the user edit Email address with the value TestEmail@TestMail.com in contact page
    And the user edit Phone number with the value 123 in contact page
    And the user edit Message with the value TestMessage in contact page
    And the user select Sequel Hub from Enquiry Type dropdown in contact page
    And the user clicks on Submit in contact page
    Then the Recaptcha has the error text Recaptcha failed, please try again. in contact page

  @DataSource:emails.csv
  Scenario: An error message is shown when the mail has a invalid format
    When the user accept all in cookie modal if exist
    And the Email address is shown in contact page
    And the user edit Email address with the value <email> in contact page
    And the user clicks on Name in contact page
    Then the Email address has the error text Please provide a valid email address in contact page
  ## email@domain..com => the error is not shown in this case
  ## email@-domain.com => the error is not shown in this case
  ## email@111.222.333.44444 => the error is not shown in this case
  ## .email@domain.com => the error is not shown in this case
  ## email.@domain.com => the error is not shown in this case
  ## email..email@domain.com => the error is not shown in this case

  Scenario: The Enquiry type dropdown has the value
    When the user accept all in cookie modal if exist
    And the Enquiry Type is shown in contact page
    And the user clicks on Enquiry Type in contact page
    Then the enquiry type dropdown has the values ',Sequel Hub,Sales,Start ups,Recruitment,Events/Marketing' in contact page
