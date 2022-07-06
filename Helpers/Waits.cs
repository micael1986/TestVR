using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;

namespace TestVR.Helpers
{
  public class Waits
  {
    private readonly IWebDriver _webDriver;
    private readonly WebDriverWait _webDriverWait;

    public Waits(BrowserDriver browserDriver)
    {
      _webDriver = browserDriver.Current;
      _webDriverWait = browserDriver.CurrentWait;
    }
    public void waitElementVisible(IWebElement element)
    {
      _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
    }
  }
}
