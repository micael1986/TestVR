using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;
using TestVR.Helpers;

namespace TestVR.PageObjects
{
  public class ContactPageObject
  {
    private const string baseUrl = "https://www.verisksequel.com";

    private readonly IWebDriver _webDriver;

    private readonly WebDriverWait _webDriverWait;

    public const int DefaultWaitInSeconds = 5;

    public ContactPageObject(BrowserDriver browserDriver)
    {
      _webDriver = browserDriver.Current;
      _webDriverWait = browserDriver.CurrentWait;
    }

    //Finding elements by ID
    private IWebElement ContactUs => _webDriver.FindElement(By.XPath("//h2[contains(text(),'Contact us')]"));

    private IWebElement ContactForm => _webDriver.FindElement(By.CssSelector("[class*='form contact']"));
    private IWebElement Name => ContactForm.FindElement(By.CssSelector("[class*=name]"));

    private IWebElement Company => ContactForm.FindElement(By.CssSelector("[class*=company]"));
    private IWebElement JobTitle => ContactForm.FindElement(By.CssSelector("[class*=jobtitle]"));
    private IWebElement EmailAddress => ContactForm.FindElement(By.CssSelector("[class*=emailaddress]"));
    private IWebElement PhoneNumber => ContactForm.FindElement(By.CssSelector("[class*=phonenumber]"));
    private IWebElement Message => ContactForm.FindElement(By.CssSelector("[class*=message]"));
    private IWebElement EnquiryType => ContactForm.FindElement(By.CssSelector("[class*=enquirytype]"));

    private IWebElement Suscribing => ContactForm.FindElement(By.CssSelector("[class*=subscribing]"));
    private IWebElement Recaptcha => ContactForm.FindElement(By.CssSelector("[class*='recaptcha ']"));

    private IWebElement Submit => ContactForm.FindElement(By.CssSelector("[type=submit]"));

    public Waits GetWaits => new Waits(_webDriverWait);

    public void navigate()
    {
      _webDriver.Navigate().GoToUrl(baseUrl + "/contact/");
    }

    public bool present()
    {
      return _webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(ContactUs, "Contact us"));
    }

    public IWebElement getWebElement(string element)
    {
      string lowerTrim = Regex.Replace(element.ToLower(), @"\s+", String.Empty);
      switch (lowerTrim)
      {
        case "name": return Name;
        case "company": return Company;
        case "jobtitle": return JobTitle;
        case "emailaddress": return EmailAddress;
        case "phonenumber": return PhoneNumber;
        case "message": return Message;
        case "enquirytype": return EnquiryType;
        case "subscribing": return Suscribing;
        case "recaptcha": return Recaptcha;
        default: throw new NotSupportedException("Element not found");
      }
    }

  }
}
