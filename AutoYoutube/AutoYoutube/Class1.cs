using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutoYoutube
{
    [TestFixture]
    public class Class1
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {

            ChromeOptions option = new ChromeOptions();
            option.AddArguments("disable-extensions");
            option.AddAdditionalCapability("useAutomationExtension", false);
            driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("https://www.youtube.com/");
        }
        [Test]
        public void searchVideo()
        {
            String searchTerm = "Selenium Tutorial";

            IWebElement ele_searchTxtbox = driver.FindElement(By.Id("search"));

            ele_searchTxtbox.SendKeys(searchTerm);
            ele_searchTxtbox.SendKeys(OpenQA.Selenium.Keys.Enter);

        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();

            driver.Close();
        }
    }
}
