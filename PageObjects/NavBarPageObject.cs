using System.Reflection;
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
    public IWebElement Logo => _webDriver.FindElement(By.CssSelector("[class*=header-logo]"));
    public IWebElement Products => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/products/']"));
    public IWebElement News => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/news/']"));
    public IWebElement Company => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/company/']"));
    public IWebElement Careers => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/careers/']"));
    public IWebElement Contact => _webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/contact/']"));

    public void present()
    {
      _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(Logo));
    }

    public IWebElement GetWebElement(string elementName)
    {
      string methodName = $"get_{TextHelper.FirstCharToUpper(elementName)}";
      var webElement = this.GetType().GetMethod(methodName)?.Invoke(this, null) as IWebElement
      ?? throw new NotSupportedException("Element not found");
      return webElement;
    }
    public Waits GetWaits()
    {
      return new Waits(_webDriverWait);
    }

  }
}
