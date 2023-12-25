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
    public class CatalogPage
    {
        private const string BASE_URL = "https://relouis.by/product_category/zhidkie-teni/";

        [FindsBy(How = How.ClassName, Using = "category-item-image-container")]
        private readonly IList<IWebElement> _catalogItems;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div/div/div[1]/div[2]/div[3]/div[2]")]
        private readonly IWebElement _buyItem;

        [FindsBy(How = How.Id, Using = "add-to-cart-modal")]
        private readonly IWebElement _modalWindow;

        public IWebDriver _driver;

        private Actions action;

        public CatalogPage(IWebDriver driver)
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

        public IWebElement GetCatalogItem(int numberOfItem)
        {
            return _catalogItems[numberOfItem];
        }

        public void GoToCatalogItem(int numberOfItem)
        {
            action.ScrollByAmount(0, 100);
            action.Perform();
            _catalogItems[numberOfItem].Click();
        }

        public bool IsRightCatalogItem()
        {
            return _driver.Title == "Тени для век жидкие сатиновые RELOUIS PRO Satin Liquid Eyeshadow - Relouis - декоративная косметика";
        }

        public void GoToCatalogItem()
        {
            _driver.Navigate().GoToUrl("https://relouis.by/product/relouis-pro-satin-liquid-eyeshadow/");
        }

        public bool TryAddItemToBasket()
        {
            _buyItem.Click();
            Thread.Sleep(2000);
            return _modalWindow.Displayed;
        }
    }
}
