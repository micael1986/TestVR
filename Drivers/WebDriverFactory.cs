using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace TestVR.Drivers
{

  public class WebDriverFactory
  {

    private readonly TimeSpan _waitDuration = TimeSpan.FromSeconds(30);

    public static IWebDriver CreateWebDriver()
    {
      BrowserType browserType = ConfigurationDriver.Browser();
      string remoteUrl = ConfigurationDriver.SeleniumRemoteUrl();

      switch (browserType)
      {
        case BrowserType.CHROME: return GetChromeDriver(false);
        case BrowserType.FIREFOX: return GetFirefoxDriver(false);
        case BrowserType.CHROMEHEADLESS: return GetChromeDriver(true);
        case BrowserType.FIREFOXHEADLESS: return GetFirefoxDriver(true);
        default: throw new NotSupportedException("not supported browser");

      }
    }

    private static IWebDriver GetFirefoxDriver(bool isHeadless)
    {
      var firefoxOptions = new FirefoxOptions();
      string remoteUrl = ConfigurationDriver.SeleniumRemoteUrl();

      if (Uri.IsWellFormedUriString(remoteUrl, UriKind.Absolute))
      {
        Uri uri = new Uri(remoteUrl);
        return new RemoteWebDriver(uri, firefoxOptions);
      }

      var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
      if (isHeadless)
      {
        firefoxOptions.AddArgument("headless");
      }
      return new FirefoxDriver(firefoxDriverService, firefoxOptions);
    }

    private static IWebDriver GetChromeDriver(bool isHeadless)
    {
      var chromeOptions = new ChromeOptions();
      string remoteUrl = ConfigurationDriver.SeleniumRemoteUrl();
      if (Uri.IsWellFormedUriString(remoteUrl, UriKind.Absolute))
      {
        Uri uri = new Uri(remoteUrl);
        return new RemoteWebDriver(uri, chromeOptions);
      }
      var chromeDriverService = ChromeDriverService.CreateDefaultService();

      if (isHeadless)
      {
        chromeOptions.AddArgument("headless");
      }
      return new ChromeDriver(chromeDriverService, chromeOptions);
    }

  }
}
