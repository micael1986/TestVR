using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;

namespace TestVR.PageObjects
{
  public class NavBarPageObject : BasePageObject
  {

    public NavBarPageObject(BrowserDriver browserDriver) : base(browserDriver) { }

    //Finding elements by ID
    public IWebElement Logo => this._webDriver.FindElement(By.CssSelector("[class*=header-logo]"));
    public IWebElement Products => this._webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/products/']"));
    public IWebElement News => this._webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/news/']"));
    public IWebElement Company => this._webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/company/']"));
    public IWebElement Careers => this._webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/careers/']"));
    public IWebElement Contact => this._webDriver.FindElement(By.CssSelector("li[class*='lg'] a[href='/contact/']"));

    public void present()
    {
      this._webDriverWait.Until(ExpectedConditions.ElementToBeClickable(Logo));
    }

  }
}
