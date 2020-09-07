using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace NUnitTestProject1
{
    [TestFixture]
    public class RozetkaSelenium
    {
        ExtentReports report = ExtendManagerForRozetkaTest.GetInstance();
        ExtentTest test;
        [Test]
        public void TestMethod()
        {
            test = report.CreateTest("Test Rozetka", "");
            test.Log(Status.Info, "Starting");            
            

            IWebDriver driver = new FirefoxDriver();
            
            driver.Url = "https://rozetka.com.ua/";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//span[text()='Каталог товаров']")).Click();

            driver.FindElement(By.XPath("//a[text()='Смартфоны, ТВ и электроника']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            

            try
            {
                driver.FindElement(By.XPath("//div//img[@alt='Телефоны, наушники, GPS']")).Click();
            }
            catch
            {
                try
                {
                    driver.FindElement(By.XPath("//a[text()='Смартфоны']")).Click();
                }
                catch
                {
                    driver.FindElement(By.XPath("//div//img[@alt='Телефоны, наушники, GPS']")).Click();
                }
            }


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//span//img[@alt='Мобильные телефоны']")).Click();


            //Actions action = new Actions(driver);
            new Actions(driver).MoveToElement(driver.FindElement(By.XPath("//input[@id='Apple']"))).Click().Build().Perform();

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0,900);");

            new Actions(driver).MoveToElement(driver.FindElement(By.XPath("//input[@id='Samsung']"))).Click().Build().Perform();
            js.ExecuteScript("window.scrollBy(0,1800);");
            new Actions(driver).MoveToElement(driver.FindElement(By.XPath("//input[@id='128 ГБ']"))).Click().Build().Perform();
            js.ExecuteScript("window.scrollBy(0,-1800);");
            

            var element = driver.FindElement(By.XPath("//div[@class='slider-filter__inner']/input[@formcontrolname='max']"));
            element.Clear();
            element.SendKeys("20000");
            driver.FindElement(By.XPath("//div[@class='slider-filter__inner']/button[@type='submit']")).Click();
            test.Log(Status.Pass, "Test passed");
            driver.Quit();
            report.Flush();
        }
    }
}
