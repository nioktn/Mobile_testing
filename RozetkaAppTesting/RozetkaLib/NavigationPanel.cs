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
    public class NavigationPanel
    {
        private readonly AppiumDriver<AndroidElement> driver;
        private readonly By _secRecyclerView = By.Id("ua.com.rozetka.shop:id/rv_menu");
        private readonly By _btnSignIn = By.Id("ua.com.rozetka.shop:id/menu_sign_up");
        private readonly By _btnSignUp = By.Id("ua.com.rozetka.shop:id/menu_sign_up");
        private readonly By _btnMain = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[1]");
        private readonly By _btnCatalog = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[2]");
        private readonly By _btnShare = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[3]");
        private readonly By _btnDiscount = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[4]");
        private readonly By _btnPersonalData = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[5]");
        private readonly By _btnCart = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[6]");
        private readonly By _btnWishList = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[7]");
        private readonly By _btnWaitList = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[8]");
        private readonly By _btnOrders = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[9]");
        private readonly By _btnComparison = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[10]");
        private readonly By _btnWatched = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[11]");
        private readonly By _btnFeedback = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[12]");
        private readonly By _btnInfo = By.XPath("//android.support.v7.widget.RecyclerView[1]/android.widget.RelativeLayout[13]");
        private readonly By _btnNavPage = By.XPath("//android.widget.ImageButton[@content-desc='Перейти вверх']");

        public AndroidElement BtnSignIn { get => driver.FindElement(_btnSignIn); }
        public AndroidElement BtnSignUp { get => driver.FindElement(_btnSignUp); }
        public AndroidElement BtnMain { get => driver.FindElement(_btnMain); }
        public AndroidElement BtnCatalog { get => driver.FindElement(_btnCatalog); }
        public AndroidElement BtnPersonalData { get => driver.FindElement(_btnPersonalData); }
        public AndroidElement BtnCart { get => driver.FindElement(_btnCart); }
        public AndroidElement BtnWishList { get => driver.FindElement(_btnWishList); }
        public AndroidElement BtnWaitList { get => driver.FindElement(_btnWaitList); }
        public AndroidElement BtnOrders { get => driver.FindElement(_btnOrders); }
        public AndroidElement BtnComparison { get => driver.FindElement(_btnComparison); }
        public AndroidElement BtnWatched { get => driver.FindElement(_btnWatched); }

        public NavigationPanel(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool IsRecyclerViewOpened()
        {
            return ElemHelper.IsElementVisible(driver, _btnMain);
        }

        public void Open()
        {
            driver.FindElement(_btnNavPage).Click();
        }

        public void Open(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(d, _btnNavPage));
            driver.FindElement(_btnNavPage).Click();
            wait.Until((d) => ElemHelper.IsElementVisible(d, _btnCatalog));
        }
    }
}
