using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System;

namespace SeleniumTests
{
    public class WebsiteTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://avidreaders.ru/");
        }

        [Test]
        public void TestPageTitle()
        {
            string title = driver.Title;
            Console.WriteLine("Title: " + title);
            Assert.AreEqual("Скачать полные версии книг бесплатно. Читай только лучшее!", title);

        }

        [Test]
        public void TestButtonClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));  // Увеличьте до 30 секунд

            IWebElement button = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"login\"]")));
            button.Click();
            // Добавьте ассерты для проверки ожидаемого результата
        }

        [Test]
        public void TestElementVisibility()
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a | //div | //img")));
            Assert.IsTrue(element.Displayed);
        }

        [Test]
        public void TestLinkNavigation()
        {
            IWebElement link = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a")));
            link.Click();
            
        }

        [Test]
        public void TestTextFieldInput()
        {
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"email_login\"]")));
            inputField.Clear();
            inputField.SendKeys("test@example.com");
            Assert.AreEqual("test@example.com", inputField.GetAttribute("value"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
