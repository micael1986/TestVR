using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using TestVR.Drivers;
using TestVR.PageObjects;


namespace TestVR.Steps
{
  [Binding]
  public sealed class HomeStepDefinitions
  {
    //Page Object for Calculator
    private readonly HomePage _homePage;

    public HomeStepDefinitions(BrowserDriver browserDriver)
    {
      _homePage = new HomePage(browserDriver);
    }

    [Given("the verisk homepage")]
    public void openThePage()
    {
      //delegate to Page Object
      _homePage.navigate();
    }

    [Then("the logo is shown")]
    public void ThenTheResultShouldBe()
    {
      Console.WriteLine(_homePage.Logo.FindElement(By.TagName("path")).GetAttribute("d"));
      _homePage.Logo.TagName.Should().NotBeNull();
    }
  }
}
