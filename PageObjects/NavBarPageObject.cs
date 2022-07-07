using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;
using TestVR.Helpers;

namespace TestVR.PageObjects
{
  public class NavBarPageObject
  {

    private readonly IWebDriver _webDriver;

    private readonly WebDriverWait _webDriverWait;

    public NavBarPageObject(BrowserDriver browserDriver)
    {
      _webDriver = browserDriver.Current;
      _webDriverWait = browserDriver.CurrentWait;
    }

    //Finding elements by ID
    private IWebElement Logo => _webDriver.FindElement(By.CssSelector("[class*=header-logo]"));
    private IWebElement Products => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/products/']"));
    private IWebElement News => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/news/']"));
    private IWebElement Company => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/company/']"));
    private IWebElement Careers => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/careers/']"));
    private IWebElement Contact => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/contact/']"));

    public void present()
    {
      _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(Logo));
    }

    public IWebElement GetWebElement(string element)
    {
      string lower = element.ToLower();
      switch (lower)
      {
        case "logo": return Logo;
        case "products": return Products;
        case "news": return News;
        case "company": return Company;
        case "careers": return Careers;
        case "contact": return Contact;
        default: throw new NotSupportedException("Element not found");
      }
    }

    public Waits GetWaits()
    {
      return new Waits(_webDriverWait);
    }

  }
}
