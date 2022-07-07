using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestVR.Drivers
{
  public class BrowserDriver : IDisposable
  {

    private readonly Lazy<IWebDriver> _currentWebDriverLazy;

    private readonly Lazy<WebDriverWait> _waitLazy;

    private readonly TimeSpan _waitDuration = TimeSpan.FromSeconds(30);

    private readonly TimeSpan _implicitWait = TimeSpan.FromSeconds(10);
    private bool _isDisposed;

    public BrowserDriver()
    {
      _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
      _waitLazy = new Lazy<WebDriverWait>(GetWebDriverWait);
      Current.Manage().Timeouts().ImplicitWait = _implicitWait;
    }

    public IWebDriver Current => _currentWebDriverLazy.Value;

    public WebDriverWait CurrentWait => _waitLazy.Value;

    private WebDriverWait GetWebDriverWait()
    {
      return new WebDriverWait(Current, _waitDuration);
    }

    private IWebDriver GetWebDriver()
    {
      return WebDriverFactory.CreateWebDriver();
    }

    public void Dispose()
    {
      if (_isDisposed)
      {
        return;
      }

      if (_currentWebDriverLazy.IsValueCreated)
      {
        Current.Quit();
      }

      _isDisposed = true;
    }
  }
}
