using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab11.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace Lab11.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://relouis.by/";

        [FindsBy(How = How.XPath, Using = "//*[@id=\"header\"]/div/nav/ul/li[6]/ul/li[1]")]
        private readonly IWebElement _linkDelivery;

        [FindsBy(How = How.ClassName, Using = "language-button")]
        private readonly IWebElement _language;

        [FindsBy(How = How.ClassName, Using = "fa-search")]
        private readonly IWebElement _search;

        [FindsBy(How = How.Id, Using = "search")]
        private readonly IWebElement _inputSearchText;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div/div[2]/div/div[1]/a")]
        private readonly IWebElement _viewMore;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"header\"]/div/div[2]/div[5]")]
        private readonly IWebElement _toggleMenu;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"header\"]/div/nav/ul/li[6]")]
        private readonly IWebElement _clientsBar;

        public IWebDriver _driver;

        private Actions action;

        public MainPage(IWebDriver driver)
        {
            Thread.Sleep(2000);
            action = new Actions(driver);
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ChangeLanguage()
        {
            _language.Click();
        }

        public void Search()
        {
            _search.Click();
        }

        public void SendEnter()
        {
            action.SendKeys(Keys.Enter);
            action.Perform();
        }

        public void InputSearchText()
        {
            _inputSearchText.SendKeys("Помада");
            _inputSearchText.SendKeys(Keys.Enter);
        }

        public bool IsSearchWorkingRight()
        {
            return _driver.Title == "Вы искали Помада - Relouis - декоративная косметика";
        }

        public bool IsLanguageSet()
        {
            return _viewMore.Text == "View all";
        }

        public bool GoToDeliveryPage()
        {
            
            //_toggleMenu.Click();
            _clientsBar.Click();
            Thread.Sleep(1000);
            _linkDelivery.Click();

            return _driver.Title == "Доставка? косметики - Relouis?";
        }

        public void GoToNews()
        {
            _viewMore.Click();
        }

        public bool HasGotNews()
        {
            return _driver.Title == "Наши новинки - Relouis - декоративная косметика";
        }
    }
}
