using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnitTestChromeProject
{
    public class GoogleTest
    {
        [Test]
        public void SearchTerm_ClickOnSecondResult()
        {
            //Step 1 - Open Chrome
            IWebDriver webDriver = new ChromeDriver();

            //Step 2 - go to Google site
            webDriver.Navigate().GoToUrl("https://www.google.com");

            //Step 3- look for the search box and search the term 'software tester'
            IWebElement searchTextBox = webDriver.FindElement(By.Name("q"));
            searchTextBox.SendKeys("software tester");
            IWebElement searchButton = webDriver.FindElement(By.XPath("//div[@class='FPdoLc tfB0Bf']//input[@name='btnK']"));
            searchButton.Click();

            //Step 4 - Click on the second result from the second page
            //find and click second page
            IWebElement secondPage = webDriver.FindElement(By.LinkText("2"));
            secondPage.Click(); 
            //find and click second link
            IWebElement secondLink = webDriver.FindElement(By.XPath("//div[2]/div/div/a/h3/span"));
            secondLink.Click();

            //Step 5 - Check the page title
            string pageTitle = webDriver.Title;
            string expectedTitle = "Software testing Jobs in New Zealand | Glassdoor.co.nz";
            Assert.AreEqual(true, pageTitle.Contains(expectedTitle), "Title is wrong");
        }
    }
}