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

namespace RozetkaLib
{
    public static class ElemHelper
    {
        public static bool IsElementVisible(IWebDriver driver, By Locator)
        {
            try { return driver.FindElement(Locator).Displayed; }
            catch { return false; }
        }

        public static bool IsElementExists(IWebDriver driver, By Locator)
        {
            try
            {
                driver.FindElement(Locator);
                return true;
            }
            catch { return false; }
        }

        public static void ScrollToElement(AndroidDriver<AndroidElement> driver, String textContent)
        {
            driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textMatches(\"" + textContent + "\").instance(0))"));
        }
    }
}
