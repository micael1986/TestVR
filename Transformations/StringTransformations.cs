using TechTalk.SpecFlow;

namespace TestVR.Steps
{
  [Binding]
  public sealed class StringTransformations
  {
    [StepArgumentTransformation]
    public List<String> TransformToListOfString(string commaSeparatedList)
    {
      return commaSeparatedList.Split(",").ToList();
    }
  }
}
