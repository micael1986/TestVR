using BoDi;
using TestVR.Drivers;
using TechTalk.SpecFlow;

namespace TestVR.Hooks
{
  [Binding]
  public class SharedBrowserDriverHooks
  {
    [BeforeFeature]
    public static void RegisterInstanceBrowserDriver(ObjectContainer objectContainer)
    {
      objectContainer.RegisterInstanceAs<BrowserDriver>(new BrowserDriver());
    }
    [AfterFeature]
    public static void ResolveInstance(ObjectContainer objectContainer)
    {
      objectContainer.Resolve<BrowserDriver>().Current.Dispose();
    }
  }
}
