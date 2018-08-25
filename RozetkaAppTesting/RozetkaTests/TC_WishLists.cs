using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using RozetkaLib;
using System;
using System.Collections.Generic;

namespace RozetkaTests
{
    public class TC_WishLists : BlankTest
    {
        NavigationPanel navPanel;

        [Test]
        public void Test_OpenLocalWishList()
        {
            navPanel = new NavigationPanel(driver);
            navPanel.OpenLoginPage(wait)
                .LogIn("testmail@outlook.com", "Testpassword1", wait);

            WishList localWishList = navPanel
                .Open(wait)
                .OpenWishLists(wait)
                .OpenGuestWishList(wait);
            String actualTitle = localWishList.EmptyTitle.Text;
            String expectedTitle = "Этот список пуст";
            StringAssert.AreEqualIgnoringCase(expectedTitle, actualTitle);
        }

        [Test]
        public void WishListTests()
        {
            Test_AddLaptopsToWishList();
            Test_RemoveLaptopsFromWishList();
        }

        public void Test_AddLaptopsToWishList()
        {
            navPanel = new NavigationPanel(driver);
            navPanel.OpenCatalogPage(wait).SelectCategory("Ноутбуки и компьютеры", wait);
            LaptopsCategory lapCat = new LaptopsCategory(driver);
            ProductsListPage productsList = lapCat.OpenAllLaptopsProductsList(wait);

            List<String> laptopsModels = new List<String> { "81AK00ALRA", "90NR0GP1-M00950", "80XL03UJRA" };

            foreach (var item in laptopsModels)
            {
                AndroidElement currentProduct = productsList.GetProduct(item, wait);
                if (currentProduct != null) new ProductCompactView(driver, currentProduct).AddToWishList(wait);
                else continue;
            }

            IList<AndroidElement> prodElemsInWishList = navPanel.
                Open(wait).
                OpenWishLists(wait).
                OpenGuestWishList(wait).
                WishedProductsList;

            bool[] matchNames = new bool[3];
            int count = 0;
            foreach (var item in prodElemsInWishList)
            {
                matchNames[count] = new ProductCompactView(driver, item).ProductName.Text.Contains(laptopsModels[count]);
                count++;
            }

            Assert.IsTrue(matchNames[0] & matchNames[1] & matchNames[2]);
        }

        public void Test_RemoveLaptopsFromWishList()
        {
            WishList rmWishList = new WishList(driver);
            var currentWishedProductsList = rmWishList.WishedProductsList;
            for (int i = currentWishedProductsList.Count-1; i >= 0; i--)
            {
                new ProductCompactView(driver, currentWishedProductsList[i]).DeleteFromWishList(wait);
            }

            Assert.IsTrue(wait.Until((d) => rmWishList.IsEmpty()));
        }
    }
}
