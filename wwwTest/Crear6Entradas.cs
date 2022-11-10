using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class Crear6Entradas
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
       // private static string baseURL;
       // private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new EdgeDriver();
            //baseURL = "https://www.google.com/";
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
        public void TheCrear6EntradasTest()
        {

            driver.Navigate().GoToUrl("https://localhost:44312/InicioSesion.aspx");
            driver.FindElement(By.Id("Email_Input")).Click();
            driver.FindElement(By.Id("Email_Input")).Clear();
            driver.FindElement(By.Id("Email_Input")).SendKeys("user@ubu.es");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("pass1234");
            driver.FindElement(By.Id("Button1")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Clear();
            driver.FindElement(By.Id("EntradaNombre_Input")).SendKeys("Primera");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("cualquiera1234");
            driver.FindElement(By.Id("EntradaButton")).Click();
            driver.Navigate().GoToUrl("https://localhost:44312/UsuarioWeb.aspx");
            driver.FindElement(By.Id("EntradaNombre_Input")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Clear();
            driver.FindElement(By.Id("EntradaNombre_Input")).SendKeys("Segunda");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("cualquiera1234");
            driver.FindElement(By.Id("EntradaButton")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Clear();
            driver.FindElement(By.Id("EntradaNombre_Input")).SendKeys("Tercera");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("tercera1234");
            driver.FindElement(By.Id("EntradaButton")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Clear();
            driver.FindElement(By.Id("EntradaNombre_Input")).SendKeys("Cuarta");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("cuarta1234");
            driver.FindElement(By.Id("EntradaButton")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Clear();
            driver.FindElement(By.Id("EntradaNombre_Input")).SendKeys("Quinta");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("cualquiera1234");
            driver.FindElement(By.Id("EntradaButton")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Clear();
            driver.FindElement(By.Id("EntradaNombre_Input")).SendKeys("Sexta");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("sexta1234");
            driver.FindElement(By.Id("EntradaButton")).Click();
        }
    }
}
