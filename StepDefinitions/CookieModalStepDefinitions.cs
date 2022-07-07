using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using TestVR.Drivers;
using TestVR.PageObjects;
using TestVR.Helpers;


namespace TestVR.Steps
{
  [Binding]
  public sealed class CookieModalStepDefinitions
  {
    private readonly CookieModalPageObject _cookieModal;

    public CookieModalStepDefinitions(BrowserDriver browserDriver)
    {
      _cookieModal = new CookieModalPageObject(browserDriver);
    }

    [When("the user accept all in cookie modal")]
    public void cookieModalAcceptAll()
    {
      _cookieModal.acceptAll();
      _cookieModal.notPresent();
    }

  }
}
