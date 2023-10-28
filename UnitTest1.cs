using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumTests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

        }

        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl("https://www.alza.cz");
            // Click on the login button
            IWebElement loginButton = driver.FindElement(By.CssSelector("[data-testid='headerContextMenuToggleLogin']"));
            loginButton.Click();

            // Enter the email and password
            IWebElement emailField = driver.FindElement(By.Id("userName"));
            emailField.SendKeys("alzatest.ja.ke+doma@alza.cz");

            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("heslo123");

            // Click on the submit button
            IWebElement submitButton = driver.FindElement(By.Id("btnLogin"));
            submitButton.Click();

            // Go to BO
            driver.Navigate().GoToUrl("https://www.alza.cz/my-account/profile/delivery-adress");



            // Create a WebDriverWait object with a timeout of 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait until the element is clickable using the CSS selector
            IWebElement CreateNewAddress = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[data-testid='button-addAddress']")));

            // Click on the element
            CreateNewAddress.Click();





        }
    }
}