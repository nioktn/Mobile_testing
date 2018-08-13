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
            Assert.IsTrue(navPan.IsRecyclerViewOpened());
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
    }
}
