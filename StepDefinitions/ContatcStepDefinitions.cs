using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using TestVR.Drivers;
using TestVR.PageObjects;

namespace TestVR.Steps
{
  [Binding]
  public sealed class ContatcStepDefinitions
  {
    private readonly ContactPageObject _contact;

    public ContatcStepDefinitions(BrowserDriver browserDriver)
    {
      _contact = new ContactPageObject(browserDriver);
    }

    [Given("the verisk contact page open")]
    public void contactOpenThePage()
    {
      _contact.navigate();
      _contact.present();
    }

    [When("the user clicks on (.*) in contact page")]
    public void contactPageElementIsClicked(string element)
    {
      IWebElement webElement = _contact.getWebElement(element).FindElement(By.CssSelector("select,input"));
      _contact.GetWaits.waitElemenClickable(webElement);
      webElement.Click();
    }

    [When("the user select (.*) from Enquiry Type dropdown in contact page")]
    public void contactPageEnquiryTypeElementIsClicked(string element)
    {
      this.contactPageElementIsClicked("Enquiry Type");
      IWebElement webElement = _contact.getEnquiryTypeWebElement(element);
      _contact.GetWaits.waitElemenClickable(webElement);
      webElement.Click();

    }

    [When("the user edit (.*) with the value (.*) in contact page")]
    public void contactPageEditElement(string element, string value)
    {
      IWebElement webElement = _contact.getWebElement(element).FindElement(By.CssSelector("input,textarea"));
      webElement.SendKeys(value);
    }

    [When("the (.*) is shown in contact page")]
    [Then("the (.*) is shown in contact page")]
    public void contactPageElementIsShownInPage(string element)
    {
      _contact.getWebElement(element).TagName.Should().NotBeNull();
    }

    [When("the '(.*)' are shown in contact page")]
    [Then("the '(.*)' are shown in contact page")]
    public void contactPageElementAreShownInPage(List<string> elements)
    {
      elements.ForEach(element => contactPageElementIsShownInPage(element));
    }

    [Then("the (.*) has the label text (.*) in contact page")]
    public void contactPageElementHasLabelText(string element, string text)
    {
      _contact.present();
      _contact.getWebElement(element).FindElement(By.TagName("label")).GetAttribute("innerText").Should().Be(text);
    }

    [Then("the (.*) has the error text (.*) in contact page")]
    public void contactPageElementHasErrorText(string element, string text)
    {
      _contact.present();
      By by = By.CssSelector("[class=field-validation-error]");
      _contact.getWebElement(element).FindElement(by).GetAttribute("innerText").Should().Be(text);
    }

    [Then("the contact page is shown")]
    public void contactPageIsShownInPage()
    {
      _contact.present().Should().BeTrue();
    }

    [Then("the enquiry type dropdown has the text (.*) in contact page")]
    public void contactPageEnquiryTypeHasElement(string text)
    {
      _contact.present();
      _contact.getEnquiryTypeWebElement(text).GetAttribute("innerText").Should().Be(text);
    }

    [Then("the enquiry type dropdown has the values '(.*)' in contact page")]
    public void contactPageEnquiryTypeHasValues(List<string> values)
    {
      _contact.present();
      values.ForEach(text => contactPageEnquiryTypeHasElement(text));

    }

  }
}
