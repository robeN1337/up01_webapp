using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;


namespace SampleApp.Test
{
    public class Tests
    {
        private readonly SampleAppContext _db;
        private IWebDriver driver;
        private const string LOGIN = "robbz";
        private const string PASSWORD = "1111";
        private string EMAIL;
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
        public void PasswordConfirmationEqualTest()
        {
            Random random = new Random();
            string s = "",
            IWebElement userNameElement = driver.FindElement(By.Id("user-name"));
            IWebElement passwordElement = driver.FindElement(By.Id("password"));
            IWebElement registerBtn = driver.FindElement(By.Id("submit-btn"));

            userNameElement.SendKeys(LOGIN);
            passwordElement.SendKeys(PASSWORD);
            registerBtn.Click();
            System.Threading.Thread.Sleep(2000);
            




        }
    }
}
