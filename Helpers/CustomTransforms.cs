// using TechTalk.SpecFlow;
// using FluentAssertions;
// using OpenQA.Selenium;

// namespace TestVR.Helpers
// {
//   [Binding]
//   public sealed class CustomTransforms
//   {

//     private readonly ScenarioContext _scenarioContext;

//     public CustomTransforms(ScenarioContext scenarioContext)
//     {
//       _scenarioContext = scenarioContext;
//     }


//     [StepArgumentTransformation(@"element:(.*)")]
//     public IWebElement TransformToWebElementOnCurrentPage(string elementName)
//     {
//       object currentPage = _scenarioContext["CurrentPage"];
//       //get the property of the current page with the given name
//       var props = currentPage.GetType().GetProperties();
//       return (IWebElement)props.First(x => x.Name == elementName).GetValue(null);
//     }
//   }
// }
