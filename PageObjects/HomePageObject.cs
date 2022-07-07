using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;
using TestVR.Helpers;

namespace TestVR.PageObjects
{
  public class HomePageObject
  {
    private const string baseUrl = "https://www.verisksequel.com";

    private readonly IWebDriver _webDriver;

    private readonly WebDriverWait _webDriverWait;

    public HomePageObject(BrowserDriver browserDriver)
    {
      _webDriver = browserDriver.Current;
      _webDriverWait = browserDriver.CurrentWait;
    }

    //Finding elements by ID
    private IWebElement Logo => _webDriver.FindElement(By.CssSelector("[class*=header-logo]"));

    public void navigate()
    {
      _webDriver.Navigate().GoToUrl(baseUrl);
    }

    public void present()
    {
      _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(Logo));
    }

    public Waits GetWaits()
    {
      return new Waits(_webDriverWait);
    }

  }
}
