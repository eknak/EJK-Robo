using NUnit.Framework;

//Inside SeleniumTest.cs

using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;


using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCsharp

{

    public class Tests

    {

        ChromeDriver driver;

        [OneTimeSetUp]

        public void Setup()

        {

            //Below code is to get the drivers folder path dynamically.

            //You can also specify chromedriver.exe path dircly ex: C:/MyProject/Project/drivers

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            //Creates the ChomeDriver object, Executes tests on Google Chrome

            ChromeOptions options = new ChromeOptions();
            
            options.AddArgument(@"--user-data-dir=c:\Cache --disable-machine-cert-request");
            

            driver = new ChromeDriver(path + @"\drivers\", options);            

        }

       

        [Test]

        public void verifyLogo()
        {
            DevToolsSession devToolsSession = driver.GetDevToolsSession();
            
            driver.Navigate().GoToUrl("https://www.comprasnet.gov.br/seguro/loginPortal.asp");
            
            Thread.Sleep(500);

            //Actions action = new Actions(driver);
            //action.SendKeys("\t\t\n");
            //action.Perform();
            ///Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed);
        }


        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}
