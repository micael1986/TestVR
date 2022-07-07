using TestVR.Drivers;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

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
        if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
        {
          var path = Directory.GetCurrentDirectory();
          var screenshotPath = Path.Combine(path, "Screenshots");
          Directory.CreateDirectory(screenshotPath);
          var tempFile = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
          var screenshot = takesScreenshot.GetScreenshot();
          var tempFileName = Path.Combine(screenshotPath, tempFile) + ".jpeg";
          screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
          var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
          Console.WriteLine($"SCENARIO: {scenarioTitle} -> SCREENSHOT: [ {tempFileName} ]");
        }
      }
    }

  }
}
