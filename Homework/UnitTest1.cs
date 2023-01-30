using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Homework
{
    public class Tests
    {
        public WebDriver driver;


        [OneTimeSetUp]
        public void Setup()

        {
            driver = new ChromeDriver("C:\\Users\\user\\Desktop\\llona\\Chrome driver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");

        }

        [Test, Order(1)]

        public void SignUp()

        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("signin2"))).Click();

            var username = driver.FindElement(By.Id("sign-username"));
            var password = driver.FindElement(By.Id("sign-password"));


            username.SendKeys("Ilonagg");
            password.SendKeys("123456");

            var signup = driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[2]"));
            signup.Click();

        }

        [Test, Order(2)]

        public void LogIn()

        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login2"))).Click();

            var username = driver.FindElement(By.Id("loginusername"));
            var password = driver.FindElement(By.Id("loginpassword"));


            username.SendKeys("Ilonagg");
            password.SendKeys("123456");

            var login = driver.FindElement(By.XPath("//button[@class='btn btn-primary' and text()= 'Log in']"));
            login.Click();

            var user = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Welcome Ilonagg")));
            Assert.That(user.Text, Is.EqualTo("Welcome Ilonagg"));


        }

        [Test, Order(3)]


        public void AddToCart()

        {
            var laptops = driver.FindElement(By.XPath("(//a[@Id='itemc'])[2]"));
            laptops.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("MacBook air"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Add to cart"))).Click();

            wait.Until(ExpectedConditions.AlertIsPresent());
            var alertText = driver.SwitchTo().Alert();
            Console.WriteLine(alertText.Text);

            Assert.That(alertText.Text, Is.EqualTo("Product added"));
            driver.SwitchTo().Alert().Accept();


        }

        [Test, Order(4)]


        public void PurchaseTheItem()

        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Cart"))).Click();

            var order = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn btn-success' and text()= 'Place Order']")));
            order.Click();

            var name = driver.FindElement(By.Id("name"));
            var country = driver.FindElement(By.Id("country"));
            var city = driver.FindElement(By.Id("city"));
            var creditcard = driver.FindElement(By.Id("card"));
            var month = driver.FindElement(By.Id("month"));
            var year = driver.FindElement(By.Id("year"));

            name.SendKeys("Ilona");
            country.SendKeys("Lithuania");
            city.SendKeys("Vilnius");
            creditcard.SendKeys("1234");
            month.SendKeys("12");
            year.SendKeys("2024");

            var purchase = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn btn-primary' and text()= 'Purchase']")));
            purchase.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());
            var alertText = driver.SwitchTo().Alert();
            Console.WriteLine(alertText.Text);

            Assert.That(alertText.Text, Is.EqualTo("Thank you for your purchase!"));
            driver.SwitchTo().Alert().Accept();

        }


    }

}