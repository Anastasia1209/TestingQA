using Lab11.Pages;
using OpenQA.Selenium;

namespace Lab11.Steps
{
    public class Steps
    {
        public IWebDriver _driver;

        /*private CatalogPage catalogPage;
        private CartPage basketPage;
        private ContactPage comparePage;
        private ProductPage productPage;
        private MainPage mainPage;*/


        public void InitBrowser()
        {
            _driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }


        public bool ChangeLanguage()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();

            mainPage.ChangeLanguage();

            return mainPage.IsLanguageSet();
        }

        public bool SearchPanel()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();

            Thread.Sleep(2000);
            mainPage.Search();
            Thread.Sleep(2000);
            mainPage.InputSearchText();
            Thread.Sleep(2000);

            return mainPage.IsSearchWorkingRight();
        }

        public bool DeliveryPage()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();
           
            return mainPage.GoToDeliveryPage();
        }

        public bool CatalogItem()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            Thread.Sleep(1000);
            catalogPage.GoToCatalogItem(0);
            return catalogPage.IsRightCatalogItem();
        }

        public bool AddItemToBasket()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem();
            Thread.Sleep(2000);
            return catalogPage.TryAddItemToBasket();
        }

        public bool DeleteItemsFromBasket()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem();

            catalogPage.TryAddItemToBasket();

            var cartPage = new Pages.CartPage(catalogPage._driver);
            cartPage.OpenPage();
            Thread.Sleep(2000);
            return cartPage.DeleteItems();
        }

        public bool BuyItems()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem();

            catalogPage.TryAddItemToBasket();

            var cartPage = new Pages.CartPage(catalogPage._driver);
            cartPage.OpenPage();
            Thread.Sleep(2000);
            return cartPage.Buyitem();
        }

        public bool TryFillPromocode()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem();

            catalogPage.TryAddItemToBasket();

            var cartPage = new Pages.CartPage(catalogPage._driver);
            cartPage.OpenPage();
            Thread.Sleep(2000);
            cartPage.InputPromoCode();
            Thread.Sleep(2000);
            cartPage.ActivatePromo();

            return true;
        }

        public bool FillInMessage()
        {
            var contactPage = new Pages.ContactPage(_driver);
            contactPage.OpenPage();
            contactPage.SelectTheme();
            contactPage.FillInInfo();

            return false;
        }

        public bool CheckNews()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();
            mainPage.GoToNews();

            return mainPage.HasGotNews();
        }

        /*public void CatalogPageInitAndOpen()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            Thread.Sleep(1000);
        }

        private void BasketPageInitAndOpen()
        {
            var basketPage = new Pages.CartPage(_driver);
            basketPage.OpenPage();
            Thread.Sleep(1000);
        }

        private void ComparePageInitAndOpen()
        {
            var comparePage = new Pages.ContactPage(_driver);
            comparePage.OpenPage();
            Thread.Sleep(1000);
        }
       
        private void MainPageInitAndOpen()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();
            Thread.Sleep(1000);
        }

        public int AddToBasketAndGetBasketCount()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            Thread.Sleep(1000);
            catalogPage.GoToCatalogItem(1);

            Thread.Sleep(2000);
            var productPage = new Pages.ProductPage(catalogPage._driver);
            productPage.AddItemToBasket();

            var basketPage = new Pages.CartPage(productPage._driver);
            return basketPage.GetBasketItemsCount();
        }

        public int AddToCompareAndGetCompareListCount()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            var productPage = new Pages.ProductPage(catalogPage._driver);
            var comparePage = new Pages.ContactPage(catalogPage._driver);

            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem(0);
            productPage.AddItemToCompareList();

            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem(1);
            productPage.AddItemToCompareList();

            comparePage.OpenPage();
            return comparePage.GetCompareListItemsCount();
        }

        public bool SendReview()
        {
            var catalogPage = new Pages.CatalogPage(_driver);

            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem(0);

            var productPage = new Pages.ProductPage(catalogPage._driver);
            productPage.OpenAddReviewWindow();
            productPage.FillInReview();
            productPage.SendReview();

            return productPage.IsReviewSended();
        }

        public bool RemoveItemFromBasketViaCatalog()
        {
            var catalogPage = new Pages.CatalogPage(_driver);

            catalogPage.OpenPage();
            Thread.Sleep(1000);
            catalogPage.NavigateToItem(0);
            Thread.Sleep(5000);
            catalogPage.AddToBasketFromCatalog();
            Thread.Sleep(1000);
            catalogPage.OpenPage();
            catalogPage.NavigateToBasket();
            Thread.Sleep(2000);
            catalogPage.RemoveItemFromBasket();
            Thread.Sleep(1000);

            catalogPage.NavigateToItem(0);

            return catalogPage.IsItemSelected();
        }

        public bool MakeRecordDoctor()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            Thread.Sleep(1000);
            catalogPage.OpenMakeOrderToDoctor();
            Thread.Sleep(1000);
            catalogPage.FillInRecord();
            Thread.Sleep(1000);
            catalogPage.ClickCaptcha();
            Thread.Sleep(10000);
            catalogPage.SendRecord();
            Thread.Sleep(1000);

            return catalogPage.IsRecordSended();
        }

        public bool EmailSubscription()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();
            Thread.Sleep(1000);
            mainPage.FillEmail();
            Thread.Sleep(1000);
            mainPage.SubscribeEmail();
            Thread.Sleep(1000);


            return true;
        }

        public bool SearchTextCapability()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();
            Thread.Sleep(1000);
            mainPage.Search();
            Thread.Sleep(1000);
            mainPage.InputSearchText();
            Thread.Sleep(7000);
            mainPage.Search();

            return false;
        }

        public bool FastOrder()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();
            catalogPage.GoToCatalogItem(0);

            var productPage = new Pages.ProductPage(catalogPage._driver);
            Thread.Sleep(1000);
            productPage.MakeFastOrder();
            Thread.Sleep(1000);

            productPage.FillInFastOrder();
            Thread.Sleep(1000);

            productPage.CommitFastOrder();
            Thread.Sleep(2000);

            return productPage.IsCommitedFastOrder();
        }

        public bool ToggleMenu()
        {
            var catalogPage = new Pages.CatalogPage(_driver);
            catalogPage.OpenPage();

            catalogPage.ToggleMenuClick();
            Thread.Sleep(5000);

            return catalogPage.IsActiveToggleMenu();
        }

        public bool BasicSearch()
        {
            var mainPage = new Pages.MainPage(_driver);
            mainPage.OpenPage();

            mainPage.InputSearchGlassesText();

            return mainPage.GetSearchItemsCount() > 0;
        }*/
    }
}
