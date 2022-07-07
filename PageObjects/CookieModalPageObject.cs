using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;
using TestVR.Helpers;

namespace TestVR.PageObjects
{
  public class CookieModalPageObject
  {

    private readonly IWebDriver _webDriver;

    private readonly WebDriverWait _webDriverWait;

    public const int DefaultWaitInSeconds = 5;

    public CookieModalPageObject(BrowserDriver browserDriver)
    {
      _webDriver = browserDriver.Current;
      _webDriverWait = browserDriver.CurrentWait;
    }

    //Finding elements by ID
    private IWebElement Modal => _webDriver.FindElement(By.CssSelector("[class*=site-cookies]:nth-child(1)"));
    private IWebElement AcceptAll => Modal.FindElement(By.CssSelector("button[class*=accept]"));

    public Waits GetWaits => new Waits(_webDriverWait);



    public void acceptAll()
    {
      GetWaits.waitElemenClickable(AcceptAll);
      AcceptAll.Click();
    }

    public void notPresent()
    {
      GetWaits.waitElementNotPresent(Modal);
    }

  }
}
