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

namespace RozetkaLib
{
    public class ProductsListPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _btnSort = By.XPath("//android.widget.LinearLayout/android.widget.RelativeLayout[1]");
        private readonly By _btnFilter = By.XPath("//android.widget.LinearLayout/android.widget.RelativeLayout[2]");
        private readonly By _btnView = By.XPath("//android.widget.LinearLayout/android.widget.FrameLayout[1]/android.widget.ImageView");
        private readonly By _productsList = By.XPath("//android.support.v7.widget.RecyclerView/android.widget.LinearLayout");

        public AndroidElement BtnSort { get => driver.FindElement(_btnSort); }
        public AndroidElement BtnFilter { get => driver.FindElement(_btnFilter); }
        public AndroidElement BtnView { get => driver.FindElement(_btnView); }
        public IList<AndroidElement> ProductsList { get => driver.FindElements(_productsList); }

        public ProductsListPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public List<AndroidElement> GetAvailableProducts()
        {
            return ProductsList as List<AndroidElement>;
        }

        public List<AndroidElement> GetAvailableProducts(WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_productsList));
            return ProductsList as List<AndroidElement>;
        }

        public AndroidElement GetProduct(String namePart)
        {
            foreach (var item in ProductsList)
            {
                if (item.Text.Contains(namePart)) return item;
            }
            return null;
        }

        public AndroidElement GetProduct(String namePart, WebDriverWait wait)
        {
            ElemHelper.ScrollToElement(driver, namePart);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_productsList));
            foreach (var item in ProductsList)
            {
                if (item.Text.Contains(namePart)) return item;
            }
            return null;
        }
    }
}
