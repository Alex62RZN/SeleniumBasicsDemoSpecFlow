using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasicsDemo;
using System;
using TechTalk.SpecFlow;

namespace SeleniumBasicsDemo2
{

    [Binding]
    public class NortWindTestsSteps
    {
        private IWebDriver driver;

        [Given(@"Я открываю ""(.*)"" url")]
        public void GivenЯОткрываюUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Url = url;
        }

        [When(@"Я вхожу в систему с именем ""(.*)"" и паролем ""(.*)""")]
        public void WhenЯСовершаюВходВСистемуСИменемИПаролем(string login, string password)
        {
            LoginPage loginPage = new LoginPage(driver);

            Assert.IsTrue(loginPage.Login("user", "user").isLoginSuccessfull(), "Login failed");
        }

        [Then(@"Вход успешен")]
        public void ThenВходВСистемуУдачен()
        {
            Assert.IsTrue(new MainPage(driver).isLoginSuccessfull(), "Login failed");
        }

        
        [When(@"Я нажимаю на ссылку All Products")]
        public void WhenЯНажимаюНаСсылкуAllProducts()
        {
            AllProductsPage allProductsPage1 = new AllProductsPage(driver);
        }

        [Then(@"Открывается страница All Products")]
        public void ThenОткрываетсястраницаAllProducts()
        {
            AllProductsPage allProductsPage1 = new AllProductsPage(driver);

            Assert.IsTrue(allProductsPage1.AllProduct().adding(), "Adding failed");
        }

        [When(@"Я нажимаю на ссылку Create new")]
        public void WhenЯНажимаюНаСсылкуCreateNew()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/a")).Click();
        }

        [Then(@"Открывается страница Product editing")]
        public void ThenОткрываетсяСтраницаProductEditing()
        {
            driver.FindElement(By.XPath(".//*[text()='Product editing']"));
        }

        [Then(@"Я создаю новый продукт")]
        public void ThenЯСоздаюНовыйПродукт()
        {

            driver.FindElement(By.Id("ProductName")).SendKeys("Steak");

            driver.FindElement(By.Id("CategoryId")).Click();

            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/select/option[7]")).Click();

            driver.FindElement(By.XPath("/html/body/div[2]/form/div[3]/div/select/option[7]")).Click();

            driver.FindElement(By.Id("UnitPrice")).SendKeys("500");

            driver.FindElement(By.XPath("/html/body/div[2]/form/input[1]")).Click();
        }

        [Then(@"Я проверяю созданный продукт")]
        public void ThenЯПроверяюСозданныйПродукт()
        {
            driver.FindElement(By.LinkText("Steak")).Click();

            string name = driver.FindElement(By.Id("ProductName")).GetAttribute("value");
            Assert.AreEqual("Steak", name, "Incorrect Product name");

            string category = driver.FindElement(By.Id("CategoryId")).GetAttribute("value");
            Assert.AreEqual("6", category, "Incorrect Category Id");

            string supplier = driver.FindElement(By.Id("SupplierId")).GetAttribute("value");
            Assert.AreEqual("6", supplier, "Incorrect Supplier Id");

            string price = driver.FindElement(By.Id("UnitPrice")).GetAttribute("value");
            Assert.AreEqual("500,0000", price, "Incorrect Unit Price");
        }
        [Then(@"Выхожу из систем")]
        public void ThenВыхожуИзСистем()
        {
            LogoutPage logoutPage = new LogoutPage(driver);

            Assert.IsTrue(logoutPage.Logout().isLogoutSuccessfull(), "Logout Faild");

            driver.Close();
        }
    }    
}
