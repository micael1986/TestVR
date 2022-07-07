using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using TestVR.Drivers;
using TestVR.PageObjects;
using TestVR.Helpers;


namespace TestVR.Steps
{
  [Binding]
  public sealed class HomeStepDefinitions
  {
    private readonly HomePageObject _home;

    public HomeStepDefinitions(BrowserDriver browserDriver)
    {
      _home = new HomePageObject(browserDriver);
    }

    [Given("the verisk home page open")]
    public void homePageOpenThePage()
    {
      _home.navigate();
      _home.present();
    }
  }
}
