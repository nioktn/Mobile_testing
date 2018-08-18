using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace RozetkaLib
{
    public class SearchPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _searchOpenButton = By.Id("ua.com.rozetka.shop:id/action_search");
        private readonly By _searchInputField = By.Id("ua.com.rozetka.shop:id/et_search_section");
        private readonly By _searchOpenField = By.Id("ua.com.rozetka.shop:id/ll_search");

        public AndroidElement SearchOpenButton { get => driver.FindElement(_searchOpenButton); }
        public AndroidElement SearchInputField { get => driver.FindElement(_searchInputField); }
        public AndroidElement SearchOpenField { get => driver.FindElement(_searchOpenField); }


        public SearchPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public SearchPage Open(WebDriverWait wait)
        {
            if (ElemHelper.IsElementVisible(driver, _searchOpenButton))
            {
                SearchOpenButton.Click();
            }
            else if (ElemHelper.IsElementVisible(driver, _searchOpenField))
            {
                SearchOpenField.Click();
            }
            ISendsKeyEvents sendsKeyEvents = driver;
            wait.Until((d) => ElemHelper.IsElementExists(d, _searchInputField));
            Thread.Sleep(2000);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Back);
            Thread.Sleep(1000);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Back);
            return this;
        }
    
        public void EnterSearchQuery(String query, WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _searchInputField));
            SearchInputField.SendKeys(query);
            ISendsKeyEvents sendsKeyEvents = driver;
            SearchInputField.Click();
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Enter);
            sendsKeyEvents.PressKeyCode(AndroidKeyCode.Keycode_ENTER);

        }
    }
}
