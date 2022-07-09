using System.Configuration;
namespace TestVR.Drivers
{
  public class ConfigurationDriver
  {

    public static BrowserType Browser()
    {
      string? browserTypeEnv = Environment.GetEnvironmentVariable("BROWSER");
      if (!string.IsNullOrEmpty(browserTypeEnv)) return Enum.Parse<BrowserType>(browserTypeEnv.ToUpper());
      BrowserType browserType = BrowserType.CHROME;
      Console.WriteLine($"### USING THE DEFAULT BROWSER {browserType}");
      return browserType;
    }

    public static Uri? SeleniumRemoteUrl()
    {
      string defaultUrl = "http://127.0.0.1:4444/wd/hub";
      string? urlEnv = Environment.GetEnvironmentVariable("SELENIUM_REMOTE_URL");
      if (!string.IsNullOrEmpty(urlEnv) && Uri.IsWellFormedUriString(urlEnv, UriKind.Absolute)) new Uri(urlEnv);
      Console.WriteLine($"### USING THE DEFAULT REMOTE URL {defaultUrl}");
      return new Uri(defaultUrl);
    }
    public static ModeType Mode()
    {
      string? modeTypeEnv = Environment.GetEnvironmentVariable("MODE");
      if (!string.IsNullOrEmpty(modeTypeEnv)) return Enum.Parse<ModeType>(modeTypeEnv.ToUpper());
      ModeType modeType = ModeType.LOCAL;
      Console.WriteLine($"### USING THE DEFAULT MODE {modeType}");
      return modeType;
    }
  }
}
