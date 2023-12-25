using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab11
{
    [TestFixture]
    public class RelouisTests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void SetUp()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void ChangeSiteLanguage()
        {
            var languageChanged = steps.ChangeLanguage();
            Assert.That(languageChanged, Is.True);
        }
 
        [Test]
        public void SearchPanelItem()
        {
            var panelWorks = steps.SearchPanel();
            Assert.That(panelWorks, Is.True);
        }

        [Test]
        public void NavigateToDeliveryPage()
        {
            var deliveryPageOpen = steps.DeliveryPage();
            Assert.That(deliveryPageOpen, Is.True);
        }

        [Test]
        public void GetCatalogItem()
        {
            var isRightItem = steps.CatalogItem();
            Assert.That(isRightItem, Is.True);
        }

        [Test]
        public void AddItemFromCatalogToBasket()
        {
            var isAdded = steps.AddItemToBasket();
            Assert.That(isAdded, Is.True);
        }

        [Test]
        public void DeleteItemFromBasket()
        {
            var isDeleted = steps.DeleteItemsFromBasket();
            Assert.That(isDeleted, Is.True);
        }

        [Test]
        public void BuyItem()
        {
            var isBought = steps.BuyItems();
            Assert.That(isBought, Is.False);
        }

        [Test]
        public void UsePromocode()
        {
            var isFilled = steps.TryFillPromocode();
            Assert.That(isFilled, Is.True);
        }

        [Test]
        public void FillMessage()
        {
            var isFilledMessage = steps.FillInMessage();
            Assert.That(isFilledMessage, Is.False);
        }


        [Test]
        public void ViewNews()
        {
            var isNewsShowed = steps.CheckNews();
            Assert.That(isNewsShowed, Is.True);
        }

        /*[Test]
        public void Search()
        {
            var isSearchWorking = steps.BasicSearch();
            Assert.That(isSearchWorking, Is.True);
        }*/
    }
}
