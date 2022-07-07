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
      IWebDriver webDriver;

      switch (browserType)
      {
        case BrowserType.CHROME:
          webDriver = GetChromeDriver(false);
          break;
        case BrowserType.FIREFOX:
          webDriver = GetFirefoxDriver(false);
          break;
        case BrowserType.CHROMEHEADLESS:
          webDriver = GetChromeDriver(true);
          break;
        case BrowserType.FIREFOXHEADLESS:
          webDriver = GetFirefoxDriver(true);
          break;
        default:
          throw new NotSupportedException("not supported browser");
      }
      webDriver.Manage().Window.Maximize();
      return webDriver;
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
        firefoxOptions.AddArgument("--headless");
        firefoxOptions.AddArgument("window-size=1920,1080");
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
        chromeOptions.AddArgument("window-size=1920,1080");
      }
      return new ChromeDriver(chromeDriverService, chromeOptions);
    }

  }
}
