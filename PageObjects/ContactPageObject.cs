using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestVR.Drivers;

namespace TestVR.PageObjects
{
  public class ContactPageObject : BasePageObject
  {
    public ContactPageObject(BrowserDriver browserDriver) : base(browserDriver) { }

    public IWebElement ContactUs => this._webDriver.FindElement(By.XPath("//h2[contains(text(),'Contact us')]"));
    public IWebElement ContactForm => this._webDriver.FindElement(By.CssSelector("[class*='form contact']"));
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

    public void navigate()
    {
      _webDriver.Navigate().GoToUrl($"{GetBaseUrl}/contact/");
    }

    public bool present()
    {
      return _webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(ContactUs, "Contact us"));
    }

    public IWebElement getEnquiryTypeWebElement(string value)
    {
      return this.EnquiryType.FindElement(By.CssSelector($"option[value='{value}']"));
    }
  }
}
