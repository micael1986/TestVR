using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using TestVR.Drivers;
using TestVR.PageObjects;


namespace TestVR.Steps
{
  [Binding]
  public sealed class NavBarStepDefinitions
  {
    private readonly NavBarPageObject _navBar;

    public NavBarStepDefinitions(BrowserDriver browserDriver)
    {
      _navBar = new NavBarPageObject(browserDriver);
    }

    [When("the user clicks on (.*) in navigation bar")]
    public void homepageElementIsClicked(string element)
    {
      IWebElement webElement = _navBar.GetWebElement(element);
      _navBar.GetWaits().waitElemenClickable(webElement);
      webElement.Click();
    }

    [When("the (.*) is shown in navigation bar")]
    [Then("the (.*) is shown in navigation bar")]
    public void homepageElementIsShownInPage(string element)
    {
      _navBar.GetWebElement(element).TagName.Should().NotBeNull();
    }

    [Then("the (.*) has the text (.*) in navigation bar")]
    public void homepageElementHasText(string element, string text)
    {
      _navBar.present();
      _navBar.GetWebElement(element).GetAttribute("innerText").Should().Be(text);
    }

  }
}
