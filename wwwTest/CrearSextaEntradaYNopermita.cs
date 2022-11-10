using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace SeleniumTests
{
    [TestClass]
    public class CrearSextaEntradaYNopermita
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        
        
        
        [SetUp]
        public void SetupTest()
        {
            
            //baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheCrearSextaEntradaYNopermitaTest()
        {
            for(int i= 0; i < 2; i++)
            {
                if (i == 0) {
                    driver = new FirefoxDriver();
                }
                else
                {
                    driver = new EdgeDriver();
                }
               
            }
            driver.Navigate().GoToUrl("https://localhost:44338/InicioSesion.aspx");
            driver.FindElement(By.Id("Email_Input")).Click();
            driver.FindElement(By.Id("Email_Input")).Clear();
            driver.FindElement(By.Id("Email_Input")).SendKeys("admin@ubu.es");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("abcd1234");
            driver.FindElement(By.Id("Button1")).Click();
            driver.FindElement(By.Id("CambiarAUsuarioButton")).Click();
            driver.Navigate().GoToUrl("https://localhost:44338/GestorWeb.aspx");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del usuario'])[1]/preceding::h1[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del usuario'])[1]/preceding::h1[1]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del usuario'])[1]/preceding::h1[1] | ]]
            try
            {
                Assert.AreEqual("Usuario", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del usuario'])[1]/preceding::h1[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | relative=parent | ]]
            driver.FindElement(By.Id("EntradaNombre_Input")).Click();
            driver.FindElement(By.Id("EntradaNombre_Input")).Clear();
            driver.FindElement(By.Id("EntradaNombre_Input")).SendKeys("Sexta");
            driver.FindElement(By.Id("Password_Input")).Click();
            driver.FindElement(By.Id("Password_Input")).Clear();
            driver.FindElement(By.Id("Password_Input")).SendKeys("nopermite");
            driver.FindElement(By.Id("EntradaButton")).Click();
            driver.Navigate().GoToUrl("https://localhost:44338/UsuarioWeb.aspx");
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='Has completado los 5 secretos por hora']/parent::*")).Click();
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='Has completado los 5 secretos por hora']/parent::*")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//*/text()[normalize-space(.)='Has completado los 5 secretos por hora']/parent::* | ]]
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='Has completado los 5 secretos por hora']/parent::*")).Click();
            try
            {
                Assert.AreEqual("Has completado los 5 secretos por hora\n\n\n\n\n\n\n\n\n\n Usuario \n Bienvenido a la página del usuario\n \n\n\n\n\n\n\n	\n	\n\n \n\n \n\n\n Crea tu entrada \n \n Nombre Entrada\n \n \n \n\n \n\n \n \n Password\n \n \n \n \n \n \n \n Enviar\n 22/23\n \n \n \n \n Enviar\n 22/23\n \n\n \n \n \n Cerrar Sesión\n 22/23\n \n \n\n \n\n\nKatalon Recorder is recording ...Stop", driver.FindElement(By.XPath("//*/text()[normalize-space(.)='Has completado los 5 secretos por hora']/parent::*")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Bienvenido a la página del usuario'])[1]/preceding::h1[1]")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/button[3]/span")).Click();
            driver.FindElement(By.Id("CerrarSesión")).Click();
            driver.Navigate().GoToUrl("https://localhost:44338/InicioSesion.aspx");
        }
    }
}
