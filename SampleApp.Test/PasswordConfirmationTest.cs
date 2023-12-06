using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SampleApp.Models;
using System.IO;


namespace SampleApp.Test
{
    public class Tests
    {
        private readonly SampleAppContext _db;
        private IWebDriver driver;
        private const string LOGIN = "robbz";
        private const string PASSWORD = "1111";
        private string EMAIL = "lolol@git";
        private const string PASSWORD_CONFIRMATION = "1111";

        [SetUp]
        public void Init()
        {
            //driver = new ChromeDriver(Directory.GetCurrentDirectory());
            driver = new ChromeDriver("C:/group/ip214/webapp/SampleApp");
            driver.Navigate().GoToUrl("https://localhost:7011/Sign");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);

        }

        

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

        [Test]
        public void FullRegistrationTest_Automatic()
        {
            IWebElement userNameElement = driver.FindElement(By.Id("user-name"));
            IWebElement emailElement = driver.FindElement(By.Id("email"));
            IWebElement passwordElement = driver.FindElement(By.Id("password"));
            IWebElement password_confirmationElement = driver.FindElement(By.Id("password-confirmation"));
            IWebElement registerBtn = driver.FindElement(By.Id("submit-btn"));

            userNameElement.SendKeys(LOGIN);
            emailElement.SendKeys(EMAIL);
            passwordElement.SendKeys(PASSWORD);
            password_confirmationElement.SendKeys(PASSWORD_CONFIRMATION);
            registerBtn.Click();
            System.Threading.Thread.Sleep(2000);

        }

        [Test]
        public void PasswordConfirmationTest()
        {
           

            

            System.Threading.Thread.Sleep(2000);
        }
    }
}
