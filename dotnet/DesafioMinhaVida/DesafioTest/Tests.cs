using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using DesafioMinhaVida.DAO;
using System.Collections.Generic;
using DesafioMinhaVida.Entities;
using System.Linq;

namespace DesafioTest
{
    [TestClass]
    public class Tests
    {
        public object ElectricGuitarDAO { get; private set; }

        [TestMethod]
        public void ItShouldInsertANewGuitar()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://localhost:61023/ElectricGuitar/Form");

            IWebElement Name = driver.FindElement(By.Id("eGuitar.name"));
            IWebElement Price = driver.FindElement(By.Id("eGuitar.price"));
            IWebElement Description = driver.FindElement(By.Id("eGuitar.description"));
            IWebElement ImageUrl = driver.FindElement(By.Id("eGuitar.imageurl"));

            Name.SendKeys("Les Paul");
            Price.SendKeys("1000.50");
            Description.SendKeys("The best guitar of the world");
            ImageUrl.SendKeys("ImageUrl");

            IWebElement submit = driver.FindElement(By.Id("btn-submit"));

            submit.Click();

            bool foundName = driver.PageSource.Contains("Les Paul");
            bool foundPrice = driver.PageSource.Contains("1000.50");
            bool foundDescription = driver.PageSource.Contains("The best guitar of the world");

            driver.Close();
            Assert.IsTrue(foundName);
            Assert.IsTrue(foundPrice);
            Assert.IsTrue(foundDescription);
        }

        [TestMethod]
        public void ItShouldEditOneElectricGuitar()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://localhost:61023/ElectricGuitar/Index");

            // The example is using on purpose the id 12
            IWebElement editBtn = driver.FindElement(By.Id("edit-12"));

            editBtn.Click();

            IWebElement Name = driver.FindElement(By.Id("eGuitar.name"));
            IWebElement Price = driver.FindElement(By.Id("eGuitar.price"));
            IWebElement Description = driver.FindElement(By.Id("eGuitar.description"));
            IWebElement ImageUrl = driver.FindElement(By.Id("eGuitar.imageurl"));

            Name.Clear();
            Name.SendKeys("Les Paul Edited");
            Price.Clear();
            Price.SendKeys("1400.50");
            Description.Clear();
            Description.SendKeys("The best guitar of the world...edited!");
            ImageUrl.Clear();
            ImageUrl.SendKeys("ImageUrl...edited too");

            IWebElement submit = driver.FindElement(By.Id("btn-submit"));
            submit.Click();

            bool foundName = driver.PageSource.Contains("Les Paul Edited");
            bool foundPrice = driver.PageSource.Contains("1400.50");
            bool foundDescription = driver.PageSource.Contains("The best guitar of the world...edited!");

            driver.Close();
            Assert.IsTrue(foundName);
            Assert.IsTrue(foundPrice);
            Assert.IsTrue(foundDescription);
        }

        [TestMethod]
        public void ItShouldDeleteOneElectricGuitar()
        {
            // Adding a new electric guitar
            IWebDriver driver = new FirefoxDriver();            
            
            driver.Navigate().GoToUrl("http://localhost:61023/ElectricGuitar/Form");

            IWebElement Name = driver.FindElement(By.Id("eGuitar.name"));
            IWebElement Price = driver.FindElement(By.Id("eGuitar.price"));
            IWebElement Description = driver.FindElement(By.Id("eGuitar.description"));
            IWebElement ImageUrl = driver.FindElement(By.Id("eGuitar.imageurl"));

            Name.SendKeys("Les Paul");
            Price.SendKeys("1000.50");
            Description.SendKeys("The best guitar of the world");
            ImageUrl.SendKeys("ImageUrl");

            IWebElement submit = driver.FindElement(By.Id("btn-submit"));

            submit.Click();

            IList<IWebElement> rows = driver.FindElements(By.ClassName("eGuitarRow"));
            // Number of electric guitars before adding
            int numberRowsBefore = rows.Count;
            string[] words = rows[rows.Count - 1].Text.Split(' ');

            IWebElement delete = driver.FindElement(By.Id("delete-" + words[0]));

            delete.Click();

            rows = driver.FindElements(By.ClassName("eGuitarRow"));
            int numberRowsAfter = rows.Count;

            driver.Close();            
            Assert.AreNotEqual(numberRowsBefore, numberRowsAfter);
        }
    }
}
