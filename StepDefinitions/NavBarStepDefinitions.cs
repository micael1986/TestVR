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
      IWebElement webElement = _navBar.getWebElement(element);
      _navBar.GetWaits.waitElemenClickable(webElement);
      webElement.Click();
    }

    [When("the (.*) is shown in navigation bar")]
    [Then("the (.*) is shown in navigation bar")]
    public void homepageElementIsShownInPage(string element)
    {
      _navBar.getWebElement(element).TagName.Should().NotBeNull();
    }

    [When("the '(.*)' are shown in navigation bar")]
    [Then("the '(.*)' are shown in navigation bar")]
    public void homepageElementsAreShownInPage(List<String> elements)
    {
      elements.ForEach(element => homepageElementIsShownInPage(element));
    }


    [Then("the (.*) has the text (.*) in navigation bar")]
    public void homepageElementHasText(string element, string text)
    {
      _navBar.present();
      _navBar.getWebElement(element).GetAttribute("innerText").Should().Be(text);
    }

  }
}
