using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LivingDocumentationEvent.Pages
{
    internal class AccountsOverviewPage
    {
        private WebDriver driver;

        public AccountsOverviewPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsVisible()
        {
            return ElementIsVisible(By.XPath("//h1[contains(text(),'Accounts Overview')]"));
        }

        private bool ElementIsVisible(By by)
        {
            Thread.Sleep(1000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = driver.FindElement(by);
                    return tempElement.Displayed ? tempElement : null;
                }
                );
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
