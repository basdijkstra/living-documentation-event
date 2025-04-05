using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LivingDocumentationEvent.Pages
{
    internal class LoginPage
    {
        private WebDriver driver;

        private By textfieldUsername = By.Name("username");
        private By textfieldPassword = By.Name("password");
        private By buttonDoLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage Open()
        {
            this.driver.Navigate().GoToUrl("http://localhost:8080/parabank");
            return this;
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(textfieldUsername, username);
            SendKeys(textfieldPassword, password);
            Click(buttonDoLogin);
        }

        private void SendKeys(By by, string valueToType)
        {
            Thread.Sleep(1000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Clear();
                myElement.SendKeys(valueToType);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {by.ToString()} not visible and enabled within 10 seconds.");
            }
        }

        public void Click(By by)
        {
            Thread.Sleep(1000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Click(): element located by {by.ToString()} not visible and enabled within 10 seconds.");
            }
        }
    }
}
