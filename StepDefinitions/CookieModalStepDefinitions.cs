using TechTalk.SpecFlow;
using TestVR.Drivers;
using TestVR.PageObjects;

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

    [When("the user accept all in cookie modal if exist")]
    public void cookieModalAcceptAllIfExist()
    {
      if (_cookieModal.isModalPresent()) _cookieModal.acceptAll();
      _cookieModal.notPresent();
    }

  }
}
