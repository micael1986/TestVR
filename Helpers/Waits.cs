using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestVR.Helpers
{
  public class Waits
  {
    private readonly WebDriverWait _webDriverWait;

    public Waits(WebDriverWait webDriverWait)
    {
      _webDriverWait = webDriverWait;
    }
    public void waitElemenClickable(IWebElement element)
    {
      _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    public void waitElementNotPresent(IWebElement element)
    {
      _webDriverWait.Until(d => !element.Displayed);
    }
  }
}
