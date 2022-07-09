using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;
namespace TestVR.PageObjects
{
  public class HomePageObject : BasePageObject
  {
    public HomePageObject(BrowserDriver browserDriver) : base(browserDriver) { }

    private IWebElement Video => this._webDriver.FindElement(By.CssSelector("[class*='banner is-video']"));

    public void navigate()
    {
      _webDriver.Navigate().GoToUrl(this.GetBaseUrl);
    }

    public void present()
    {
      _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(Video));
    }

  }
}
