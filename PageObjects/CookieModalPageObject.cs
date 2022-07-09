using OpenQA.Selenium;
using TestVR.Drivers;

namespace TestVR.PageObjects
{
  public class CookieModalPageObject : BasePageObject
  {
    public CookieModalPageObject(BrowserDriver browserDriver) : base(browserDriver) { }

    private IWebElement Modal => this._webDriver.FindElement(By.CssSelector("[class*=site-cookies]:nth-child(1)"));
    private IWebElement AcceptAll => Modal.FindElement(By.CssSelector("button[class*=accept]"));

    public void acceptAll()
    {
      GetWaits.waitElemenClickable(AcceptAll);
      AcceptAll.Click();
    }

    public void notPresent()
    {
      GetWaits.waitElementNotPresent(Modal);
    }

    public bool isModalPresent()
    {
      return Modal.Displayed;
    }

  }
}
