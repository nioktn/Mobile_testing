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

namespace RozetkaTests
{
    public class BlankTest
    {
        protected AndroidDriver<AndroidElement> driver;
        protected WebDriverWait wait;
        DesiredCapabilities capabilities; 

        [OneTimeSetUp]
        public void FirstInitialize()
        {            
            capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\Nikita\source\repos\Mobile_testing\Rozetka+v2.21.6.apk");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), capabilities);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        [OneTimeTearDown]
        public void LastCleanUp()
        {
            driver.CloseApp();
            driver.Quit();
        }
    }
}
