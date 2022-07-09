using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;
using TestVR.Helpers;

namespace TestVR.PageObjects
{
  public abstract class BasePageObject
  {

    public readonly IWebDriver _webDriver;
    public readonly WebDriverWait _webDriverWait;

    public string GetBaseUrl => "https://www.verisksequel.com";

    public Waits GetWaits => new Waits(this._webDriverWait);
    public BasePageObject(BrowserDriver browserDriver)
    {
      _webDriver = browserDriver.Current;
      _webDriverWait = browserDriver.CurrentWait;
    }

    public IWebElement getWebElement(string element)
    {
      string elementName = "";
      foreach (string s in element.Split(" "))
      {
        elementName = String.Concat(elementName, TextHelper.FirstCharToUpper(s));
      }
      string methodName = $"get_{elementName}";
      var webElement = this.GetType().GetMethod(methodName)?.Invoke(this, null) as IWebElement
      ?? throw new NotSupportedException($"Element not found {methodName}");
      return webElement;
    }
  }
}
