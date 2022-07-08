using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace TestVR.Helpers
{
  public class SeleniumHelper
  {
    public static bool isChrome(IWebDriver driver)
    {

      if (driver.GetType() == typeof(RemoteWebDriver))
      {
        RemoteWebDriver remote = (RemoteWebDriver)driver;
        var capabilities = remote.Capabilities.GetCapability("browserName") as string;
        return capabilities == "chrome";
      }
      // Using local browser driver
      return driver.GetType() == typeof(ChromeDriver);
    }
  }
}
