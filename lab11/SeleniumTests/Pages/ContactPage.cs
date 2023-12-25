using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Pages
{
    public class ContactPage
    {
        private const string BASE_URL = "https://relouis.by/contacts/";

        [FindsBy(How = How.ClassName, Using = "jq-selectbox__select")]
        private readonly IWebElement _selectThemes;

        [FindsBy(How = How.Id, Using = "formName")]
        private readonly IWebElement _inputName;

        [FindsBy(How = How.Id, Using = "formEmail")]
        private readonly IWebElement _inputEmail;

        [FindsBy(How = How.Id, Using = "formMess")]
        private readonly IWebElement _inputMessage;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div/div/div[2]/div[2]/div/form/div[6]/input[2]")]
        private readonly IWebElement _sendMessage;


        public IWebDriver _driver;

        private Actions action;

        public ContactPage(IWebDriver driver)
        {
            Thread.Sleep(2000);
            _driver = driver;
            action = new Actions(driver);
            PageFactory.InitElements(driver, this);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(BASE_URL);
        }

        public void SelectTheme()
        {
            action.MoveToElement(_selectThemes);
            action.MoveByOffset(0, 100);
            action.Click();
            action.Build();
            action.Perform();
            Thread.Sleep(3000);

        }

        public void FillInInfo()
        {
            _inputName.SendKeys("test");
            _inputEmail.SendKeys("test@gmail.com");
            _inputMessage.SendKeys("testtesttest");

            _sendMessage.Click();
        }
    }
}
