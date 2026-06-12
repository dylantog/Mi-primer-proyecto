using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;
        
        [SetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        [Test]
        public void Create_Country_Test()
        {
            var URL = "http://localhost:8080/";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.LinkText("Agregar país")).Click();
            Assert.That(_driver.Url, Does.Contain("/country"));

            _driver.FindElement(By.Id("name")).SendKeys("México");

            var continent = new SelectElement(_driver.FindElement(By.Id("continente")));
            continent.SelectByText("América");

            _driver.FindElement(By.Id("idioma")).SendKeys("Español");

            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(2000);
            Assert.That(_driver.Url, Is.EqualTo(URL));

            Assert.That(_driver.PageSource.Contains("México"),Is.True);
        }
    }
}
