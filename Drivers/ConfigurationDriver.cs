namespace TestVR.Drivers
{
  public class ConfigurationDriver
  {


    public static BrowserType Browser()
    {

      BrowserType browserType = BrowserType.CHROME;

      // if (string.IsNullOrEmpty(SeleniumRemoteUrl()))
      // {
      //   browserType = BrowserType.CHROMEHEADLESS;
      // }

      string? browserTypeEnv = Environment.GetEnvironmentVariable("BROWSER");

      if (!string.IsNullOrEmpty(browserTypeEnv))
      {
        browserType = Enum.Parse<BrowserType>(browserTypeEnv.ToUpper());
      }
      return browserType;
    }

    public static string SeleniumRemoteUrl()
    {

      string? urlEnv = Environment.GetEnvironmentVariable("SELENIUM_REMOTE_URL");

      if (!string.IsNullOrEmpty(urlEnv)) return urlEnv;

      return "";
    }
  }
}
