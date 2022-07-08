using System.Text.RegularExpressions;

namespace TestVR.Helpers
{
  public class TextHelper
  {
    public static string FirstCharToUpper(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      return char.ToUpper(s[0]) + s.Substring(1);
    }
    public static string RemoveWhiteSpaces(string s)
    {
      return Regex.Replace(s, @"\s+", String.Empty);
    }
  }
}
