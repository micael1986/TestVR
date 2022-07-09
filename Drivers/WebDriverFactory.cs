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
      IWebDriver webDriver;

      switch (browserType)
      {
        case BrowserType.CHROME:
          webDriver = GetChromeDriver();
          break;
        case BrowserType.FIREFOX:
          webDriver = GetFirefoxDriver();
          break;
        default:
          throw new NotSupportedException("not supported browser");
      }
      webDriver.Manage().Window.Maximize();
      return webDriver;
    }

    private static IWebDriver GetFirefoxDriver()
    {
      var firefoxOptions = new FirefoxOptions();

      if (ConfigurationDriver.Mode() == ModeType.REMOTE)
      {
        return new RemoteWebDriver(ConfigurationDriver.SeleniumRemoteUrl(), firefoxOptions);
      }
      if (isHeadless()) firefoxOptions.AddArguments(getHeadlessArguments());
      var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
      return new FirefoxDriver(firefoxDriverService, firefoxOptions);
    }

    private static IWebDriver GetChromeDriver()
    {
      var chromeOptions = new ChromeOptions();

      if (ConfigurationDriver.Mode() == ModeType.REMOTE)
      {
        return new RemoteWebDriver(ConfigurationDriver.SeleniumRemoteUrl(), chromeOptions);
      }
      if (isHeadless()) chromeOptions.AddArguments(getHeadlessArguments());
      var chromeDriverService = ChromeDriverService.CreateDefaultService();
      return new ChromeDriver(chromeDriverService, chromeOptions);
    }

    private static bool isHeadless()
    {
      return ConfigurationDriver.Mode() == ModeType.HEADLESS;
    }

    private static string[] getHeadlessArguments()
    {
      return new string[] { "--headless", "window-size=1920,1080" };
    }
  }
}
