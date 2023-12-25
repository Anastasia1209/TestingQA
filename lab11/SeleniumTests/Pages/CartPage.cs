using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace Lab11.Pages
{
    public class CartPage
    {
        private const string BASE_URL = "https://relouis.by/cart/";

        [FindsBy(How = How.ClassName, Using = "cart-block-item")]
        private readonly IWebElement _cartItem;

        [FindsBy(How = How.ClassName, Using = "cart-block-item-remove")]
        private readonly IWebElement _deleteBasketItems;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"cart-block\"]/div/div")]
        private readonly IWebElement _isBasketEmpty;

        [FindsBy(How = How.Id, Using = "cart-block-order-button")]
        private readonly IWebElement _buyItem;

        [FindsBy(How = How.Id, Using = "get-order-button")]
        private readonly IWebElement _makeOrder;

        [FindsBy(How = How.Id, Using = "promo-code")]
        private readonly IWebElement _inputPromoCode;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"promo-form\"]/div[2]/div[2]/input")]
        private readonly IWebElement _activatePromocode;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"popmake-15630\"]/button")]
        private readonly IWebElement _closeAd;

        public IWebDriver _driver;

        Actions action;

        public CartPage(IWebDriver driver)
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

        public bool DeleteItems()
        {
            Thread.Sleep(5000);
            _closeAd.Click();
            Thread.Sleep(1000);
            action.ScrollByAmount(0, 150);
            action.Perform();
            action.MoveToElement(_cartItem);
            action.Perform();

            _deleteBasketItems.Click();

            return _isBasketEmpty.Displayed;
        }

        public bool Buyitem()
        {
            Thread.Sleep(5000);
            _closeAd.Click();
            Thread.Sleep(1000);


            _buyItem.Click();
            Thread.Sleep(1000);
            return !_makeOrder.Enabled;
        }

        public void InputPromoCode()
        {
            Thread.Sleep(5000);
            _closeAd.Click();
            Thread.Sleep(1000);
            _inputPromoCode.SendKeys("test");
        }

        public void ActivatePromo()
        {
            _activatePromocode.Click();
        }
    }
}
