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
    public static string MakeValidFileName(string name)
    {
      string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
      string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

      return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
    }

  }
}
