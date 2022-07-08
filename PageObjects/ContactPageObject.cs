using System.Reflection;
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
    public IWebElement ContactUs => _webDriver.FindElement(By.XPath("//h2[contains(text(),'Contact us')]"));

    public IWebElement ContactForm => _webDriver.FindElement(By.CssSelector("[class*='form contact']"));
    public IWebElement Name => ContactForm.FindElement(By.CssSelector("[class*=name]"));
    public IWebElement Company => ContactForm.FindElement(By.CssSelector("[class*=company]"));
    public IWebElement JobTitle => ContactForm.FindElement(By.CssSelector("[class*=jobtitle]"));
    public IWebElement EmailAddress => ContactForm.FindElement(By.CssSelector("[class*=emailaddress]"));
    public IWebElement PhoneNumber => ContactForm.FindElement(By.CssSelector("[class*=phonenumber]"));
    public IWebElement Message => ContactForm.FindElement(By.CssSelector("[class*=message]"));
    public IWebElement EnquiryType => ContactForm.FindElement(By.CssSelector("[class*=enquirytype]"));

    public IWebElement Subscribing => ContactForm.FindElement(By.CssSelector("[class*=subscribing]"));
    public IWebElement Recaptcha => ContactForm.FindElement(By.CssSelector("[class*='recaptcha ']"));

    public IWebElement Submit => ContactForm.FindElement(By.CssSelector("[class*='navigation']"));

    public Waits GetWaits => new Waits(_webDriverWait);

    public void navigate()
    {
      _webDriver.Navigate().GoToUrl(baseUrl + "/contact/");
    }

    public bool present()
    {
      return _webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(ContactUs, "Contact us"));
    }

    public IWebElement getEnquiryTypeWebElement(string value)
    {
      return this.EnquiryType.FindElement(By.CssSelector($"option[value='{value}']"));
    }
    public IWebElement getWebElement(string element)
    {
      string elementName = "";
      foreach (string s in element.Split(" "))
      {
        elementName = String.Concat(elementName, TextHelper.FirstCharToUpper(s));
      }
      string methodName = $"get_{elementName}";
      var webElement = this.GetType().GetMethod(methodName)?.Invoke(this, null) as IWebElement
      ?? throw new NotSupportedException($"Element not found {methodName}");
      return webElement;
    }

  }
}
