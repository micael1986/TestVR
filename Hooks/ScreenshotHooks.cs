using TestVR.Drivers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using TestVR.Helpers;
namespace TestVR.Hooks
{
  [Binding]
  public sealed class ScreenshotHooks
  {
    private readonly BrowserDriver _browserDriver;
    private readonly ScenarioContext _scenarioContext;

    public ScreenshotHooks(BrowserDriver browserDriver, ScenarioContext scenarioContext)
    {
      _browserDriver = browserDriver;
      _scenarioContext = scenarioContext;
    }

    [AfterScenario]
    public void MakeScreenshotAfterScenario()
    {
      if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
      {
        string browserName = SeleniumHelper.isChrome(_browserDriver.Current) ? "chrome" : "firefox";
        if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
        {
          var path = Directory.GetCurrentDirectory();
          var screenshotPath = Path.Combine(path, "Screenshots");
          Directory.CreateDirectory(screenshotPath);
          var tempFile = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
          var screenshot = takesScreenshot.GetScreenshot();
          var scenarioTitle = TextHelper.MakeValidFileName(_scenarioContext.ScenarioInfo.Title);
          var tempFileName = Path.Combine(screenshotPath, $"{scenarioTitle}-{browserName}-{tempFile}.jpeg");
          screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
          Console.WriteLine($"SCENARIO: {scenarioTitle} -> SCREENSHOT: [ {tempFileName} ]");
        }
      }
    }

  }
}
