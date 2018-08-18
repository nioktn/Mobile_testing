using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.Interfaces;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.Interfaces;
using RozetkaLib;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.MultiTouch;

namespace RozetkaTests
{
    public class Test : BlankTest
    {
        NavigationPanel navPan;

        [Test]
        public void Test_OpenNavPane()
        {
            navPan = new NavigationPanel(driver);
            navPan.Open(wait);
            Assert.IsTrue(navPan.IsNavigationPanelOpened());
        }

        [Test]
        public void Test_ClickNotVisibleButt()
        {
            navPan = new NavigationPanel(driver);
            navPan.Open(wait);
            //TouchActions touchActions = new TouchActions(driver);
            //touchActions.LongPress(recViewInstance.BtnCart).Move(recViewInstance.BtnMain.Location.X, recViewInstance.BtnMain.Location.Y).Release().Perform();

            ElemHelper.ScrollToElement(driver, "Просмотренные");
            navPan.BtnWatched.Click();
            Thread.Sleep(5000);
        }

        [Test]
        public void Test_CategoryClick()
        {
            navPan = new NavigationPanel(driver);
            navPan.Open(wait);

            navPan.BtnCatalog.Click();
            CatalogPage catPage = new CatalogPage(driver);

            ElemHelper.ScrollToElement(driver, catPage._childProducts);
            catPage.ChildProducts.Click();

            Thread.Sleep(5000);
        }


        [Test]
        public void ChooseSomeNotebooks()
        {
            navPan = new NavigationPanel(driver);
            navPan.OpenCatalogPage(wait)
                .LaptopsAndComputers.Click();

            LaptopsCategory lapCat = new LaptopsCategory(driver);
            Thread.Sleep(2000);


            TouchAction tacts = new TouchAction(driver);
            tacts.Tap(lapCat.GetCategoryByName("Ноутбуки")).Perform();
            Thread.Sleep(2000);

            wait.Until((d) => ElemHelper.IsElementVisible(driver, lapCat._btnAllLaptops));
            Thread.Sleep(2000);

            lapCat.BtnAllLaptops.Click();
            Thread.Sleep(2000);

            ProductsListPage prLsPage = new ProductsListPage(driver);
            prLsPage.GetToWishListButton(prLsPage.GetProduct("3GC44EA", wait)).Click();
            prLsPage.GetToWishListButton(prLsPage.GetProduct("90NR0GN1-M03880", wait)).Click();
            prLsPage.GetToWishListButton(prLsPage.GetProduct("2EW20ES", wait)).Click();
            Thread.Sleep(5000);
            navPan.Open();
            ElemHelper.ScrollToElement(driver, "Списки желаний");
            navPan.BtnWishList.Click();
            Thread.Sleep(3000);
        }

        [Test]
        public void SearchTest()
        {
            navPan = new NavigationPanel(driver);
            Thread.Sleep(5000);
            navPan.Close();
            SearchPage searchPage = new SearchPage(driver);
            searchPage.Open(wait)
                .EnterSearchQuery("notebook", wait);
            Thread.Sleep(3000);
            Thread.Sleep(5000);

        }
    }
}
