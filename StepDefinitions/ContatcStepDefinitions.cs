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
      IWebElement webElement = _contact.getWebElement(element);
      _contact.GetWaits.waitElemenClickable(webElement);
      webElement.Click();
    }

    [When("the (.*) is shown in contact page")]
    [Then("the (.*) is shown in contact page")]
    public void contactPageElementIsShownInPage(string element)
    {
      _contact.getWebElement(element).TagName.Should().NotBeNull();
    }

    [Then("the (.*) has the text (.*) in contact")]
    public void contactPageElementHasText(string element, string text)
    {
      _contact.present();
      _contact.getWebElement(element).FindElement(By.CssSelector("label")).GetAttribute("innerText").Should().Be(text);
    }

    [Then("the contact page is shown")]
    public void contactPageIsShownInPage()
    {
      _contact.present().Should().BeTrue();
    }


  }
}
