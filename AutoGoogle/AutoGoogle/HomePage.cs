using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoGoogle
{
    [TestFixture]
    public class Home
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {

            ChromeOptions option = new ChromeOptions();
            option.AddArguments("disable-extensions");
            option.AddAdditionalCapability("useAutomationExtension", false);

            driver = new ChromeDriver(option);

            driver.Navigate().GoToUrl("https://www.google.com/");

        }
        [Test]
        public void Search()
        {
            String searchTerm = "GitHub multiple branches";

            IWebElement ele_SearchTxtBox = driver.FindElement(By.Name("q"));

            ele_SearchTxtBox.SendKeys(searchTerm);

            ele_SearchTxtBox.SendKeys(OpenQA.Selenium.Keys.Enter);

            String pageSource = driver.PageSource;

            Assert.IsTrue(pageSource.Contains(searchTerm));
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();

            //driver.Quit();
        }
    }
}
