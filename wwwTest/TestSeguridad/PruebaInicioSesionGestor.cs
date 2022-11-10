using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class PruebaInicioSesionGestor
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void ThePruebaInicioSesionGestorTest()
        {
            driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
            driver.Navigate().GoToUrl("https://localhost:44312/InicioSesion.aspx");
            driver.FindElement(By.Id("Email_Input")).Clear();
            driver.FindElement(By.Id("Email_Input")).SendKeys("admin@ubu.es");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("abcd1234");
            driver.FindElement(By.XPath("//form[@id='form1']/h1")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/h1")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//form[@id='form1']/h1 | ]]
            driver.FindElement(By.XPath("//form[@id='form1']/h1")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/h1")).Click();
            try
            {
                Assert.AreEqual("INICIO DE SESIÓN", driver.FindElement(By.XPath("//form[@id='form1']/h1")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("Button1")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del gestor'])[1]/preceding::h1[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del gestor'])[1]/preceding::h1[1]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del gestor'])[1]/preceding::h1[1] | ]]
            try
            {
                Assert.AreEqual("Gestor", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del gestor'])[1]/preceding::h1[1]")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//form[@id='form1']/button[5]/span")).Click();
            driver.Navigate().GoToUrl("https://localhost:44312/GestorWeb.aspx");
            driver.FindElement(By.Id("CerrarSesiónButton")).Click();
            driver.Navigate().GoToUrl("https://localhost:44312/InicioSesion.aspx");
            driver.FindElement(By.XPath("//form[@id='form1']/h1")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/h1")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//form[@id='form1']/h1 | ]]
            driver.FindElement(By.XPath("//form[@id='form1']/h1")).Click();
            try
            {
                Assert.AreEqual("INICIO DE SESIÓN", driver.FindElement(By.XPath("//form[@id='form1']/h1")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
