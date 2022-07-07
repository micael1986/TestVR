using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;
using TestVR.Helpers;

namespace TestVR.PageObjects
{
  public class ContactPageObject
  {
    private const string baseUrl = "https://www.verisksequel.com";

    private readonly IWebDriver _webDriver;

    private readonly WebDriverWait _webDriverWait;

    public const int DefaultWaitInSeconds = 5;

    public ContactPageObject(BrowserDriver browserDriver)
    {
      _webDriver = browserDriver.Current;
      _webDriverWait = browserDriver.CurrentWait;
    }

    //Finding elements by ID
    private IWebElement ContactUs => _webDriver.FindElement(By.XPath("//h2[contains(text(),'Contact us')]"));

    public Waits GetWaits => new Waits(_webDriverWait);

    public void navigate()
    {
      _webDriver.Navigate().GoToUrl(baseUrl + "/contact/");
    }

    public bool present()
    {
      return _webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(ContactUs, "Contact us"));
    }

    public IWebElement getWebElement(string element)
    {
      string lower = element.ToLower();
      switch (lower)
      {
        case "contactUs": return ContactUs;
        default: throw new NotSupportedException("Element not found");
      }
    }

  }
}
